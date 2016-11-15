using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chip8.Core
{
    public abstract class Instruction
    {
        public virtual char Prefix => '0';

        public abstract void Execute(VirtualMachine vm);

        public override string ToString()
        {
            return "0000";
        }

        public virtual string ToAssembler()
        {
            return "END";
        }

        public Instruction()
        {

        }
    }
}
