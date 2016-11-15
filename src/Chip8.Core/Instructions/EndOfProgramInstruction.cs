﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chip8.Core
{
    public class EndOfProgramInstruction : Instruction
    {
        public override void Execute(VirtualMachine vm)
        {
            vm.Stop();
        }
    }
}
