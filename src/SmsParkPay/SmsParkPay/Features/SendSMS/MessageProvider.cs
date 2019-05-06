using System.Collections.Generic;
using SmsParkPay.Mixins;

namespace SmsParkPay.Features.SendSMS
{
    internal static class MessageProvider
    {
        private static readonly Dictionary<FareType, string> FareToCodeMap = new Dictionary<FareType, string>
        {
            {FareType.Area1Time30Minutes, "403"},
            {FareType.Area1Time1Hour, "404"},
            {FareType.Area1Time2Hours, "405"},

            {FareType.Area2Time1Hour, "407"},
            {FareType.Area2Time2Hours, "408"},
            {FareType.Area2Time4Hours, "409"}
        };

        internal static string GetMessage(this FareType type, string licensePlate)
        {
            if (licensePlate.IsNullOrEmpty())
                return string.Empty;

            return FareToCodeMap.ContainsKey(type)
                ? $"{FareToCodeMap[type]} {licensePlate}"
                : string.Empty;
        }
    }
}
