using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basic.Samples.TestDataBuilder
{
    [TestFixture]
    public class TestDataBuilder_Sample_Tests
    {
        [Test]
        public void WorksWithObjectMother()
        {
            var user = TestUsers.ARegularUser();
            var adminUser = TestUsers.AnAdmin();
            // Если в тестах нужно много комбинаций параметров, будет комбинаторный взрыв.
        }

        [Test]
        public void WorksWithBuilder()
        {
            var user = TestUserBuilder.AUser().Build();
            var adminUser = TestUserBuilder.AUser().InAdminRole().Build();
            // Такой код не ломается, при смене сигнатуры конструктора User.
            // Это важно, если таких тестов много.
        }
    }
}
