/*

https://www.codewars.com/kata/54ff3102c1bad923760001f3/train/csharp

Return the number (count) of vowels in the given string.

We will consider a, e, i, o, u as vowels for this Kata (but not y).

The input string will only consist of lower case letters and/or spaces.



*/

namespace Code_Problems {
    using System;
    using System.Collections.Generic;

    public static class Kata {
        public static int GetVowelCount(string str) {
            int vowelCount = 0;
            HashSet<char> vowels = new HashSet<char>() {'a', 'e', 'i', 'o', 'u'};

            foreach(char c in str) {
                if(vowels.Contains(c)) {
                    vowelCount++;
                }
            }

            return vowelCount;
        }
    }
    
}