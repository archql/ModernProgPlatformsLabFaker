namespace lab2Faker.Tests
{
    using lab2Faker.Core;
    public class Tests
    {

        [SetUp]
        public void Setup()
        {
        }

        private void TestPrimitiveGenerate<T>(Faker f)
        {
            object i;
            try
            {
                i = f.Create<T>();
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
                return;
            }
            Assert.IsInstanceOf(typeof(T), i);
            Assert.IsNotNull(i);
            TestContext.WriteLine(typeof(T).FullName + " generated: {0}", i.ToString());
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


            Assert.Pass();
        }
    }
}