using System;
using System.Collections.Generic;
using System.IO;

namespace Max_Num_Of_Inequalities
{
    public class MaxInequalities
    {
        static int min, max, maxInequalitiesCount, optimalX;

        static void Main(string[] args)
        {
            //string path = @"C:\Users\petya.ko\Desktop\Max-Num-Of-Inequalities\Max-Num-Of-Inequalities\inequalities.in.txt";
            //string inputPath = @"C:\Users\PePsi\Desktop\Max-Num-Of-Inequalities\Max-Num-Of-Inequalities\inequalities.in.txt";
            //string outputPath = @"C:\Users\PePsi\Desktop\Max-Num-Of-Inequalities\Max-Num-Of-Inequalities\inequalities.out.txt";

            //Input
            Console.WriteLine("Please enter the path to the inequalities.in.txt");
            Console.WriteLine("Example => C:\\Users\\petya.ko\\Desktop\\Max-Num-Of-Inequalities\\Max-Num-Of-Inequalities\\inequalities.in.txt");
            string inputPath = Console.ReadLine();

            string outputPath = inputPath.Replace("inequalities.in.txt", "inequalities.out.txt");

            FindRange(inputPath, out min, out max);

            FindMaxInequalitiesCount(inputPath, out maxInequalitiesCount, out optimalX);

            List<string> inequalities = new List<string>();
            FindSetsOfInequalities(inputPath, out inequalities);

            OutputInFileAndConsole(outputPath, inequalities);
        }

        private static void OutputInFileAndConsole(string outputPath, List<string> inequalities)
        {
            //Clearing content of inequalities.out.txt file
            File.WriteAllText(outputPath, String.Empty);
            //File.Create(outputPath).Close();            

            //Add maxInequalitiesCount to the collection of inequalities because of the inequalities.out.txt
            inequalities.Insert(0, maxInequalitiesCount.ToString());

            //Write output in inequalities.out.txt
            File.WriteAllLines(outputPath, inequalities); //public static void WriteAllLines(string path, IEnumerable<string> contents);

            //Print output on the console
            foreach (var inequality in inequalities)
            {
                Console.WriteLine(inequality);
            }
        }

        private static void FindSetsOfInequalities(string inputPath, out List<string> inequalities)
        {
            inequalities = new List<string>();

            using (StreamReader sr = File.OpenText(inputPath))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] parts = line.Split(' ');

                    if (parts[1] == "<" && optimalX < Int32.Parse(parts[2]) ||
                        parts[1] == "<=" && optimalX <= Int32.Parse(parts[2]) ||
                        parts[1] == "=" && optimalX == Int32.Parse(parts[2]) ||
                        parts[1] == ">=" && optimalX >= Int32.Parse(parts[2]) ||
                        parts[1] == ">" && optimalX > Int32.Parse(parts[2]))
                    {
                        inequalities.Add(line);
                    }
                }
            }
        }

        private static void FindMaxInequalitiesCount(string inputPath, out int maxInequalitiesCount, out int optimalX)
        {
            maxInequalitiesCount = 0;
            optimalX = min;

            for (int i = min; i <= max; i++)
            {
                int currentCounter = 0;

                using (StreamReader sr = File.OpenText(inputPath))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] parts = line.Split(' ');

                        if (parts[1] == "<" && i < Int32.Parse(parts[2]) ||
                            parts[1] == "<=" && i <= Int32.Parse(parts[2]) ||
                            parts[1] == "=" && i == Int32.Parse(parts[2]) ||
                            parts[1] == ">=" && i >= Int32.Parse(parts[2]) ||
                            parts[1] == ">" && i > Int32.Parse(parts[2]))
                        {
                            currentCounter++;
                        }
                    }
                }

                if (currentCounter > maxInequalitiesCount)
                {
                    maxInequalitiesCount = currentCounter;
                    optimalX = i;
                }
            }
        }

        private static void FindRange(string inputPath, out int min, out int max)
        {
            min = Int32.MaxValue;
            max = Int32.MinValue;

            using (StreamReader sr = File.OpenText(inputPath))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] parts = line.Split(' ');

                    if (Int32.Parse(parts[2]) < min)
                    {
                        min = Int32.Parse(parts[2]);
                    }
                    if (Int32.Parse(parts[2]) > max)
                    {
                        max = Int32.Parse(parts[2]);
                    }
                }
            }
        }


    }
}
