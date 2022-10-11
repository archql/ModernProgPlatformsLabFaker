using lab2Faker.Core;

namespace lab2Faker.Generators
{
    internal class SByteGenerator : IValueGenerator
    {
        public readonly Type GeneratorType = typeof(sbyte);
        public bool CanGenerate(Type type)
        {
            return type == GeneratorType;
        }
        public object Generate(Type typeToGenerate, GeneratorContext context)
        {
            return Next(context);
        }
        public static sbyte Next(GeneratorContext ctx)
        {
            return (sbyte)((ctx.Random.Next(sbyte.MaxValue) + 1) * (ctx.Random.Next(0, 1) * 2 - 1));
        }
    }
}
