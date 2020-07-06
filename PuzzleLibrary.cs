using System;
using System.Collections.Generic;
using System.IO;

namespace WheelOfFortune
{
    public class PuzzleLibrary
    {
        private string _path = @"..\..\..\PuzzleLibrary.txt";
        private string[] library;
        static List<string> usedPuzzles = new List<string>();


        /// <summary>
        ///     This method randomly returns a puzzle string that is on the PuzzleLibrary.
        /// </summary>
        /// <returns></returns>
        public string GetNextPuzzle()
        {
            if (library == null)
            {
                try
                {
                    library = System.IO.File.ReadAllLines(_path);
                }
                catch (FileNotFoundException e)
                {
                    Console.WriteLine("Puzzle library file - {0} - is not found.", e.FileName);
                }
            }
            Random rand = new Random();
            while (true)
            {
                int next = rand.Next(0, library.Length - 1);
                if (!usedPuzzles.Contains(library[next]))
                {
                    usedPuzzles.Add(library[next]);

                    return library[next];
                }
                //TODO remove infinite loop
            }
            
            //Console.WriteLine("DEBUG: WORD IS: " + library[next]);//TODO - remove
             
        }
    }
}
