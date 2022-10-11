using lab2Faker.Core;

namespace lab2Faker.Generators
{
    internal class DecimalGenerator : IValueGenerator
    {
        public double ScaleFactor = 100;

        public readonly Type GeneratorType = typeof(decimal);
        public bool CanGenerate(Type type)
        {
            return type == GeneratorType;
        }

        public object Generate(Type typeToGenerate, GeneratorContext context)
        {
            return (decimal)((context.Random.NextDouble() - 0.5) * ScaleFactor);
        }
    }
}
