using lab2Faker.Core;

namespace lab2Faker.Generators
{
    internal class StringGenerator : IValueGenerator
    {
        internal const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789 $%#^&!@)(*?";

        public readonly Type GeneratorType = typeof(string);
        public bool CanGenerate(Type type)
        {
            return type == GeneratorType;
        }
        public object Generate(Type typeToGenerate, GeneratorContext context)
        {
            return RandomString(context.Random, 5, 25);
        }
        internal string RandomString(Random rnd, int minlen, int maxlen)
        {
            int len = rnd.Next(minlen, maxlen);
            return new string(Enumerable.Repeat(chars, len)
                .Select(s => s[rnd.Next(s.Length)]).ToArray());
        }
    }
}
