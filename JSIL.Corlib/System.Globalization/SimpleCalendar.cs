using System;
using System.Collections.Generic;
using System.Text;

namespace System.Globalization
{
    class SimpleCalendar
    {
        /// <summary>
        /// The era number for the Common Era (C.E.) or Anno Domini (A.D.)
        /// respective.
        /// </summary>
        public const int ADEra = 1;

        /// <value>Overridden. Gives the eras supported by the Gregorian
        /// calendar as an array of integers.
        /// </value>
        public override int[] Eras
        {
            get
            {
                return new int[] { ADEra };
            }
        }

        public int GetDayOfMonth(DateTime dt)
        {
            return CCGregorianCalendar.GetDayOfMonth(dt);
        }

        public DayOfWeek GetDayOfWeek(DateTime dt)
        {
            return CCGregorianCalendar.GetDayOfWeek(dt);
        }

        internal int GetEra(DateTime dt)
        {
            return ADEra;
        }

        internal int GetYear(DateTime dt)
        {
            throw new NotImplementedException();
        }
    }
}
