/*

https://www.codewars.com/kata/51c8e37cee245da6b40000bd/train/csharp

Complete the solution so that it strips all text that follows any of a set of comment markers passed in. Any whitespace at the end of the line should also be stripped out.

Example:

Given an input string of:

apples, pears # and bananas
grapes
bananas !apples

The output expected would be:

apples, pears
grapes
bananas

The code would be called like so:

string stripped = StripCommentsSolution.StripComments("apples, pears # and bananas\ngrapes\nbananas !apples", new [] { "#", "!" })
// result should == "apples, pears\ngrapes\nbananas"


*/

namespace Code_Problems {
    using System.Linq;
    using System.Text.RegularExpressions;
    using System.Collections.Generic;
    public class StripCommentsSolution {
        public static string StripComments(string text, string[] commentSymbols) {
            string output = "";
            var parser = search(text, commentSymbols);

            foreach(var character in parser) {
                if(character == '\n' && output.EndsWith(' ')) {
                    output = output.Substring(0, output.Length - 1);
                }
                

                output += character;
            }
                
            
            return output.TrimEnd(' ');
        }

        private static IEnumerable<char> search(string input, string[] commentSymbols) {
            bool valid_output = true;

            for(int i = 0; i < input.Length; i++) {                  
                    if(commentSymbols.Contains(input[i].ToString())) {
                        valid_output = false;
                    }
                    else if(input[i] == '\n' && !valid_output) {
                        valid_output = true;
                    }

            
                if(valid_output) {
                    yield return input[i];
                } 

            }
        }
    }

}