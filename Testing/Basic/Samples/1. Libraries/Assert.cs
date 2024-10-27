using FluentAssertions;
using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace Basic.Samples.Libraries
{
    [TestFixture]
    internal class Assert
    {

        [Test]
        public void Sum_Assert()
        {
            var result = 1 + 2;

            Assert.Equals(result, 3);
        }

        [Test]
        public void Sum_Fluent()
        {
            var result = 1 + 2;
            result.Should().Be(3);
        }


        [Test]
        public void Collections_Assert()
        {
            var result = new List<int>();
            result.Add(1);

            CollectionAssert.AreEqual(result, new List<int> { 1 });
        }

        [Test]
        public void Collections_Fluent()
        {
            var result = new List<int>();
            result.Add(1);

            result.Should().BeEquivalentTo(new List<int> { 1 });
        }
    }
}
