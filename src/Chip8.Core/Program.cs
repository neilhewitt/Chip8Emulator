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
            StringBuilder builder = new StringBuilder();
            foreach (Instruction instruction in Instructions)
            {
                builder.Append(instruction.ToAssembler() + "\n");
            }

            return builder.ToString();
        }

        public Program()
        {
            _instructions = new List<Instruction>();
        }
    }
}
