using MessageApplication.Web;
using Xunit;

namespace MessageApplication.Tests
{
    public class TransliterationTests
    {
        [Fact]
        public void CyrillicToLatinStringEmptyTest()
        {
            Assert.Equal(Transliteration.CyrillicToLatin(string.Empty), string.Empty);
        }

        [Fact]
        public void CyrillicToLatinStringNullTest()
        {
            Assert.Equal(Transliteration.CyrillicToLatin(null), string.Empty);
        }

        [Fact]
        public void CyrillicToLatinStringTest()
        {
            Assert.Equal(Transliteration.CyrillicToLatin("Привет мир"), "Privet mir");
        }
    }
}