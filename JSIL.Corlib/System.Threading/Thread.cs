
using System.Globalization;
using System;
namespace System.Threading
{
    public class Thread
    {
        static Thread()
        {
            CurrentThread = new Thread();
        }

        public static Thread CurrentThread { get; set; }

        private CultureInfo current_culture;
        public CultureInfo CurrentCulture
        {
            get
            {
                CultureInfo culture = current_culture;
                if (culture != null)
                    return culture;

                current_culture = culture = CultureInfo.ConstructCurrentCulture();
                NumberFormatter.SetThreadCurrentCulture(culture);
                return culture;
            }
        }

        public int ManagedThreadId
        {
            get { return 0; } 
        }

        public CultureInfo CurrentUICulture
        {
            get { return CurrentCulture; }
        }
    }
}
