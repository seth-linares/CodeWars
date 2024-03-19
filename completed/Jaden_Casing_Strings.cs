/*
https://www.codewars.com/kata/5390bac347d09b7da40006f6/train/csharp

Jaden Smith, the son of Will Smith, is the star of films such as The Karate Kid (2010) and After Earth (2013). Jaden is also known for some of his philosophy that he delivers via Twitter. When writing on Twitter, he is known for almost always capitalizing every word. For simplicity, you'll have to capitalize each word, check out how contractions are expected to be in the example below.

Your task is to convert strings to how they would be written by Jaden Smith. The strings are actual quotes from Jaden Smith, but they are not capitalized in the same way he originally typed them.

Example:

Not Jaden-Cased: "How can mirrors be real if our eyes aren't real"
Jaden-Cased:     "How Can Mirrors Be Real If Our Eyes Aren't Real"

Link to Jaden's former Twitter account @officialjaden via archive.org


*/


namespace Code_Problems {
    using System;

    public static class JadenCase
    {
    public static string ToJadenCase(this string phrase) {
                if(phrase.Length < 1) {
                    return phrase;
                }
                
                
                char[] newString = phrase.ToCharArray();



                for(int i = 0; i < newString.Length; i++) {
                    if(i == 0 && !newString[i].Equals(' ')) {
                        newString[i] = Char.ToUpper(newString[i]);
                    } 

                    else {
                        if(i - 1 > 0) {
                            if(!newString[i].Equals(' ') && newString[i - 1].Equals(' ')) {
                                newString[i] = Char.ToUpper(newString[i]);
                            }
                        }
                    }
                }
                return new string(newString);
            }
    }
}