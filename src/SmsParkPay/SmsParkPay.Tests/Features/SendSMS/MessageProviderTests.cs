using NUnit.Framework;
using SmsParkPay.Features.SendSMS;

namespace SmsParkPay.Tests.Features.SendSMS
{
    public class MessageProviderTests
    {
        [TestCase(FareType.Area1Time30Minutes, "PlateNr", ExpectedResult = "403 PlateNr")]
        [TestCase(FareType.Area1Time1Hour, "PlateNr", ExpectedResult = "404 PlateNr")]
        [TestCase(FareType.Area1Time2Hours, "PlateNr", ExpectedResult = "405 PlateNr")]
        [TestCase(FareType.Area2Time1Hour, "PlateNr", ExpectedResult = "407 PlateNr")]
        [TestCase(FareType.Area2Time2Hours, "PlateNr", ExpectedResult = "408 PlateNr")]
        [TestCase(FareType.Area2Time4Hours, "PlateNr", ExpectedResult = "409 PlateNr")]
        public string GivenTypeAndPlate_GetMessage_ReturnsExpectedMessage(FareType type, string plate)
        {
            return type.GetMessage(plate);
        }

        [Test]
        public void GivenEmptyPlate_GetMessage_ReturnsEmptyString([Values]FareType type)
        {
            Assert.That(type.GetMessage(string.Empty), Is.Empty);
        }

        [Test]
        public void GivenNullPlate_GetMessage_ReturnsEmptyString([Values]FareType type)
        {
            Assert.That(type.GetMessage(null), Is.Empty);
        }
    }
}
