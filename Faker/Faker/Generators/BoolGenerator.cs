using lab2Faker.Core;

namespace lab2Faker.Generators
{
    internal class BoolGenerator : IValueGenerator
    {
        public readonly Type GeneratorType = typeof(bool);
        public bool CanGenerate(Type type)
        {
            return type == GeneratorType;
        }

        public object Generate(Type typeToGenerate, GeneratorContext ctx)
        {
            return true; //ctx.Random.Next(1) == 0;
        }
    }
}
