using ChessLogicLib;
using System;
using System.IO;

namespace Chess
{
    internal class WriteIntoConsole
    {
        public void Write(Action programLogic)
        {
            string filePath = "output.txt";

            using (StringWriter consoleOutput = new StringWriter())
            {
                TextWriter originalOutput = Console.Out; // Save the original Console output
                Console.SetOut(consoleOutput); // Redirect Console output to StringWriter
                try
                {
                    programLogic.Invoke();
                }
                finally
                {
                    // Restore the original Console output
                    Console.SetOut(originalOutput);
                    File.WriteAllText(filePath, consoleOutput.ToString());
                }
            }
        }
    }
}
