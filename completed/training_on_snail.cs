/*
https://www.codewars.com/kata/521c2db8ddc89b9b7a0000c1/train/csharp
Given an n x n array, return the array elements arranged from outermost elements to the middle element, traveling clockwise.

array = [[1,2,3],
         [4,5,6],
         [7,8,9]]
snail(array) #=> [1,2,3,6,9,8,7,4,5]

For better understanding, please follow the numbers of the next array consecutively:

array = [[1,2,3],
         [8,9,4],
         [7,6,5]]
snail(array) #=> [1,2,3,4,5,6,7,8,9]


NOTE: The idea is not sort the elements from the lowest value to the highest; the idea is to traverse the 2-d array in a clockwise snailshell pattern.

NOTE 2: The 0x0 (empty matrix) is represented as en empty array inside an array [[]].
*/

namespace Code_Problems {
    using System.Collections.Generic;
    public class SnailSolution {
        public static int[] Snail(int[][] array) {
            if(array[0].Length == 0) 
                return new int[0];
                
            else if(array[0].Length == 1)
                return new int[1]{array[0][0]};

            List<int> result = new List<int>();
            int top = 0, bottom = array.Length - 1, left = 0, right = array[0].Length - 1;

            while (top <= bottom && left <= right) {
                for (int j = left; j <= right; j++) {
                    result.Add(array[top][j]);  
                }

                top++;

                for (int i = top; i <= bottom; i++) {
                    result.Add(array[i][right]);
                }
                right--;

                
                for (int j = right; j >= left; j--) {
                    result.Add(array[bottom][j]);
                }

                bottom--;
                

                
                for (int i = bottom; i >= top; i--) {
                    result.Add(array[i][left]);
                }
                
                left++;
                
            }

            return result.ToArray();
        }
    }   
}