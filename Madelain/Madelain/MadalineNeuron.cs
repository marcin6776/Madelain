using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Madelain
{
    class MadalineNeuron
    {
        double[] Weights= new double[16];
        double neuron_output;

        public double norm( int[]input)
        {
            //obliczanie ilosci jedynek
            int ImputSum = 0;
            foreach (int value in input)
            {
                ImputSum = ImputSum + value;
            }
            // wartosc wagi dla jedynek
            double toWeight = 1 / Math.Sqrt(ImputSum);
            return toWeight;
        }
        public void learn(int[] input)
        {
            double Weight = norm(input);
           
            //przypisanie wagi jedynkom
            for(int i=0; i < 16; i++)
            {
                if (input[i] == 1)
                {
                    Weights[i] = Weight;
                }
            }



        }
        public double Check(int[] testimput)
        {
            neuron_output = 0;
            // konwersja z tablicy z inta na double
            double[] TestImput2 = new double[16];
            for (int i = 0; i < testimput.Length; i++)
            {
                TestImput2[i] = Convert.ToDouble(testimput[i]);
            }
            double WeightsTest = norm(testimput);
            //normalizacja danych wejsciowych
            for(int i = 0; i < 16; i++)
            {
                if (testimput[i] == 1)
                {
                   TestImput2[i] = WeightsTest;
                }
            }
            //sumowanie wyjscia
            for(int i=0;i<16; i++)
            {
                neuron_output = neuron_output + Weights[i] * TestImput2[i];
            }

            return neuron_output;
        }


    }
}
