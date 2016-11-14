using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chip8.Core
{
    public class Program
    {
        private IList<Instruction> _instructions;

        public IEnumerable<Instruction> Instructions => _instructions;

        public void Add(Instruction instruction)
        {
            _instructions.Add(instruction);
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            foreach(Instruction instruction in Instructions)
            {
                builder.Append(instruction.ToString() + "\n");
            }

            return builder.ToString();
        }

        public string ToAssembler()
        {
            int index = 0;
            StringBuilder builder = new StringBuilder();
            foreach (Instruction instruction in Instructions)
            {
                builder.Append(index++.ToString().PadLeft(6, '0') + "\t" + instruction.ToAssembler() + "\t\n");
            }

            return builder.ToString();
        }

        public Program()
        {
            _instructions = new List<Instruction>();
        }
    }
}
