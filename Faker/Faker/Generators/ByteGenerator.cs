using lab2Faker.Core;

namespace lab2Faker.Generators 
{
    internal class ByteGenerator : IValueGenerator
    {
        public readonly Type GeneratorType = typeof(byte);
        public bool CanGenerate(Type type)
        {
            return type == GeneratorType;
        }

        public object Generate(Type typeToGenerate, GeneratorContext context)
        {
            return Next(context);
        }

        public static byte Next(GeneratorContext ctx)
        {
            return (byte)(ctx.Random.Next(byte.MaxValue) + 1);
        }
    }
}
