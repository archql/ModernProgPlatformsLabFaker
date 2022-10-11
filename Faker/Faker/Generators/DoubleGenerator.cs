using lab2Faker.Core;

namespace lab2Faker.Generators
{
    internal class DoubleGenerator : IValueGenerator
    {
        static public double ScaleFactor = 100;

        public readonly Type GeneratorType = typeof(double);
        public bool CanGenerate(Type type)
        {
            return type == GeneratorType;
        }

        public object Generate(Type typeToGenerate, GeneratorContext context)
        {
            return (context.Random.NextDouble() - 0.5) * ScaleFactor;
        }
    }
}
