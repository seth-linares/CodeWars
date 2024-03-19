/*
https://www.codewars.com/kata/58e24788e24ddee28e000053/train/csharp

This is the first part of this kata series. Second part is here. (https://www.codewars.com/kata/58e61f3d8ff24f774400002c/train/csharp)

We want to create a simple interpreter of assembler which will support the following instructions:

    mov x y - copies y (either a constant value or the content of a register) into register x
    inc x - increases the content of the register x by one
    dec x - decreases the content of the register x by one
    jnz x y - jumps to an instruction y steps away (positive means forward, negative means backward, y can be a register or a constant), but only if x (a constant or a register) is not zero

Register names are alphabetical (letters only). Constants are always integers (positive or negative).

Note: the jnz instruction moves relative to itself. For example, an offset of -1 would continue at the previous instruction, while an offset of 2 would skip over the next instruction.

The function will take an input list with the sequence of the program instructions and will execute them. The program ends when there are no more instructions to execute, then it returns a dictionary (a table in COBOL) with the contents of the registers.

Also, every inc/dec/jnz on a register will always be preceeded by a mov on the register first, so you don't need to worry about uninitialized registers.
Example

["mov a 5"; "inc a"; "dec a"; "dec a"; "jnz a -1"; "inc a"]

visualized:

mov a 5
inc a
dec a
dec a
jnz a -1
inc a

The above code will:

    set register a to 5,
    increase its value by 1,
    decrease its value by 2,
    then decrease its value until it is zero (jnz a -1 jumps to the previous instruction if a is not zero)
    and then increase its value by 1, leaving register a at 1

So, the function should return:

new Dictionary<string, int> { { "a" , 1 } };

This kata is based on the Advent of Code 2016 - day 12


*/

namespace Code_Problems {
    using System;
    using System.Linq;
    using System.Collections.Generic;
    public static class SimpleAssembler {
        public static Dictionary<string, int> Interpret(string[] program) {
            // TODO: Write a Simple Assembler :)
            var dict = new Dictionary<string, int>();
            int val_1 = 0;
            int val_2 = 0;

            for(int i = 0; i < program.Length; i++) {
                jump: 
                    string[] operations = program[i].Split(" ");
                    
                    
                    for(int j = 1; j < operations.Length; j++) {
                        if(!dict.ContainsKey(operations[j]) && operations[j].All(char.IsLetter)) {
                            dict.Add(operations[j], 0);
                        }

                        
                    }
                    

                    if(operations[0] == "jnz") {
                        val_1 = int.TryParse(operations[1], out val_1) ? val_1 : val_1 = dict[operations[1]];
                        val_2 = int.TryParse(operations[2], out val_2) ? val_2 : val_2 = dict[operations[2]];
                    }
                    

                    switch(operations[0]) {
                        case "mov":
                            int num = int.TryParse(operations[2], out num) ? dict[operations[1]] = num : dict[operations[1]] = dict[operations[2]];
                            break;
                        case "inc":
                            dict[operations[1]]++;
                            break;
                        case "dec":
                            dict[operations[1]]--;
                            break;
                        case "jnz":
                            if(val_1 != 0) {
                                if(i + val_2 < program.Length && i + val_2 >= 0) {
                                    i+= val_2;
                                    goto jump;
                                }
                                else {
                                    return dict;
                                }
                            }

                            break;
                    } // switch statment 
            
                
            } // outer for loop
            return dict;
        } // method
    }
}
