using System;
using System.Collections.Generic;
using System.Text;

namespace Payment.SharedUltilities.Extensions
{
    public static class CollectionExtension
    {
        public static string GetRawData(this SortedList<string, string> requestData)
        {
            StringBuilder data = new StringBuilder();
            foreach (KeyValuePair<string, string> kv in requestData)
            {
                if (!String.IsNullOrEmpty(kv.Value))
                {
                    data.Append(kv.Key + "=" + kv.Value + "&");
                }
            }
            if (data.Length > 0)
            {
                data.Remove(data.Length - 1, 1);
            }
            return data.ToString();
        }

        public static void AddData(this SortedList<string, string> data, string key, string value)
        {
            if (!String.IsNullOrEmpty(value))
            {
                data.Add(key, value);
            }
        }
    }
}
