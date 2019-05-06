using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using Plugin.Messaging;
using SmsParkPay.Features.SendSMS;
using SmsParkPay.Features.Settings;

namespace SmsParkPay.Tests.Features.SendSMS
{
    public class SendSMSViewModelTests
    {
        [Test]
        public void GivenCanSendSmsIsFalse_SensSms_DoesntSendSms()
        {
            var smsTaskMock = new Mock<ISmsTask>();
            smsTaskMock.Setup(task => task.CanSendSms).Returns(false);

            var sut = new SendSMSViewModel(smsTaskMock.Object, Mock.Of<ISettingsService>());

            sut.SendSmsCommand.Execute(FareType.Area1Time1Hour);

            smsTaskMock.Verify(task => task.SendSms(It.IsAny<string>(), It.IsAny<string>()), Times.Never);
        }

        [TestCaseSource(nameof(GetInvalidSettingsCases))]
        public void GivenInvalidSettings_SendSms_DoesntSendSms(ISettingsService settingsService)
        {
            var smsTaskMock = new Mock<ISmsTask>();
            smsTaskMock.Setup(task => task.CanSendSms).Returns(true);

            var sut = new SendSMSViewModel(smsTaskMock.Object, settingsService);

            sut.SendSmsCommand.Execute(FareType.Area1Time1Hour);

            smsTaskMock.Verify(task => task.SendSms(It.IsAny<string>(), It.IsAny<string>()), Times.Never);
        }

        private static IEnumerable<TestCaseData> GetInvalidSettingsCases()
        {
            yield return new TestCaseData(CreateSettingsService(null, "plate"));

            yield return new TestCaseData(CreateSettingsService("number", null));
        }

        [Test]
        public void GivenValidSettings_SendSms_SendsSms()
        {
            var smsTaskMock = new Mock<ISmsTask>();
            smsTaskMock.Setup(task => task.CanSendSms).Returns(true);

            var sut = new SendSMSViewModel(smsTaskMock.Object, CreateSettingsService("phone", "plate"));

            sut.SendSmsCommand.Execute(FareType.Area1Time1Hour);

            smsTaskMock.Verify(task => task.SendSms("phone", "404 plate"), Times.Once);
        }

        private static ISettingsService CreateSettingsService(string phoneNumber, string licensePlate)
        {
            return Mock.Of<ISettingsService>(service => service.PhoneNumber == phoneNumber &&
                                                        service.LicensePlate == licensePlate);
        }
    }
}
