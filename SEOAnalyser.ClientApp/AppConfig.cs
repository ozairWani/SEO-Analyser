using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace SEOAnalyser.ClientApp
{
    public static class AppConfig
    {

        public static string AnalyserApiURL
        {
            get
            {
                return string.Concat((string)GetAppSetting(typeof(string), "apibaseUri"), (string)GetAppSetting(typeof(string), "api_part"));
            }
        }

        public static string BaseUri
        {
            get
            {
                return (string)GetAppSetting(typeof(string), "apibaseUri");
            }
        }

        public static string URIPart
        {
            get
            {
                return (string)GetAppSetting(typeof(string), "api_part");
            }
        }

        private static object GetAppSetting(Type expectedType, string key)
        {
            string value = ConfigurationManager.AppSettings.Get(key);
            try
            {
                if (expectedType == typeof(int))
                    return int.Parse(value);
                if (expectedType == typeof(string))
                    return value;

                throw new Exception("Type not supported.");
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Config key:{0} was expected to be of type {1} but was not.",
                    key, expectedType), ex);
            }
        }
    }
}