using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chip8.Core
{
    public class JumpInstruction : Instruction
    {
        public override char Prefix => '1';
        public Address Address { get; }

        public JumpInstruction(Address address)
        {
            Address = address;
        }
    }
}
