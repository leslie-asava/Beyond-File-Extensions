using System;
using System.Collections.Generic;

namespace FileSignatures
{
    internal class FileSignatures
    {
        public static Dictionary<string, List<List<int>>> BaseExtensionChecks = new Dictionary<string, List<List<int>>>()
        {
            // File types and their signatures
            { "exe", new List<List<int>>() { new List<int> { 0x4D, 0x5A } } }, // EXE
            { "pdf", new List<List<int>>() { new List<int> { 0x25, 0x50, 0x44, 0x46 } } }, // PDF
            { "zip", new List<List<int>>()
                {
                    new List<int> { 0x50, 0x4B, 0x03, 0x04 },
                    new List<int> { 0x50, 0x4B, 0x05, 0x06 }, // Empty Archive
                    new List<int> { 0x50, 0x4B, 0x07, 0x08 } // Spanned Archive
                }
            },
            { "png", new List<List<int>> { new List<int> { 0x89, 0x50, 0x4E, 0x47, 0x0D, 0x0A, 0x1A, 0x0A } }} // PNG
        };

        // File types based of zip
        public static Dictionary<string, string[]> ZipBasedExtensionChecks = new Dictionary<string, string[]>()
        {
            { "docx", new string[] { "word/", ".xml" } },
            { "pptx", new string[] { "ppt/", ".xml" } },
            { "apk", new string[] { "META-INF/", "AndroidManifest.xml" } },
            { "jar", new string[] { "META-INF/", "MANIFEST.MF" } },
            { "epub", new string[] { "META-INF/", "container.xml" } }
        };

        public static Dictionary<string, string> ExtensionMap = new Dictionary<string, string>()
        {
            {"exe", "exe" },
            {"pdf", "pdf" },
            {"zip", "zip" },
            {"docx", "zip" },
            {"pptx", "zip" },
            {"apk", "zip" },
            {"jar", "zip" },
            {"epub", "zip" },
            {"png", "png" },
        };



    }
}
