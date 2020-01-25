using System;
using System.Collections.Generic;
using System.Text;
using static System.String;

namespace Prontuario.Service.Adapters
{
    public static class DataAdapter
    {
        public static DateTime ParseDateTime(string data)
        {
            return IsNullOrEmpty(data) ? default : DateTime.ParseExact(data, "dd-MM-yyyy HH:mm:ss", null);
        }

        public static DateTime ParseDate(string data)
        {
            return IsNullOrEmpty(data) ? default : DateTime.ParseExact(data, "dd-MM-yyyy", null);
        }

        public static DateTime ParseTime(string data)
        {
            return IsNullOrEmpty(data) ? default : DateTime.ParseExact(data, "HH:mm:ss", null);
        }
    }
}
