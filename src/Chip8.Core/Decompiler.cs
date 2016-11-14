using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Chip8.Core
{
    public class Decompiler
    {
        public Program Decompile(string pathToBinFile)
        {
            return Decompile(File.ReadAllBytes(pathToBinFile));
        }

        public Program Decompile(byte[] code)
        {
            Program program = new Program();
            for(int index = 0; index < code.Length; index += 2)
            {
                byte first = code[index];
                byte second = code[index + 1];

                string firstHex = Convert.ToString(first, 16).ToUpper().PadLeft(2, '0');
                string secondHex = Convert.ToString(second, 16).ToUpper().PadLeft(2, '0');
                char register1 = firstHex[1];
                char register2 = secondHex[0];

                switch (firstHex[0])
                {
                    case '0':
                        program.Add(new EndOfProgramInstruction());
                        break;
                    case '1':
                        program.Add(new JumpInstruction(new Address(firstHex[1] + secondHex)));
                        break;
                    case '3':
                        program.Add(new SkipIfInstruction(register1, second));
                        break;
                    case '6':
                        program.Add(new AssignInstruction(register1, second));
                        break;
                    case '7':
                        program.Add(new AddInstruction(register1, second));
                        break;
                    case '8':
                        program.Add(new BitOperationInstruction(register1, register2, secondHex[1]));
                        break;
                    case 'C':
                        program.Add(new RandomAndInstruction(register1, second));
                        break;
                }
            }

            return program;
        }
    }
}
