using lab2Faker.Core;

namespace lab2Faker.Generators
{
    internal class FloatGenerator : IValueGenerator
    {
        static public float ScaleFactor = 100;

        public readonly Type GeneratorType = typeof(float);
        public bool CanGenerate(Type type)
        {
            return type == GeneratorType;
        }

        public object Generate(Type typeToGenerate, GeneratorContext context)
        {
            return (context.Random.NextSingle() - 0.5f) * ScaleFactor;
        }
    }
}
