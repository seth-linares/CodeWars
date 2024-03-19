/*
https://www.codewars.com/kata/59568be9cc15b57637000054/train/csharp

In the nation of CodeWars, there lives an Elder who has lived for a long time. Some people call him the Grandpatriarch, but most people just refer to him as the Elder.

There is a secret to his longetivity: he has a lot of young worshippers, who regularly perform a ritual to ensure that the Elder stays immortal:

    The worshippers line up in a magic rectangle, of dimensions m and n.
    They channel their will to wish for the Elder. In this magic rectangle, any worshipper can donate time equal to the xor of the column and the row (zero-indexed) he's on, in seconds, to the Elder.
    However, not every ritual goes perfectly. The donation of time from the worshippers to the Elder will experience a transmission loss l (in seconds). Also, if a specific worshipper cannot channel more than l seconds, the Elder will not be able to receive this worshipper's donation.

The estimated age of the Elder is so old it's probably bigger than the total number of atoms in the universe. However, the lazy programmers (who made a big news by inventing the Y2K bug and other related things) apparently didn't think thoroughly enough about this, and so their simple date-time system can only record time from 0 to t-1 seconds. If the elder received the total amount of time (in seconds) more than the system can store, it will be wrapped around so that the time would be between the range 0 to t-1.

Given m, n, l and t, please find the number of seconds the Elder has received, represented in the poor programmer's date-time system.

(Note: t will never be bigger than 2^32 - 1, and in JS, 2^26 - 1.)

Example:

m=8, n=5, l=1, t=100

Let's draw out the whole magic rectangle:
0 1 2 3 4 5 6 7
1 0 3 2 5 4 7 6
2 3 0 1 6 7 4 5
3 2 1 0 7 6 5 4
4 5 6 7 0 1 2 3

Applying a transmission loss of 1:
0 0 1 2 3 4 5 6
0 0 2 1 4 3 6 5
1 2 0 0 5 6 3 4
2 1 0 0 6 5 4 3
3 4 5 6 0 0 1 2

Adding up all the time gives 105 seconds.

Because the system can only store time between 0 to 99 seconds, the first 100 seconds of time will be lost, giving the answer of 5.

This is no ordinary magic (the Elder's life is at stake), so you need to care about performance. All test cases (900 tests) can be passed within 1 second, but naive solutions will time out easily. Good luck, and do not displease the Elder.


*/



/*

**Significance behind Math.Max(m, n) % 8.**

0th indexed version*

sum = n * (n - 1)       
      -----------   =   sum from n to 0
           2

ex: given n = 8
    8 * (8 - 1) / 2 = 28; 1 + 2 + 3 + 4 + 5 + 6 + 7 = 28



*/





namespace Code_Problems {
    
    using System;
    public static class Immortal {
        /// set true to enable debug
        public static bool Debug = false;


        public static long ElderAge(long m, long n, long loss, long time) {
            long count = 0;
            long row_sum = 0;


            for(int i = 0; i < Math.Min(m, n); i++) {
                if(i > 0) {
                    Console.WriteLine($"row sum = {row_sum} at row i = {i - 1}, max number = {Math.Max(m, n)}");
                    Console.WriteLine($"row sum (binary) = {Convert.ToString(row_sum, 2)} at row i (binary) = {Convert.ToString(i - 1, 2)}, max number (binary) = {Convert.ToString(Math.Max(m, n), 2)}");
                    Console.WriteLine($"count = {count}, count (binary) = {Convert.ToString(count, 2)}");
                    row_sum = 0;
                    Console.WriteLine();
                }
                

                for(int j = 0; j < Math.Max(m, n); j++) {
                    long value = Math.Max((j ^ i) - loss, 0);
                    count += value;
                    row_sum += value;
                    if(j == Math.Max(m, n) - 1 && i == Math.Min(m, n) - 1) {
                        Console.WriteLine($"row sum = {row_sum} at row i = {i}, max number = {Math.Max(m, n)}");
                        Console.WriteLine($"row sum (binary) = {Convert.ToString(row_sum, 2)} at row i (binary) = {Convert.ToString(i, 2)}, max number (binary) = {Convert.ToString(Math.Max(m, n), 2)}");
                        Console.WriteLine($"count = {count}, count (binary) = {Convert.ToString(count, 2)}");
                    }
                    
                }
            }
            
                
            

            return count < time ? count : count % time; // do it!
        }


        public static int[,] GenerateXorMatrix(int rows, int cols, int loss) {
            int[,] matrix = new int[rows, cols];
            for (int row = 0; row < rows; row++) {
                for (int col = 0; col < cols; col++) {
                    matrix[row, col] = Math.Max((row ^ col) - loss, 0);
                }
            }
            return matrix;
        }

        public static void PrintMatrix(int rows, int cols, int loss, bool binary) {
            int[,] matrix = GenerateXorMatrix(rows, cols, loss);

            int max_width = 0;
            foreach (int num in matrix) {
                max_width = Math.Max(max_width, Convert.ToString(num, 2).Length);
            }

            for (int row = 0; row < rows; row++) {
                for (int col = 0; col < cols; col++) {
                    if(binary) {
                        Console.Write(Convert.ToString(matrix[row, col], 2).PadRight(max_width));
                    }
                    else {
                        Console.Write(Convert.ToString(matrix[row, col]).PadRight(max_width));
                    }
                    
                    if (col < cols - 1) {
                        Console.Write(" | ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}


// public static long ElderAge(long m, long n, long loss, long time) {
//             long count = 0;
//             // long row_sum = 0;
//             long big = Math.Max(n, m);
//             long small = Math.Min(n, m);

//             double power_max = Math.Log2(big);


//             if(Math.Floor(power_max) != power_max) {
//                 Console.WriteLine();
//                 count = (big * (big - 1)) / 2 * small;
//                 Console.WriteLine("RETURNING from __if(Math.Log2(big) == 0)__");
//                 return count < time ? count : count % time;
//             }


//             else {
//                 Console.WriteLine("Loop");
//                 for(int i = 0; i < n; i++) { 
//                     for(int j = 0; j < m; j++) {
//                         count += Math.Max((j ^ i) - loss, 0);
//                     }
//                 }
                
                
//             }

//             return count < time ? count : count % time; // do it!
//         }
