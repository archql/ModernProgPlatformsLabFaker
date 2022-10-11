using lab2Faker.Core;

namespace lab2Faker.Generators
{
    internal class CharGenerator : IValueGenerator
    {
        public readonly Type GeneratorType = typeof(char);
        public bool CanGenerate(Type type)
        {
            return type == GeneratorType;
        }
        public object Generate(Type typeToGenerate, GeneratorContext context)
        {
            return StringGenerator.chars[context.Random.Next(StringGenerator.chars.Length)];
        }
    }
}
