/*
https://www.codewars.com/kata/526156943dfe7ce06200063e/train/csharp

Inspired from real-world Brainf**k, we want to create an interpreter of that language which will support the following instructions:

    > increment the data pointer (to point to the next cell to the right).
    < decrement the data pointer (to point to the next cell to the left).
    + increment (increase by one, truncate overflow: 255 + 1 = 0) the byte at the data pointer.
    - decrement (decrease by one, treat as unsigned byte: 0 - 1 = 255 ) the byte at the data pointer.
    . output the byte at the data pointer.
    , accept one byte of input, storing its value in the byte at the data pointer.
    [ if the byte at the data pointer is zero, then instead of moving the instruction pointer forward to the next command, jump it forward to the command after the matching ] command.
    ] if the byte at the data pointer is nonzero, then instead of moving the instruction pointer forward to the next command, jump it back to the command after the matching [ command.

The function will take in input...

    the program code, a string with the sequence of machine instructions,
    the program input, a string, possibly empty, that will be interpreted as an array of bytes using each character's ASCII code and will be consumed by the , instruction

... and will return ...

    the output of the interpreted code (always as a string), produced by the . instruction.

Implementation-specific details for this Kata:

    Your memory tape should be large enough - the original implementation had 30,000 cells but a few thousand should suffice for this Kata
    Each cell should hold an unsigned byte with wrapping behavior (i.e. 255 + 1 = 0, 0 - 1 = 255), initialized to 0
    The memory pointer should initially point to a cell in the tape with a sufficient number (e.g. a few thousand or more) of cells to its right. For convenience, you may want to have it point to the leftmost cell initially
    You may assume that the , command will never be invoked when the input stream is exhausted
    Error-handling, e.g. unmatched square brackets and/or memory pointer going past the leftmost cell is not required in this Kata. If you see test cases that require you to perform error-handling then please open an Issue in the Discourse for this Kata (don't forget to state which programming language you are attempting this Kata in).



*/



namespace Code_Problems {
    using System.Collections.Generic;
    public static class BrainDuck {
        public static string BrainLuck(string code, string input) {
            byte[] str_bytes = new byte[input.Length];

            for(int p = 0; p < input.Length; p++) {
                str_bytes[p] = (byte)input[p];
            }

            List<byte>byte_list = new List<byte>(){0};

            Dictionary<int, int> index_L = new Dictionary<int, int>();
            Stack<int> indices = new Stack<int>();


            for(int f = 0; f < code.Length; f++) {
                switch(code[f]) {
                    case '[':
                        indices.Push(f);
                        break;
                    case ']':
                        indices.TryPop(out int last_L);
                        index_L.Add(last_L, f);
                        index_L.Add(f, last_L);
                        break;
                }
                
            }

        
            string output = "";

            int i = 0; // command
            int j = 0; // byte array
            int k = 0; // input string


            while(i < code.Length && k <= input.Length) {
                switch(code[i]) {
                    case '>':
                        
                        i++;
                        if(byte_list.Count < j + 2) {
                            byte_list.Add(0);
                            j++;
                            
                            break;
                        }

                        j++;
                        
                        break; 

                    case '<':
                        i++;
                        j--;
                        break;


                    case '+':
                        byte_list[j]++;

                        i++;
                        
                        break;

                    case '-':
                        byte_list[j]--;
                        i++;
                        
                        break;

                    case '.':
                        output += ((char)byte_list[j]).ToString();
                        i++;
                        
                        
                        break;
                        
                    case ',':
                        byte_list[j] = str_bytes[k];
                        k++;

                        i++;

                        break;

                    case '[':
                        if(byte_list[j] == 0) {
                            i = index_L[i] + 1;
                            
                            break;
                        }

                        i++;

                        break;
                        
                    case ']':
                        if(byte_list[j] != 0) {
                            i = index_L[i] + 1;
                            
                            break;
                        }

                        i++;
                        
                        break;

                }
            }
            return output;
        }
    }
}

