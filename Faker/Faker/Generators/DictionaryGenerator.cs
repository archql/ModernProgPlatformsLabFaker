using lab2Faker.Core;
using System.Collections;

namespace lab2Faker.Generators
{
    internal class DictionaryGenerator : IValueGenerator
    {
        public readonly Type GeneratorType = typeof(IDictionary<,>);
        public bool CanGenerate(Type type)
        {
            return type.GetInterfaces().Any(it => it.IsGenericType && it.GetGenericTypeDefinition() == typeof(IDictionary<,>));
        }

        public object Generate(Type typeToGenerate, GeneratorContext context)
        {
            IDictionary? e;
            try
            {
                e = (IDictionary?)Activator.CreateInstance(typeToGenerate);
            } catch { return null; }
            if (e != null)
            {
                var len = context.Random.Next(3, 5);
                for (int i = 0; i < len; i++) 
                { 
                    e.Add(
                        context.Faker.Create(typeToGenerate.GetGenericArguments()[0]),
                        context.Faker.Create(typeToGenerate.GetGenericArguments()[1])
                        );
                }
            }
            return e;
        }
    }
}
