using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Web;

namespace Payment.SharedUltilities.Extensions
{
    public static class ObjectExtension
    {
        public static Dictionary<string, string> ToDictionaryStringString(this object obj)
        {
            if (obj != null)
            {
                Dictionary<string, string> result = new Dictionary<string, string>();
                PropertyInfo[] props = obj.GetType().GetProperties();
                foreach (var prop in props)
                {
                    if (!string.IsNullOrEmpty(prop.GetValue(obj)?.ToString()))
                    {
                        result.Add(prop.Name, prop.GetValue(obj).ToString());
                    }
                }
                return result;
            }
            return null;
        }
        public static string ToQueryStringData(this object obj)
        {
            if (obj != null)
            {
                var data = obj.ToDictionaryStringString();
                if(data != null)
                {
                    StringBuilder query = new StringBuilder();
                    foreach (KeyValuePair<string, string> kv in data)
                    {
                        if (!String.IsNullOrEmpty(kv.Value))
                        {
                            query.Append(kv.Key + "=" + HttpUtility.UrlEncode(kv.Value) + "&");
                        }
                    }
                    return query.ToString();
                }
            }
            return string.Empty;

        }
        public static string ToQueryStringRawData(this object obj)
        {
            if(obj != null)
            {
                var data = obj.ToDictionaryStringString();
                StringBuilder query = new StringBuilder();
                foreach (KeyValuePair<string, string> kv in data)
                {
                    if (!String.IsNullOrEmpty(kv.Value))
                    {
                        query.Append(kv.Key + "=" + kv.Value + "&");
                    }
                }
                if (query.Length > 0)
                {
                    query.Remove(query.Length - 1, 1);
                }
                return query.ToString();
            }
            return string.Empty;
        }
        public static SortedList<string, string> ToSortedList(this object obj, IComparer<string> comparer)
        {
            SortedList<string, string> result = new SortedList<string, string>(comparer);
            var dictionary = obj.ToDictionaryStringString();

            foreach(var key in dictionary.Keys)
            {
                result.Add(key, dictionary[key]);
            }

            return result;
        }
    }
}
