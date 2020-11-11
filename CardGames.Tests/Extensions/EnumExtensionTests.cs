using CardGames.Extensions;
using NUnit.Framework;

namespace CardGames.Tests.Extensions
{
    [TestFixture]
    public class EnumExtensionTests
    {
        [Test]
        public void GetDescription_WithDescriptionAttribute()
        {
            const TestEnum enumValue = TestEnum.HasDescription;

            var result = enumValue.GetDescription();

            Assert.AreEqual("Has Description", result);
        }

        [Test]
        public void GetDescription_NoDescriptionAttribute()
        {
            const TestEnum enumValue = TestEnum.NoDescription;

            var result = enumValue.GetDescription();

            Assert.AreEqual("NoDescription", result);
        }

        [Test]
        public void GetDescription_NoValue()
        {
            const TestEnum enumValue = (TestEnum)3;

            var result = enumValue.GetDescription();

            Assert.AreEqual(string.Empty, result);
        }
    }
}
