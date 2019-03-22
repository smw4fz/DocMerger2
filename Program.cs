using System;
using System.IO;

namespace DocMerger2
{
    class Program
    {
        static void Main(string[] args)
        {
            string input1 = "";

            if (args.Length < 3)
            {
                Console.WriteLine("DocumentMerger2 <input_file_1> <input_file_2> ... <input_file_n> <output_file > ");
                Console.WriteLine("Supply a list of text files to merge followed by the name of the resulting merged text file as command line arguments.");
            } 

            else
            {
                for (int i=0;i<args.Length-1;i++)
                {

                    string fileName1 = args[i];

                    try
                    {
                        if (File.Exists(fileName1 + ".txt") == false)
                        {
                            Console.WriteLine("Exiting Program");
                            break;
                        }

                        StreamReader sr = new StreamReader($"{fileName1}.txt");

                        string text = sr.ReadLine();
                        input1 = input1 + text;

                        while (text != null)
                        {
                            input1 = input1 + Environment.NewLine;
                            text = sr.ReadLine();
                            input1 = input1 + text;
                        }
                        sr.Close();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("File error!");
                        throw ex; 
                    }
                } // end for loop 

                    try
                    {
                        using (StreamWriter write = new StreamWriter(args[args.Length - 1] + ".txt"))
                        {
                            write.Write(input1);
                        }
                        Console.WriteLine($"{(args[args.Length - 1])} is saved");
                    }

                    catch (Exception e)
                    {
                        using (StreamWriter write = new StreamWriter("exception.txt"))
                        {
                            write.Write(input1);
                        }
                        Console.WriteLine("The file doesn't work. The file is now called excepion.txt");
                        throw e; 
                    }
            } // end else 


            Console.ReadLine();

        } // end main 
    } // end class 
} // end namespace