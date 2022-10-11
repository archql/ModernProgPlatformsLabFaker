using lab2Faker.Core;

namespace lab2Faker.Generators
{
    internal class LongGenerator : IValueGenerator
    {
        public readonly Type GeneratorType = typeof(long);
        public bool CanGenerate(Type type)
        {
            return type == GeneratorType;
        }

        public object Generate(Type typeToGenerate, GeneratorContext context)
        {
            return (long)SByteGenerator.Next(context);
        }
    }
}
