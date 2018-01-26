using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Engine
{
    public struct SeedGenerator
    {
        private DateTime _baseSeed;
        public DateTime BaseSeed
        {
            get => _baseSeed;
        }

        public SeedGenerator(DateTime baseSeed) : this()
        {
            _baseSeed = baseSeed;
        }

        public double SeedAsDouble() => _baseSeed.ToOADate();

        public int SeedAsInteger() => (int)_baseSeed.ToOADate();

        public double NextDouble() => new Random(SeedAsInteger()).NextDouble();

        public int NextInteger() => new Random(SeedAsInteger()).Next();

        public int NextInteger(int min, int max) => new Random(SeedAsInteger()).Next(min, max);

        public byte[] NextByteSequence(int elements = 8)
        {
            Byte[] byteSequence = new Byte[elements];
            new Random(SeedAsInteger()).NextBytes(byteSequence);
            return byteSequence;
        }
    }
}
