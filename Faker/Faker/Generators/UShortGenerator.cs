using lab2Faker.Core;

namespace lab2Faker.Generators
{
    internal class UShortGenerator : IValueGenerator
    {
        public readonly Type GeneratorType = typeof(ushort);
        public bool CanGenerate(Type type)
        {
            return type == GeneratorType;
        }

        public object Generate(Type typeToGenerate, GeneratorContext context)
        {
            return (ushort)ByteGenerator.Next(context);
        }
    }
}
