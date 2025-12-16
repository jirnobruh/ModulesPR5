using System;

namespace ModulesPR5
{
    public class UserSession
    {
        public int Id { get; set; }
        public string LastName { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string MiddleName { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;

        public string FullName
        {
            get
            {
                var parts = new[] { LastName, FirstName, MiddleName };
                return string.Join(" ", parts).Trim();
            }
        }
    }

    public static class Session
    {
        public static UserSession CurrentUser { get; set; }

        public static bool IsWithinWorkHours(DateTime now)
        {
            var t = now.TimeOfDay;
            var workStart = new TimeSpan(10, 0, 0);
            var workEnd = new TimeSpan(19, 0, 0);
            return t >= workStart && t <= workEnd;
        }

        public static string GetGreeting(DateTime now)
        {
            if (CurrentUser == null) return string.Empty;

            var t = now.TimeOfDay;
            var morningStart = new TimeSpan(10, 0, 0);
            var morningEnd = new TimeSpan(12, 0, 0);
            var dayStart = new TimeSpan(12, 1, 0);
            var dayEnd = new TimeSpan(17, 0, 0);
            var eveningStart = new TimeSpan(17, 1, 0);
            var eveningEnd = new TimeSpan(19, 0, 0);

            string part = null;
            if (t >= morningStart && t <= morningEnd) part = "Доброе утро";
            else if (t >= dayStart && t <= dayEnd) part = "Добрый день";
            else if (t >= eveningStart && t <= eveningEnd) part = "Добрый вечер";

            if (part == null) return string.Empty;
            return $"{part}, {CurrentUser.FullName}!";
        }
    }
}