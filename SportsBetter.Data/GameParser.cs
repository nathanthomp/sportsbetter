using SportsBetter.Library.Game;
using System;
using System.Collections.Generic;
using System.IO;

namespace SportsBetter.Data
{
    public class GameParser
    {
        /*
         * Get a file and read its contents creating a bet for each line
         */
        public static List<NFLGame> Parse(string fileName)
        {
            List<NFLGame> result = new List<NFLGame>();
            if (File.Exists(fileName))
            {
                try
                {
                    using (StreamReader sr = new StreamReader(fileName))
                    {
                        string line;
                        NFLGame game;
                        while ((line = sr.ReadLine()) != null)
                        {
                            string[] lineArray = line.Split(',');
                            game = new NFLGame(lineArray[0], int.Parse(lineArray[1]), lineArray[2], int.Parse(lineArray[3]));
                            result.Add(game);
                        }
                    }
                }
                catch (IOException)
                {
                    Console.WriteLine($"Please close file: {fileName}");
                }

                return result;
            }
            else
            {
                throw new FileNotFoundException($"Cannot find file: {fileName}");
            }
        }
    }
}
