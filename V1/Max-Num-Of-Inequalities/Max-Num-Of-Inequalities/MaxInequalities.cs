using System;
using System.Collections.Generic;
using System.IO;

namespace Max_Num_Of_Inequalities
{
    public class MaxInequalities
    {
        static void Main(string[] args)
        {
            //Input
            //string path = @"C:\Users\petya.ko\Desktop\Max-Num-Of-Inequalities\Max-Num-Of-Inequalities\inequalities.in.txt";

            //string inputPath = @"C:\Users\PePsi\Desktop\Max-Num-Of-Inequalities\Max-Num-Of-Inequalities\inequalities.in.txt";
            //string outputPath = @"C:\Users\PePsi\Desktop\Max-Num-Of-Inequalities\Max-Num-Of-Inequalities\inequalities.out.txt";

            Console.WriteLine("Please enter the path to the inequalities.in.txt");
            Console.WriteLine("Example => C:\\Users\\petya.ko\\Desktop\\Max-Num-Of-Inequalities\\Max-Num-Of-Inequalities\\inequalities.in.txt");
            string inputPath = Console.ReadLine();
            string outputPath = inputPath.Replace("inequalities.in.txt", "inequalities.out.txt");

            //Find range
            int min = Int32.MaxValue;
            int max = Int32.MinValue;
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

            //Find max inequalities count
            int maxInequalitiesCount = 0;
            int optimalX = min;
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
            
            //Find sets of inequalities
            List<string> inequalities = new List<string>();
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

            //Output

            //Clearing content of inequalities.out.txt file
            File.WriteAllText(outputPath, String.Empty);
            //File.Create(outputPath).Close();            

            //Add maxInequalitiesCount to the collection of inequalities for the inequalities.out.txt
            inequalities.Insert(0, maxInequalitiesCount.ToString());
            //Write output in inequalities.out.txt
            File.WriteAllLines(outputPath, inequalities);
            //public static void WriteAllLines(string path, IEnumerable<string> contents);

            //Print output on the console
            foreach (var inequality in inequalities)
            {
                Console.WriteLine(inequality);
            }
        }


    }
}
