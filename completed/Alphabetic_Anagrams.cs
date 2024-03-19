/*
https://www.codewars.com/kata/53e57dada0cb0400ba000688


Consider a "word" as any sequence of capital letters A-Z (not limited to just "dictionary words"). For any word with at least two different letters, there are other words composed of the same letters but in a different order (for instance, STATIONARILY/ANTIROYALIST, which happen to both be dictionary words; for our purposes "AAIILNORSTTY" is also a "word" composed of the same letters as these two).

We can then assign a number to every word, based on where it falls in an alphabetically sorted list of all words made up of the same group of letters. One way to do this would be to generate the entire list of words and find the desired one, but this would be slow if the word is long.

Given a word, return its number. Your function should be able to accept any word 25 letters or less in length (possibly with some letters repeated), and take no more than 500 milliseconds to run. To compare, when the solution code runs the 27 test cases in JS, it takes 101ms.

For very large words, you'll run into number precision issues in JS (if the word's position is greater than 2^53). For the JS tests with large positions, there's some leeway (.000000001%). If you feel like you're getting it right for the smaller ranks, and only failing by rounding on the larger, submit a couple more times and see if it takes.

Python, Java and Haskell have arbitrary integer precision, so you must be precise in those languages (unless someone corrects me).

C# is using a long, which may not have the best precision, but the tests are locked so we can't change it.

Sample words, with their rank:
ABAB = 2
AAAB = 1
BAAA = 4
QUESTION = 24572
BOOKKEEPER = 10743
MUCHOCOMBINATIONS = 1938852339039
HAXPBVLWI = 85336
*/






namespace Code_Problems {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    

    public class Alphabetic_Anagrams {


        public static long ListPosition(string value) {
        
            Dictionary<char, int> occurrences = value.GroupBy(c => c).ToDictionary(c => c.Key, num => num.Count());

            long rank = 1;
            int length = value.Length;
            long factorial = Factorial(length);

            foreach(char c in value) {
                factorial /= length;
                length--;

                foreach(KeyValuePair<char, int> pair in occurrences) {
                
                    if (pair.Key < c) {
                        rank += pair.Value * factorial / Factorial(occurrences);
                    }
                }

                occurrences[c]--;
                if (occurrences[c] == 0) 
                occurrences.Remove(c);
            }

            return rank;
        }

        private static long Factorial(int n) {
            long result = 1;
            for (int i = 2; i <= n; i++)
                result *= i;
            return result;
        }

        private static long Factorial(Dictionary<char, int> occurrences) {
            long result = 1;
            foreach (var pair in occurrences)
                result *= Factorial(pair.Value);
            return result;
        }

    }    
}