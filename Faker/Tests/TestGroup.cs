namespace lab2Faker.Tests
{
    using lab2Faker.Core;

    using crazyDictionary = Dictionary<Dictionary<int, int>, Dictionary<int, int>>;
    public class Tests
    {
        private Faker f;

        [SetUp]
        public void Setup()
        {
            f = new Faker();
            Assert.That(f.isOk(), Is.EqualTo(true));
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

        [Test]
        public void TestConstructiveObjects()
        {
            C c = TestPrimitiveGenerate<C>(f);

            Assert.That(c.x, Is.Not.EqualTo(0));
            Assert.That(c.y, Is.Not.EqualTo(0));
            Assert.That(c.z, Is.Not.EqualTo(0));
            Assert.That(c.w, Is.EqualTo(0));

            D d = TestPrimitiveGenerate<D>(f);

            Assert.That(d.x, Is.EqualTo(0));
            Assert.That(d.y, Is.EqualTo(0));
            Assert.That(d.z, Is.Not.EqualTo(0));
            Assert.That(d.w, Is.Not.EqualTo(0));
            Assert.That(d.name, Is.EqualTo("Hello"));
        }

        [Test]
        public void TestRecursion()
        {
            E e = TestPrimitiveGenerate<E>(f);
            Assert.That(e.x, Is.Not.EqualTo(0));
            Assert.That(e.next, Is.Not.EqualTo(null));
            Assert.That(e.next.next, Is.Not.EqualTo(null));
            Assert.That(e.next.next.next, Is.Not.EqualTo(null));
            Assert.That(e.next.next.next.next, Is.Not.EqualTo(null));
            Assert.That(e.next.next.next.next.next, Is.EqualTo(null));
        }

        [Test]
        public void TestCollection()
        {
            //Dictionary<A, E> d = f.Create<Dictionary<A, E>>();
            Dictionary<int, string> d = f.Create<Dictionary<int, string>>();
            Assert.That(d.Count, Is.GreaterThan(0));

            Dictionary<A, E> d2 = f.Create<Dictionary<A, E>>();
            foreach (var item in d2)
            {
                Assert.That(item.Key, Is.Not.Null);
                Assert.That(item.Value, Is.Not.Null);
            }

            crazyDictionary d3 = f.Create<crazyDictionary>();
            foreach (var item in d3)
            {
                Assert.That(item.Key, Is.Not.Null);
                Assert.That(item.Value, Is.Not.Null);
                Assert.That(item.Key.Count, Is.GreaterThan(0));
                Assert.That(item.Value.Count, Is.GreaterThan(0));
            }
        }

        class E
        {
            public int x;
            public E? next;

            public override string ToString()
            {
                return "{ val = " + x + "; base: " + ((next == null) ? "null" : next.ToString()) + " }";
            }
        }
        class D : C
        {
            public string name { get; private set; } = "Hello";
            public D(int w) : base(w, 0, 0)
            {
            }

            public override string ToString()
            {
                return "{ name = " + name + "; base: " + base.ToString() + " }";
            }
        }

        class C
        {
            public int x { get; private set; }
            public int y { get; private set; }
            public int z;
            public int w { get; private set; } = 0;

            public C()
            { }
            public C(int x, int y) { this.x = x; this.y = y;}
            protected C(int w, int x, int y) { this.w = w; this.x = x; this.y = y; }

            public override string ToString()
            {
                return "{ x = " + x + "; y = " + y + "; z = " + z + "; w = " + w + " }";
            }
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