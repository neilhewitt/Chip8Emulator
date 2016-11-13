using System;
using System.Linq;

namespace Chip8.Core
{
    public class Nybble
    {
        public Bit BitOne { get; }
        public Bit BitTwo { get; }
        public Bit BitThree { get; }
        public Bit BitFour { get; }

        public Nybble(string bitsAsString)
        {
            if (bitsAsString.Length != 4 || !bitsAsString.All(x => x == '1' || x == '0'))
            {
                throw new ArgumentException("Input must be 4 chars long and all chars must be 0 or 1");
            }

            BitOne = new Bit(bitsAsString[0] == 0 ? BitState.Zero : BitState.One);
            BitTwo = new Bit(bitsAsString[1] == 0 ? BitState.Zero : BitState.One);
            BitThree = new Bit(bitsAsString[2] == 0 ? BitState.Zero : BitState.One);
            BitFour = new Bit(bitsAsString[3] == 0 ? BitState.Zero : BitState.One);
        }
    }

    public class Bit
    {
        private int _value;

        public Bit(BitState state)
        {
            _value = state == BitState.Zero ? 0 : 1;
        }
    }

    public enum BitState
    {
        Zero, One
    }
}