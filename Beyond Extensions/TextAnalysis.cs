using System;
using System.IO;
using System.Text.RegularExpressions;

namespace TextAnalysis
{
    internal class TextAnalysis
    {
        /*static void Main(string[] args)
        {
            // Specify the path to the file you want to analyze
            string filePath = @"C:\path\to\your\file.txt";

            // Read the content of the file
            string fileContent = File.ReadAllText(filePath);

            // Detect script types
            if (IsJavaScript(fileContent))
            {
                Console.WriteLine("JavaScript script detected.");
            }
            else if (IsPython(fileContent))
            {
                Console.WriteLine("Python script detected.");
            }
            else
            {
                Console.WriteLine("Script type not identified.");
            }
        }*/

        static bool IsScriptofType(string content)
        {
            return false;
        }

        static bool IsJavaScript(string content)
        {
            // Use a simple regex pattern to identify JavaScript code
            string pattern = @"(function\s*\(.*\)|console\.log\s*\(|var\s+\w+\s*=\s*function\s*\()";
            return Regex.IsMatch(content, pattern);
        }

        static bool IsPython(string content)
        {
            // Use a simple regex pattern to identify Python code
            string pattern = @"(print\s*\(|def\s+\w+\s*\(|import\s+\w+)";
            return Regex.IsMatch(content, pattern);
        }
    }

}
