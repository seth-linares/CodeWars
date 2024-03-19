/*
https://www.codewars.com/kata/58e61f3d8ff24f774400002c/train/csharp

This is the second part of this kata series. First part is here. (https://www.codewars.com/kata/58e24788e24ddee28e000053/train/csharp)

We want to create an interpreter of assembler which will support the following instructions:

    mov x, y - copy y (either an integer or the value of a register) into register x.
    inc x - increase the content of register x by one.
    dec x - decrease the content of register x by one.
    add x, y - add the content of the register x with y (either an integer or the value of a register) and stores the result in x (i.e. register[x] += y).
    sub x, y - subtract y (either an integer or the value of a register) from the register x and stores the result in x (i.e. register[x] -= y).
    mul x, y - same with multiply (i.e. register[x] *= y).
    div x, y - same with integer division (i.e. register[x] /= y).
    label: - define a label position (label = identifier + ":", an identifier being a string that does not match any other command). Jump commands and call are aimed to these labels positions in the program.
    jmp lbl - jumps to the label lbl.
    cmp x, y - compares x (either an integer or the value of a register) and y (either an integer or the value of a register). The result is used in the conditional jumps (jne, je, jge, jg, jle and jl)
    jne lbl - jump to the label lbl if the values of the previous cmp command were not equal.
    je lbl - jump to the label lbl if the values of the previous cmp command were equal.
    jge lbl - jump to the label lbl if x was greater or equal than y in the previous cmp command.
    jg lbl - jump to the label lbl if x was greater than y in the previous cmp command.
    jle lbl - jump to the label lbl if x was less or equal than y in the previous cmp command.
    jl lbl - jump to the label lbl if x was less than y in the previous cmp command.
    call lbl - call to the subroutine identified by lbl. When a ret is found in a subroutine, the instruction pointer should return to the instruction next to this call command.
    ret - when a ret is found in a subroutine, the instruction pointer should return to the instruction that called the current function.
    msg 'Register: ', x - this instruction stores the output of the program. It may contain text strings (delimited by single quotes) and registers. The number of arguments isn't limited and will vary, depending on the program.
    end - this instruction indicates that the program ends correctly, so the stored output is returned (if the program terminates without this instruction it should return the default output: see below).
    ; comment - comments should not be taken in consideration during the execution of the program.


Output format:

The normal output format is a string (returned with the end command). For Scala and Rust programming languages it should be incapsulated into Option.

If the program does finish itself without using an end instruction, the default return value is:

null


Input format:

The function/method will take as input a multiline string of instructions, delimited with EOL characters. Please, note that the instructions may also have indentation for readability purposes.

For example:

program = "\n; My first program\nmov  a, 5\ninc  a\ncall function\nmsg  '(5+1)/2 = ', a    ; output message\nend\n\nfunction:\n    div  a, 2\n    ret\n"
AssemblerInterpreter.Interpret(program);

// Which is equivalent to (keep in mind that empty lines are not displayed in the console on CW, so you actually won't see the separation before "function:"...):

; My first program
mov  a, 5
inc  a
call function
msg  '(5+1)/2 = ', a    ; output message
end

function:
    div  a, 2
    ret

The above code would set register a to 5, increase its value by 1, calls the subroutine function, divide its value by 2, returns to the first call instruction, prepares the output of the program and then returns it with the end instruction. In this case, the output would be (5+1)/2 = 3.

*/

namespace Code_Problems {
    using System;
    using System.Text.RegularExpressions;
    using System.Collections.Generic;
    using System.Linq;

    public class AssemblerInterpreter {
        public static string? Interpret(string input) {
            Stack<int> calls = new Stack<int>(); // stack of locations of function calls
            List<string> valid_code = new List<string>();
            Dictionary<string, int> registers = new Dictionary<string, int>();
            int? last_cmp = null;
            string? message = null;
            



            string[] parts = input.Split("\n");
            
            
            for(int i = 0; i < parts.Length; i++) {
                string tempPlaceholder = "__COMMA__";
                string result = Regex.Replace(parts[i], @"'[^']*'", m => m.Value.Replace(",", tempPlaceholder)).Replace(",", " ").Replace(tempPlaceholder, ",");


                result = Regex.Replace(result, @";.*$|\s{2,}", " ").Trim();

                if(result == "" || result == " ") continue;

                valid_code.Add(result);

                string[] filtered_parts = Regex.Split(result, @" (?=(?:[^']*'[^']*')*[^']*$)").Select(s => s.Trim().Replace("'", "")).ToArray();

                for(int j = 0; j < filtered_parts.Length; j++) {

                    if(!registers.ContainsKey(filtered_parts[j]) && filtered_parts[j].All(char.IsLetter) && filtered_parts[j].Length == 1) {
                        registers.Add(filtered_parts[j], 0);
                    }

                }
            }
            

            Dictionary<string, int> labels = valid_code // I hate vertical LINQ, but in cases like this, it's unreadable without it. 
                .Select((string element, int index) => new {element, index}) // elements and indices are inherent to collections, need to use new {} to preserve it for following steps
                .Where(t => t.element.EndsWith(":"))
                .Select(t => (t.element, t.index))
                .ToDictionary(t => t.element.Substring(0, t.element.Length - 1), t => t.index);




            for(int i = 0; i < valid_code.Count; i++) {
                int num;
                string[] filtered_parts = Regex.Split(valid_code[i], @" (?=(?:[^']*'[^']*')*[^']*$)").Select(s => s.Trim().Replace("'", "")).ToArray();
                switch (filtered_parts[0]) {
                    case "mov":
                        registers[filtered_parts[1]] = int.TryParse(filtered_parts[2], out num) ? num : registers[filtered_parts[2]];
                        break;
                    case "inc":
                        registers[filtered_parts[1]]++;
                        break;
                    case "dec":
                        registers[filtered_parts[1]]--;
                        break;
                    case "add":
                        registers[filtered_parts[1]] += int.TryParse(filtered_parts[2], out num) ? num : registers[filtered_parts[2]];
                        break;
                    case "sub":
                        registers[filtered_parts[1]] -= int.TryParse(filtered_parts[2], out num) ? num : registers[filtered_parts[2]];
                        break;
                    case "mul":
                        registers[filtered_parts[1]] *= int.TryParse(filtered_parts[2], out num) ? num : registers[filtered_parts[2]];
                        break;
                    case "div":
                        registers[filtered_parts[1]] /= int.TryParse(filtered_parts[2], out num) ? num : registers[filtered_parts[2]];
                        break;
                    case "jmp":
                        i = labels[filtered_parts[1]];
                        break;
                    case "cmp":
                        int x = int.TryParse(filtered_parts[1], out num) ? num : registers[filtered_parts[1]];
                        int y = int.TryParse(filtered_parts[2], out int num_2) ? num_2 : registers[filtered_parts[2]];
                        last_cmp = x.CompareTo(y);
                        break;
                    case "jne":
                        if(last_cmp is null) return null;
                        else if(last_cmp != 0) i = labels[filtered_parts[1]]; 
                        break;
                    case "je":
                        if(last_cmp is null) return null;
                        else if(last_cmp == 0) i = labels[filtered_parts[1]]; 
                        break;
                    case "jge":
                        if(last_cmp is null) return null;
                        else if(last_cmp >= 0) i = labels[filtered_parts[1]];
                        break;
                    case "jg":
                        if(last_cmp is null) return null;
                        else if(last_cmp > 0) i = labels[filtered_parts[1]];
                        break;
                    case "jle":
                        if(last_cmp is null) return null;
                        else if(last_cmp <= 0) i = labels[filtered_parts[1]];
                        break;
                    case "jl":
                        if(last_cmp is null) return null;
                        else if(last_cmp < 0) i = labels[filtered_parts[1]];
                        break;
                    case "call":
                        calls.Push(i);
                        i = labels[filtered_parts[1]];
                        break;
                    case "ret":
                        i = calls.Pop();
                        if(i + 1 == valid_code.Count) return null;
                        break;
                    case "msg":
                        for(int l = 1; l < filtered_parts.Length; l++) { // since there r unknown # elements, loop through all elements in the array
                            if(registers.ContainsKey(filtered_parts[l])) message += registers[filtered_parts[l]];
                            else message += filtered_parts[l];
                        }

                        break;
                    case "end":
                        return message;
                    default:
                        break;
                }

            }

            return null;
        }
    }
}