using System;
using System.Reflection;

namespace lab2Faker.Core
{
    public class Faker
    {
        Random rnd = new Random();

        public T Create<T>()
        {
            // get type t
            Type t = typeof(T);
            if (t.IsPrimitive || t == typeof(Decimal))
            {
                switch (Type.GetTypeCode(t))
                {
                    case TypeCode.Boolean: return (T)Convert.ChangeType(rnd.Next(1) == 0, t);
                    case TypeCode.Byte: return (T)Convert.ChangeType(rnd.Next(256), t);
                    case TypeCode.SByte: return (T)Convert.ChangeType(rnd.Next(256) - 128, t);
                    case TypeCode.Int16:
                    case TypeCode.Int32:
                    case TypeCode.Int64:
                        return (T)Convert.ChangeType(rnd.Next(UInt16.MaxValue) - Int16.MaxValue, t);
                    case TypeCode.UInt16:
                    case TypeCode.UInt32:
                    case TypeCode.UInt64:
                    case TypeCode.Char:
                        return (T)Convert.ChangeType(rnd.Next(UInt16.MaxValue), t);
                    case TypeCode.Double:
                    case TypeCode.Single:
                    case TypeCode.Decimal:
                        return (T)Convert.ChangeType(rnd.NextSingle() * 100, t);
                }
            }
            else if (t == typeof(string))
            {
                return (T)Convert.ChangeType(RandomString(rnd.Next(5, 25)), t);
            }

            // create instance of type T
            T result = Activator.CreateInstance<T>();

            TypeInfo info = t.GetTypeInfo();
            IEnumerable<PropertyInfo> pList = info.DeclaredProperties;
            IEnumerable<MethodInfo> mList = info.DeclaredMethods;

            return result;
        }
        private string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[rnd.Next(s.Length)]).ToArray());
        }
    }
}