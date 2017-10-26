using CrossCuttingConcerns;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CrossCuttingConcernsTests
{
    [TestClass]
    public class CommonServiceTests
    {
        [TestMethod]
        public void Giving_BelgiumCode_When_GetVatByCountryCodeIsCalled_Then_Should_Return_21()
        {
            CommonService service = new CommonService();

            var code = service.GetVatByCountryCode(Country.BE);

            code.Should().Be(21);
        }

        [TestMethod]
        public void Giving_CanadaCode_When_GetVatByCountryCodeIsCalled_Then_Should_Return_5()
        {
            CommonService service = new CommonService();

            var code = service.GetVatByCountryCode(Country.CA);

            code.Should().Be(5);
        }

        [TestMethod]
        public void Giving_FranceCode_When_GetVatByCountryCodeIsCalled_Then_Should_Return_20()
        {
            CommonService service = new CommonService();

            var code = service.GetVatByCountryCode(Country.FR);

            code.Should().Be(20);
        }

        [TestMethod]
        public void Giving_ItalyCode_When_GetVatByCountryCodeIsCalled_Then_Should_Return_22()
        {
            CommonService service = new CommonService();

            var code = service.GetVatByCountryCode(Country.IT);

            code.Should().Be(22);
        }

        [TestMethod]
        public void Giving_RomaniaCode_When_GetVatByCountryCodeIsCalled_Then_Should_Return_24()
        {
            CommonService service = new CommonService();

            var code = service.GetVatByCountryCode(Country.RO);

            code.Should().Be(24);
        }

        [TestMethod]
        public void Giving_BelgiumCodeAndPrice1000_When_GetVATValueFromPriceIsCalled_Then_Should_Return_210()
        {
            CommonService service = new CommonService();

            var vatValue = service.GetVATValueFromPrice(Country.BE, 1000);

            vatValue.Should().Be(210);
        }

        [TestMethod]
        public void Giving_CanadaCodeAndPrice1000_When_GetVATValueFromPriceIsCalled_Then_Should_Return_50()
        {
            CommonService service = new CommonService();

            var vatValue = service.GetVATValueFromPrice(Country.CA, 1000);

            vatValue.Should().Be(50);
        }

        [TestMethod]
        public void Giving_FranceCodeAndPrice1000_When_GetVATValueFromPriceIsCalled_Then_Should_Return_200()
        {
            CommonService service = new CommonService();

            var vatValue = service.GetVATValueFromPrice(Country.FR, 1000);

            vatValue.Should().Be(200);
        }

        [TestMethod]
        public void Giving_ItalyCodeAndPrice1000_When_GetVATValueFromPriceIsCalled_Then_Should_Return_220()
        {
            CommonService service = new CommonService();

            var vatValue = service.GetVATValueFromPrice(Country.IT, 1000);

            vatValue.Should().Be(220);
        }

        [TestMethod]
        public void Giving_RomaniaCodeAndPrice1000_When_GetVATValueFromPriceIsCalled_Then_Should_Return_240()
        {
            CommonService service = new CommonService();

            var vatValue = service.GetVATValueFromPrice(Country.RO, 1000);

            vatValue.Should().Be(240);
        }

        [TestMethod]
        public void Giving_BelgiumCodeAndPrice1000_When_GetFinalPriceIsCalled_Then_Should_Return_1210()
        {
            CommonService service = new CommonService();

            var vatValue = service.GetFinalPrice(Country.BE, 1000);

            vatValue.Should().Be(1210);
        }

        [TestMethod]
        public void Giving_CanadaCodeAndPrice1000_When_GetFinalPriceIsCalled_Then_Should_Return_1050()
        {
            CommonService service = new CommonService();

            var vatValue = service.GetFinalPrice(Country.CA, 1000);

            vatValue.Should().Be(1050);
        }

        [TestMethod]
        public void Giving_FranceCodeAndPrice1000_When_GetFinalPriceIsCalled_Then_Should_Return_1200()
        {
            CommonService service = new CommonService();

            var vatValue = service.GetFinalPrice(Country.FR, 1000);

            vatValue.Should().Be(1200);
        }

        [TestMethod]
        public void Giving_ItalyCodeAndPrice1000_When_GetFinalPriceIsCalled_Then_Should_Return_1220()
        {
            CommonService service = new CommonService();

            var vatValue = service.GetFinalPrice(Country.IT, 1000);

            vatValue.Should().Be(1220);
        }

        [TestMethod]
        public void Giving_RomaniaCodeAndPrice1000_When_GetFinalPriceIsCalled_Then_Should_Return_1240()
        {
            CommonService service = new CommonService();

            var vatValue = service.GetFinalPrice(Country.RO, 1000);

            vatValue.Should().Be(1240);
        }
    }
}
