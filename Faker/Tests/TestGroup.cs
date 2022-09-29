namespace lab2Faker.Tests
{
    using lab2Faker.Core;
    public class Tests
    {

        [SetUp]
        public void Setup()
        {
        }

        private T TestPrimitiveGenerate<T>(Faker f)
        {
            object i;
            try
            {
                i = f.Create<T>();
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
                return default(T);
            }
            Assert.IsInstanceOf(typeof(T), i);
            Assert.IsNotNull(i);
            TestContext.WriteLine(typeof(T).FullName + " generated: {0}", i.ToString());

            return (T)i;
        }

        [Test]
        public void TestPrimitives()
        {
            Faker f = new Faker();
            // test
            TestPrimitiveGenerate<int>(f);
            TestPrimitiveGenerate<double>(f);
            TestPrimitiveGenerate<string>(f);
            TestPrimitiveGenerate<bool>(f);
            TestPrimitiveGenerate<char>(f);
            TestPrimitiveGenerate<short>(f);
            TestPrimitiveGenerate<ushort>(f);
            TestPrimitiveGenerate<long>(f);
            TestPrimitiveGenerate<decimal>(f);


            Assert.Pass();
        }

        [Test]
        public void TestSimpleObjects()
        {
            Faker f = new Faker();

            // create instance of type T
            // get type t
            Type t = typeof(A);
            A result = Activator.CreateInstance<A>();

            Assert.That(typeof(A).GetFields().Length, Is.Not.EqualTo(0));
            Assert.That(typeof(B).GetFields().Length, Is.Not.EqualTo(0));

            A a = TestPrimitiveGenerate<A>(f);
            B b = TestPrimitiveGenerate<B>(f);

            Assert.That(a.id, Is.Not.EqualTo(0));
            Assert.IsNotNull(a.name);
            Assert.IsNotEmpty(a.name);

            Assert.That(b.id, Is.Not.EqualTo(0));
            Assert.IsNotNull(b.name);
            Assert.IsNotEmpty(b.name);


            Assert.Pass();
        }
        class A
        {
            public int id;
            public string name;

            public override string ToString()
            {
                return "{ id = " + id + "; name = " + name + " }";
            }
        };
        class B : A
        {
            public double weight;
            public float price;
            public char currency;

            public override string ToString()
            {
                return "{ weight = " + weight + "; price = " + price + "; currency " + currency +
                    "; base: " + base.ToString() + " }";
            }
        }
    }
}