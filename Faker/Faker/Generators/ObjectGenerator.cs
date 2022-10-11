using lab2Faker.Core;

namespace lab2Faker.Generators
{
    internal class ObjectGenerator : IValueGenerator
    {
        private readonly ObjRecursionManager recursionManager;

        public ObjectGenerator(ObjRecursionManager orm)
        {
            recursionManager = orm;
        }

        private static object? GetDefaultValue(Type t)
        {
            if (t.IsValueType) 
            { 
                // Для типов-значений вызов конструктора по умолчанию даст default(T).
                try
                {
                    return Activator.CreateInstance(t);
                } catch { };
            }
            // Для ссылочных типов значение по умолчанию всегда null.
            return null;
        }
        private object CreateObject(Type t, GeneratorContext ctx)
        {
            if (!recursionManager.tryEnterRecursion(t))
                return null;
            var constructors = t.GetConstructors(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public)
                .OrderByDescending(t => t.GetParameters().Length)
                .ToList();
            foreach (var constructor in constructors)
            {
                var initedArgs = constructor.GetParameters().
                    Select(i => i.ParameterType).
                    Select(ctx.Faker.Create).
                    ToArray();
                try
                {
                    return constructor.Invoke(initedArgs);
                } catch (Exception ex) { Console.WriteLine(ex); }
            }
            if (!t.IsValueType)
            {
                try
                {
                    return Activator.CreateInstance(t);
                } catch { };
            }
            return null;
        }
        private void FillObject(object o, Type t, GeneratorContext ctx)
        {
            if (o == null)
                return;
            foreach (var fld in t.GetFields(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public))
            {
                if (Equals(fld.GetValue(o), GetDefaultValue(fld.FieldType)))
                    fld.SetValue(o, ctx.Faker.Create(fld.FieldType));
            }
            foreach (var fld in t.GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public))
            {
                if (Equals(fld.GetValue(o), GetDefaultValue(fld.PropertyType)) && fld.CanWrite && fld.SetMethod != null && fld.SetMethod.IsPublic)
                    fld.SetValue(o, ctx.Faker.Create(fld.PropertyType));
            }

            recursionManager.leaveRecursion(t);
        }
        public object Generate(Type typeToGenerate, GeneratorContext context)
        {
            var o = CreateObject(typeToGenerate, context);
            FillObject(o, typeToGenerate, context);
            return o;
        }

        public bool CanGenerate(Type type)
        {
            return true;
        }
    }
}
