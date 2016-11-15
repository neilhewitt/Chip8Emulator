using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chip8.Core;
using System.IO;
using System.Threading;

namespace Chip8.Tests
{
    public class Program
    {
        private static byte[] _lastValues;
        private static string[] _source;

        public static void Main(string[] args)
        {
            Console.Clear();

            Console.WriteLine("Press any key to load program...");
            Console.ReadKey();

            byte[] code = File.ReadAllBytes("chip8test.bin");
            Chip8.Core.Program program = new Decompiler().Decompile(code);
            _source = program.ToAssembler().Split('\n').Take(program.Instructions.Count).ToArray();
            Console.WriteLine("\n" + program.ToAssembler());

            Console.WriteLine("Press any key to run this program...");
            Console.ReadKey();

            VirtualMachine vm = new VirtualMachine();
            vm.BeforeInstructionExecute += Vm_BeforeInstructionExecute;
            vm.AfterInstructionExecute += Vm_AfterInstructionExecute;

            Console.Clear();
            _lastValues = vm.State;
            Display(vm, _lastValues);

            vm.Run(program, 500);

            Console.WriteLine("\n\nProgram ended. Press any key to exit.");
            Console.ReadKey();
        }

        private static void Vm_AfterInstructionExecute(object sender, VirtualMachine vm)
        {
            Display(vm, _lastValues);
            _lastValues = vm.State;
            //Console.WriteLine("\nPress any key for next instruction");
            //Console.ReadKey();
        }

        private static void Vm_BeforeInstructionExecute(object sender, VirtualMachine vm)
        {
        }

        public static void Display(VirtualMachine vm, byte[] lastValues)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("CHIP8 Virtual Machine (C)2016 Radius Zero Ltd");
            Console.WriteLine("---------------------------------------------\n");
            Console.WriteLine("Register state");
            Console.WriteLine("==============\n");
            bool flipFlop = false;
            for (int i = 0; i < 16; i++)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("V" + i.ToString().PadRight(2) + ": ");
                if (lastValues == null || vm.V[i].Value != lastValues[i])
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                Console.Write("0x" + vm.V[i].Value.ToString("X").ToUpper());
                if (flipFlop)
                {
                    Console.WriteLine();
                }
                else
                {
                    Console.Write("\t\t");
                }
                flipFlop = !flipFlop;
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\nProgram counter: " + vm.ProgramCounter + "\n");

            int start = vm.ProgramCounter >= 4 ? vm.ProgramCounter - 4 : 0;
            for (int i = start; i < start + 10; i++)
            {
                if (i >= 0 && i < _source.Length)
                {
                    if (i == vm.ProgramCounter)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }

                    Console.WriteLine(_source[i] + "                       ");
                }
                else
                {
                    Console.WriteLine("                               ");
                }

                Console.ForegroundColor = ConsoleColor.White;
            }
        }
    }
}
