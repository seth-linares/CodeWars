/*

https://www.codewars.com/kata/52685f7382004e774f0001f7

Write a function, which takes a non-negative integer (seconds) as input and returns the time in a human-readable format (HH:MM:SS)

    HH = hours, padded to 2 digits, range: 00 - 99
    MM = minutes, padded to 2 digits, range: 00 - 59
    SS = seconds, padded to 2 digits, range: 00 - 59

The maximum time never exceeds 359999 (99:59:59)

You can find some examples in the test fixtures.


*/

using NUnit.Framework;

namespace Code_Problems {
    public static class TimeFormat {
        public static string GetReadableTime(int seconds) {
            int leftover_seconds = seconds % 3600;
            return $"{seconds / 3600:00}:{leftover_seconds / 60:00}:{leftover_seconds % 60:00}";   
        }
    }
}






// [TestFixture]
// public class HumanReadableTimeTest
// {
//   [Test]
//   public void HumanReadableTest()
//   {
//       Assert.AreEqual("00:00:00", TimeFormat.GetReadableTime(0));
//       Assert.AreEqual("00:00:05", TimeFormat.GetReadableTime(5));
//       Assert.AreEqual("00:01:00", TimeFormat.GetReadableTime(60));
//       Assert.AreEqual("23:59:59", TimeFormat.GetReadableTime(86_399));
//       Assert.AreEqual("99:59:59", TimeFormat.GetReadableTime(359_999));
//   }
// }