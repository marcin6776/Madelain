using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;



namespace Madelain
{
    class madelaine
    {
        DataTable traintab = new DataTable();
        DataTable testtab = new DataTable();
        DataTable letters = new DataTable();

        public void read(DataTable data, string inputFile, int number_col)
        {



            for (int col = 0; col < number_col; col++)
                data.Columns.Add(new DataColumn((col + 1).ToString()));


            string[] lines = System.IO.File.ReadAllLines(inputFile);

            foreach (string line in lines)
            {
                var cols = line.Split(',');

                DataRow dr = data.NewRow();
                for (int cIndex = 0; cIndex < number_col; cIndex++)
                {
                    try
                    {
                        dr[cIndex] = Int32.Parse(cols[cIndex]);
                    }
                    catch
                    {
                        dr[cIndex] = cols[cIndex];
                    }
                }

                data.Rows.Add(dr);
            }
        }

        public void init()
        {

            read(traintab, @"D:\Studia\Informatyka\semestr 2\jpad\learn.txt", 4);
            read(testtab, @"D:\Studia\Informatyka\semestr 2\jpad\test.txt", 4);
            read(letters, @"D:\Studia\Informatyka\semestr 2\jpad\litery.txt", 3);
        }
    
    }
    class Program
    {
        static void Main(string[] args)
        {
            //madelaine decyzja = new madelaine();
            //decyzja.init();
            MadalineNeuron neuron = new MadalineNeuron();
            int[] inn = { 0, 1, 0, 0, 0, 1, 1, 1, 0, 1, 0, 1, 1, 0, 1, 0 };
            int[] innTest = { 0, 1, 1, 0, 0, 1, 1, 1, 0, 1, 0, 0, 1, 0, 0, 0 };
            neuron.learn(inn);
            double outt = neuron.Check(innTest);
            Console.WriteLine(outt);
            Console.ReadLine();
        }
    }
}
