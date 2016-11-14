using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Chip8.Core
{
    public class Compiler
    {
        public void Compile(Program program, string outputPath)
        {
            byte[] code = Compile(program);
            File.WriteAllBytes(outputPath, code);
        }

        public byte[] Compile(Program program)
        {
            List<byte> bytes = new List<byte>();

            foreach(Instruction instruction in program.Instructions)
            {
                string instructionCode = instruction.ToString();
                bytes.Add(byte.Parse(instructionCode.Substring(0, 2), System.Globalization.NumberStyles.HexNumber));
                bytes.Add(byte.Parse(instructionCode.Substring(2, 2), System.Globalization.NumberStyles.HexNumber));
            }

            if (!(program.Instructions.Last() is EndOfProgramInstruction))
            {
                bytes.Add(0);
                bytes.Add(0);
            }

            return bytes.ToArray();
        }

        public Compiler()
        {
        }
    }
}
