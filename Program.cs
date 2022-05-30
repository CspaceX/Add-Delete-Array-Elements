using System;

namespace AddElements
{
    class Program
    {
        static void First(ref int[] MyArray, int lenght)
        {
            int[] FirstIndex = new int[lenght + 1];
            Console.WriteLine("Enter value of first index");
            FirstIndex[0] = int.Parse(Console.ReadLine());
            for (int i = 1; i < FirstIndex.Length; i++)
            {
                FirstIndex[i] = MyArray[i - 1];
            }
            MyArray = FirstIndex;
        }
        static void Last (ref int[] MyArray, int lenght)
            {
            int[] LastIndex = new int[lenght + 1];
            Console.WriteLine("Enter value of last index");
            LastIndex[(LastIndex.Length - 1)] = int.Parse(Console.ReadLine());
            for (int i = 0; i < (LastIndex.Length - 1); i++)
            {
                LastIndex[i] = MyArray[i];
            }
            MyArray = LastIndex;
        }
        static void IndexPlus(ref int[] MyArray, int index, int indexValue)
        {
            int[] NewArray = new int[MyArray.Length + 1];           
            NewArray[index] = indexValue;
            for (int i = 0; i < index; i++)                     
                NewArray[i] = MyArray[i];            
            for (int i = (index + 1); i < NewArray.Length; i++)            
                NewArray[i] = MyArray[i - 1];           
            MyArray = NewArray;
        }

        static void IndexMinus(ref int[] MyArray, int index)
        {
            int[] NewArray = new int[MyArray.Length - 1];
            for (int i = 0; i < index; i++)
                NewArray[i] = MyArray[i];
            for (int i = index; i < NewArray.Length; i++)
                NewArray[i] = MyArray[i + 1];
            MyArray = NewArray;                        
        }

        static void Main(string[] args)
        {
            while (true)
            {
                Random random = new Random();
                int[] MyArray = new int[]{random.Next(100), random.Next(100), random.Next(100), random.Next(100)};                
                for (int i = 0; i < MyArray.Length; i++)
                {
                    Console.Write($"{MyArray[i]}\t");
                }
                Console.WriteLine();
                Console.WriteLine("Choose changing: add First [f] index, add Last [l] index or Add[a]/Delete[d] specific index");
                string Value = Console.ReadLine();
                switch (Value)
                {
                    case "f":
                        First(ref MyArray, MyArray.Length);
                        break;                  
                    case "l":
                        Last(ref MyArray, MyArray.Length);
                        break;                    
                    case "a":                        
                        Console.WriteLine("Choose index [] (from 0 to 4)");
                        int IndexPlusNumber = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter value of index");
                        int ValuePlus = int.Parse(Console.ReadLine());
                        IndexPlus(ref MyArray, IndexPlusNumber, ValuePlus);                        
                        break;
                    case "d":
                        Console.WriteLine("Choose index [] (from 0 to 3)");
                        int IndexMinusNumber = int.Parse(Console.ReadLine());                       
                        IndexMinus(ref MyArray, IndexMinusNumber);
                        break;
                    default:
                        Console.WriteLine("Incorrect data");
                        break;
                }
                Console.WriteLine("New array:");
                for (int i = 0; i < MyArray.Length; i++)
                {
                    Console.Write($"{MyArray[i]}\t");
                }
                Console.ReadLine();
                Console.Clear();
            }
        }
    }
}
