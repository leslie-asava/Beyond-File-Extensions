using System;
using System.IO;
using BinaryAnalysis;
using FileSignatures;

class Program
{
    static void Main(string[] args)
    {

        string filePath = "C:\\Users\\Leslie\\Documents\\Hello World\\Hello.pdf"; // Replace with Filepath
        string actualExtension = Path.GetExtension(filePath).TrimStart('.');
        string mappedExtension = FileSignatures.FileSignatures.ExtensionMap[actualExtension];

        if (BinaryAnalysis.BinaryAnalysis.IsFileOfType(filePath, actualExtension, mappedExtension))
        {
            Console.WriteLine($"PASS. The file {filePath} is indeed [{actualExtension}]");
        }
        else
        {
            Console.WriteLine($"Failed. The file {filePath} is not [{actualExtension}]");
            // BinaryAnalysis.BinaryAnalysis.DetectFileType(filePath, actualExtension);
        }
    }
}
