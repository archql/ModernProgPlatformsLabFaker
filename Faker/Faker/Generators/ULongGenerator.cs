using lab2Faker.Core;

namespace lab2Faker.Generators
{
    internal class ULongGenerator : IValueGenerator
    {
        public readonly Type GeneratorType = typeof(ulong);
        public bool CanGenerate(Type type)
        {
            return type == GeneratorType;
        }

        public object Generate(Type typeToGenerate, GeneratorContext context)
        {
            return (ulong)ByteGenerator.Next(context);
        }
    }
}
