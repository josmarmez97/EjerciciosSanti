using System;
using System.Web;

namespace CaptchaRequestDynamicSettingsExampleCSharp
{
    public class ValidationCounter
    {
        const string FailedValidationsCountKey = "FailedValidationsCountKey";

        public static int GetFailedValidationsCount()
        {
            int count = 0;
            object saved = HttpContext.Current.Session[FailedValidationsCountKey];
            if (null != saved)
            {
                try
                {
                    count = (int)saved;
                }
                catch (InvalidCastException)
                {
                    // ignore cast errors
                    count = 0;
                }
            }
            return count;
        }

        public static void IncrementFailedValidationsCount()
        {
            int count = GetFailedValidationsCount();
            count++;
            HttpContext.Current.Session[FailedValidationsCountKey] = count;
        }

        public static void ResetFailedValidationsCount()
        {
            HttpContext.Current.Session.Remove(FailedValidationsCountKey);
        }
    }
}