using lab2Faker.Core;

namespace lab2Faker.Generators
{
    internal class UIntGenerator : IValueGenerator
    {
        public readonly Type GeneratorType = typeof(uint);
        public bool CanGenerate(Type type)
        {
            return type == GeneratorType;
        }

        public object Generate(Type typeToGenerate, GeneratorContext context)
        {
            return (uint)ByteGenerator.Next(context);
        }
    }
}
