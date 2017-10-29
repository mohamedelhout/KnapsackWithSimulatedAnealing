using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulated_Anealing
{
    struct Cell
    {
        public int profit;
        public int weight;
    }
    class SimulatedAnealing
    {
        double tempratureOfSystem;
        double temprature;
        double coolingRate;
        int capacity;
        int dimension;
        int[] profitArray;
        int[] weightArray;
        int[] solutionArray;
        int[] currentArray;
        Cell bestFitness;
        Cell currentFitness;

        public SimulatedAnealing(double _tempratureOfSystem, double _coolingRate, int _capacity,int _dimension, int[] _profitArray, int[] _weightArray)
        {
            tempratureOfSystem = _tempratureOfSystem;
            temprature = _tempratureOfSystem / 2;
            coolingRate = _coolingRate;
            capacity = _capacity;
            dimension = _dimension;
            profitArray = _profitArray;
            weightArray = _weightArray;
            solutionArray = new int[_dimension];
            currentArray = new int[_dimension];
            bestFitness.profit = bestFitness.weight = 0;
            currentFitness.profit = currentFitness.weight = 0;
        }
        private void CreateRandomSolution()
        {
            Random getRandom = new Random();
            for (int i = 0; i < solutionArray.Length; i++)
            {
                if ((getRandom.NextDouble()) >= 0.5)
                {
                    solutionArray[i] = 1;
                }
                else
                {
                    solutionArray[i] = 0;
                }
            }
        }
        private void FitnessFunction(ref Cell cell ,ref int[] arr)
        {
            cell.profit = 0;
            cell.weight = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if ( arr[i] == 1 )
                {
                    cell.profit += profitArray[i];
                    cell.weight += weightArray[i];
                }
                else { }
            }
        }
        private void AcceptanceSolution(ref int[] arr)
        {
            if ( currentFitness.weight <= capacity)
            {
                if ( currentFitness.profit >= bestFitness.profit )
                {
                    for (int i = 0; i < arr.Length; i++)
                    {
                        solutionArray[i] = arr[i];
                    }
                }
                else
                {
                    Random getRandom = new Random();
                    double acceptanceRate = Math.Exp((bestFitness.profit - currentFitness.profit) / tempratureOfSystem);
                    if ((getRandom.NextDouble()) < acceptanceRate && tempratureOfSystem >= temprature)
                    {
                        for (int i = 0; i < arr.Length; i++)
                        {
                            solutionArray[i] = arr[i];
                        }
                    }
                }
            }
            else { }
        }
        private void Swap_Mutation(ref int[] arr)
        {
            int temp ;
            Random getRandom = new Random();
            int x = getRandom.Next(0, arr.Length - 1);
            int y = getRandom.Next(0, arr.Length - 1);
            temp = arr[x];
            arr[x] = arr[y];
            arr[y] = temp;
        }
        public void Run()
        {
            CreateRandomSolution();
            FitnessFunction(ref bestFitness,ref solutionArray);
            for (int i = 0; i < solutionArray.Length; i++)
            {
                currentArray[i] = solutionArray[i];
            }
            Random getRandom = new Random();
            while(tempratureOfSystem > 1)
            {

                if (getRandom.NextDouble() < 0.5)
                {
                    Swap_Mutation(ref currentArray);
                }
                FitnessFunction(ref currentFitness, ref currentArray);
                AcceptanceSolution(ref currentArray);

                tempratureOfSystem *= (1 - coolingRate);
            }
            Console.Write("The Best items weights : ");
            for(int i = 0; i < solutionArray.Length; i++)
            {
                Console.Write("{0} , ",solutionArray[i]);
            }
            Console.WriteLine();
            Console.WriteLine("Total Weight : {0}", bestFitness.weight);
            Console.WriteLine("Total Profit : {0}", bestFitness.profit);
        }
    }
}
