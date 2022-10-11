using lab2Faker.Core;

namespace lab2Faker.Generators
{
    internal class IntGenerator : IValueGenerator
    {
        public readonly Type GeneratorType = typeof(int);
        public bool CanGenerate(Type type)
        {
            return type == GeneratorType;
        }

        public object Generate(Type typeToGenerate, GeneratorContext context)
        {
            return (int)SByteGenerator.Next(context);
        }
    }
}
