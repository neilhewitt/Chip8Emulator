using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chip8.Core;
using System.IO;

namespace Chip8.Tests
{
    public class Program
    {
        public static void Main(string[] args)
        {
            byte[] code = File.ReadAllBytes("chip8test.bin");
            Chip8.Core.Program program = new Decompiler().Decompile(code);
            Console.WriteLine(program.ToAssembler());
            byte[] newCode = new Compiler().Compile(program);
            File.WriteAllBytes("compiled.bin", newCode);
            Console.ReadLine();
        }
    }
}
