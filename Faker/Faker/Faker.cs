using lab2Faker.Generators;
using System;
using System.Collections.ObjectModel;
using System.Reflection;

namespace lab2Faker.Core
{
    public class Faker
    {
        private readonly List<IValueGenerator> m_generators; // private readonly
        private readonly GeneratorContext m_gcontext;

        public bool isOk() { return m_generators.Last().CanGenerate(null);  }

        public Faker()
        {
            m_gcontext = new GeneratorContext(new Random(), this);
            m_generators = new List<IValueGenerator>();

            // get all generators from assemblies (except the last one - ObjectGenerator)
            var types = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(i => i.GetTypes())
                .Where(j => typeof(IValueGenerator).IsAssignableFrom(j) && 
                        !j.IsInterface && !Equals(j.Name, "ObjectGenerator"))
                .ToList();
            // add them to generators list
            foreach (var type in types)
            {
                try
                {
                    var gen = (IValueGenerator?)Activator.CreateInstance(type);
                    if (gen != null)
                    {
                        m_generators.Add(gen);
                    }
                } catch { };
            }
            // add last of generators -- ObjectGenerator
            m_generators.Add(new ObjectGenerator(new ObjRecursionManager(4)));
        }

        public T Create<T>()
        {
            return (T)Create(typeof(T));
        }

        // Может быть вызван изнутри Faker, из IValueGenerator (см. ниже) или пользователем
        public object Create(Type t)
        {
            // Процедура создания и инициализации объекта.

            // check if in m_generators
            foreach (IValueGenerator g in m_generators)
            {
                if (g.CanGenerate(t))
                {
                    return g.Generate(t, m_gcontext);
                }
            }
            return null;
        }
    }
}