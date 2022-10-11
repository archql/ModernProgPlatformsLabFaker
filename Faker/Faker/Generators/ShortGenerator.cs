using lab2Faker.Core;

namespace lab2Faker.Generators
{
    internal class ShortGenerator : IValueGenerator
    {
        public readonly Type GeneratorType = typeof(short);
        public bool CanGenerate(Type type)
        {
            return type == GeneratorType;
        }

        public object Generate(Type typeToGenerate, GeneratorContext context)
        {
            return (short)SByteGenerator.Next(context);
        }
    }
}
