/*
https://www.codewars.com/kata/54bf1c2cd5b56cc47f0007a1/train/csharp

Count the number of Duplicates

Write a function that will return the count of distinct case-insensitive alphabetic characters and numeric digits that occur more than once in the input string. The input string can be assumed to contain only alphabets (both uppercase and lowercase) and numeric digits.
Example

"abcde" -> 0 # no characters repeats more than once
"aabbcde" -> 2 # 'a' and 'b'
"aabBcde" -> 2 # 'a' occurs twice and 'b' twice (`b` and `B`)
"indivisibility" -> 1 # 'i' occurs six times
"Indivisibilities" -> 2 # 'i' occurs seven times and 's' occurs twice
"aA11" -> 2 # 'a' and '1'
"ABBA" -> 2 # 'A' and 'B' each occur twice


*/





namespace Code_Problems {
    using System;
    using System.Linq;
    using System.Collections.Generic;
    public class Counting_Duplicates {
        public static int DuplicateCount(string str) {
            if(str.Length == 0) {
                return 0;
            }

            int count = 0;

            String lower = str.ToLower();

            List<char> real_string = lower.Distinct().ToList();

            for(int i = 0; i < real_string.Count; i++) {
                if(lower.IndexOf(real_string[i]) != lower.LastIndexOf(real_string[i])) {
                    count++;
                }
            }

            return count;
        }
    }
}