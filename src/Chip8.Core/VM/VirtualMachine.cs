using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Chip8.Core
{
    public class VirtualMachine
    {
        private bool _running = false;

        public IReadOnlyList<Register> V { get; }
        public Register VF => V[15];
        public short ProgramCounter { get; private set; }
        public byte[] State => V.Select(r => r.Value).ToArray();
        public string CurrentInstructionAsAssembler { get; private set; }

        public event EventHandler<VirtualMachine> BeforeProgramStart;
        public event EventHandler<VirtualMachine> BeforeInstructionExecute;
        public event EventHandler<VirtualMachine> AfterInstructionExecute;
        public event EventHandler<VirtualMachine> Stopped;
        public event EventHandler<VirtualMachine> BeforeProgramEnd;

        public void Run(Program program, int delayAfterEachInstructionInMilliseconds = 0)
        {
            BeforeProgramStart(null, this);
            _running = true;

            while (_running && program.Instructions.Count > ProgramCounter)
            {
                Instruction instruction = program.Instructions[ProgramCounter];
                CurrentInstructionAsAssembler = instruction.ToAssembler();

                BeforeInstructionExecute(null, this);

                ProgramCounter++;
                instruction.Execute(this);
                if (delayAfterEachInstructionInMilliseconds > 0)
                {
                    Thread.Sleep(delayAfterEachInstructionInMilliseconds);
                }

                AfterInstructionExecute(null, this);
            }

            BeforeProgramEnd(null, this);
        }

        public void JumpTo(Address address)
        {
            ProgramCounter = (short)(address.Offset / 2);
        }

        public void SkipNextInstruction()
        {
            ProgramCounter++;
        }

        public void Stop()
        {
            _running = false;
            Stopped(null, this);
        }

        public VirtualMachine()
        {
            List<Register> registers = new List<Register>();
            for (int i = 0; i < 16; i++) registers.Add(new Register());
            V = registers;

            BeforeProgramStart += (sender, e) => { };
            BeforeInstructionExecute += (sender, e) => { };
            AfterInstructionExecute += (sender, e) => { };
            Stopped += (sender, e) => { };
            BeforeProgramEnd += (sender, e) => { };
        }
    }
}
