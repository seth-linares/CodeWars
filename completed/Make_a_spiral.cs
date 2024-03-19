/*
https://www.codewars.com/kata/534e01fbbb17187c7e0000c6/train/csharp

Your task, is to create a NxN spiral with a given size.

For example, spiral with size 5 should look like this:

00000
....0
0...0
0...0
00000

and with the size 10:

0000000000
.........0
0........0
0........0
0........0
0........0
0........0
0........0
0........0
0000000000

Return value should contain array of arrays, of 0 and 1, with the first row being composed of 1s. For example for given size 5 result should be:

[[1,1,1,1,1],[0,0,0,0,1],[1,1,1,0,1],[1,0,0,0,1],[1,1,1,1,1]]

Because of the edge-cases for tiny spirals, the size will be at least 5.

General rule-of-a-thumb is, that the snake made with '1' cannot touch to itself.


*/

namespace Code_Problems {
    using System;
    public class Spiralizor {
        public static int[,] Spiralize(int size) {
            // Happy coding...
            int[,] actual = new int[size,size];
            int rows = actual.GetLength(0);
            int cols = actual.GetLength(1);
            int i = 0;
            int j = 0;

            
            

            for(int iter = 0; iter < size / 2; iter++) {
                while(j + 1 < cols) {
                    if((j + 1 < cols) && (i + 1 < rows)) {
                        if(actual[i + 1, j + 1] == 1) {
                            return actual;
                        }
                    }
                    
                    if(j + 2 < cols) {
                        if(actual[i, j + 2] == 1) {
                            actual[i, j] = 1;
                            break;
                        }
                    }
                    actual[i, j] = 1;
                    j++;
                }

                while(i + 1 < rows) {
                    
                    if(i + 2 < rows) {
                        if(actual[i + 2, j] == 1) {
                            actual[i, j] = 1;
                            break;
                        }
                    }

                    actual[i, j] = 1;
                    i++;
                }

                while(j - 1 >= 0) {
                    if((j - 1 >= 0) && (i - 1 >= 0)) {
                        if(actual[i - 1, j - 1] == 1) {
                            return actual;
                        }
                    }
                    
                    if(j - 2 >= 0) {
                        if(actual[i, j - 2] == 1) {
                            actual[i, j] = 1;
                            break;
                        }
                    }
                    actual[i, j] = 1;
                    j--;
                }

                while(i - 1 >= 0) {                    
                    if(i - 2 >= 0) {
                        if(actual[i - 2, j] == 1) {
                            actual[i, j] = 1;
                            break;
                        }
                    }
                    actual[i, j] = 1;
                    i--;
                }

                
            }

            return actual;            
        }
    }
}