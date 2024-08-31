namespace Labb_1___Avancerad_fullstackutveckling.Helpers
{
    public class Helper
    {
        public static DateTime DateTimeCleanUp(DateTime dateTime)
        {
            return dateTime.Date.AddHours(dateTime.Hour).AddMinutes(dateTime.Minute);
        }
    }
}
