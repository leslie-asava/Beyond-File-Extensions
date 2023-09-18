using System;
using System.Collections.Generic;
using System.IO.Compression;
using FileSignatures;

namespace BinaryAnalysis
{
    internal class BinaryAnalysis
    {
        // Check for file types that can be determined by signature alone
        public static bool IsFileOfType(string filename, string actualExtension, string mappedExtension)
        {
            List<List<int>> signatures = FileSignatures.FileSignatures.BaseExtensionChecks[mappedExtension];
            try
            {
                using (FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read))
                {
                    byte[] header = new byte[signatures[0].Count];
                    int bytesRead = fs.Read(header, 0, header.Length);

                    foreach (var signature in signatures)
                    {
                        if (bytesRead == signature.Count)
                        {
                            bool match = true;
                            for (int i = 0; i < signature.Count; i++)
                            {
                                if (header[i] != signature[i])
                                {
                                    match = false;
                                    break;
                                }
                            }
                            if (match)

                                /*if (mappedExtension == "zip")
                                {
                                    foreach (var zipExtension in FileSignatures.FileSignatures.ZipBasedExtensionChecks)
                                    {
                                        if (IsFileBasedOffZip(filename, actualExtension, zipExtension.Value))
                                        {
                                            Console.WriteLine($"{filename} is a recognized {zipExtension.Key} file.");
                                            return true;
                                        }
                                    }
                                }*/

                                return true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            return false;
        }

        static bool IsFileBasedOnZip(string filename, string actualExtension, string[] structure)
        {
            try
            {
                using (FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read))
                using (ZipArchive zipArchive = new ZipArchive(fs, ZipArchiveMode.Read))
                {
                    // Check for specific directories or files within the ZIP archive
                    foreach (string part in structure)
                    {
                        if (part == actualExtension)
                            {
                            bool found = false;
                            foreach (ZipArchiveEntry entry in zipArchive.Entries)
                            {
                                if (entry.FullName.StartsWith(part))
                                {
                                    found = true;
                                    break;
                                }
                            }

                            if (!found)
                            {
                                return false;
                            }
                        }
                        
                    }

                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            return false;
        }
    }
}

