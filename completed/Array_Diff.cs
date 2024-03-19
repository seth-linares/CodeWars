
/*

https://www.codewars.com/kata/523f5d21c841566fde000009/train/csharp

Your goal in this kata is to implement a difference function, which subtracts one list from another and returns the result.

It should remove all values from list a, which are present in list b keeping their order.

Kata.ArrayDiff(new int[] {1, 2}, new int[] {1}) => new int[] {2}

If a value is present in b, all of its occurrences must be removed from the other:

Kata.ArrayDiff(new int[] {1, 2, 2, 2, 3}, new int[] {2}) => new int[] {1, 3}


*/






namespace Code_Problems {
    using System.Collections.Generic;
    using System.Linq;
    public class Array_Diff { //Rename Class for clarity
        public static int[] ArrayDiff(int[] a, int[] b) {
            HashSet<int> bSet = new HashSet<int>(b);
            List<int> c = new List<int>();

            for(int i = 0; i < a.Length; i++) {
                if(!b.Contains(a[i])) { // WE CAN USE .Contains() BECAUSE IMPORTING LINQ UNLOCKS ARRAY MAGIC POWERS!!!
                    c.Add(a[i]);
                }
            }

            return c.ToArray();
        }
    }


    // public class Kata {
    //     public static int[] ArrayDiff(int[] a, int[] b) {
    //         HashSet<int> bSet = new HashSet<int>(b);
    //         List<int> c = new List<int>();

    //         for(int i = 0; i < a.Length; i++) {
    //             if(!bSet.Contains(a[i])) { // HashSet version for time complexity! 🤓
    //                 c.Add(a[i]);
    //             }
    //         }

    //         return c.ToArray();
    //     }
    // }
}