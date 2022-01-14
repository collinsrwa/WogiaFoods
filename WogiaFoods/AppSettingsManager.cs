using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Text;

namespace WogiaFoods
{
    public class AppSettingsManager
    {
        //Store instance of the singleton
        private static AppSettingsManager _instance;

        //Store appsettings variables in memory for quick access
        private JObject _secrets;

        //Constants needed to access app settings file
        private const string Namespace = "WogiaFoods";
        private const string Filename = "AppSettings.json";


        //Create instance of the Singleton
        private AppSettingsManager()
        {
            var assembly = IntrospectionExtensions.GetTypeInfo(typeof(AppSettingsManager)).Assembly;
            var stream = assembly.GetManifestResourceStream($"{Namespace}.{Filename}");
            using (var reader= new StreamReader(stream))
            {
                var json = reader.ReadToEnd();
                _secrets = JObject.Parse(json);
            }
        }
        public static AppSettingsManager Settings
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new AppSettingsManager();
                }
                return _instance;
            }
        }
        public string this[string name]
        {
            get
            {
                try
                {
                    var path = name.Split(':');
                    JToken node = _secrets[path[0]];
                    for (int i = 1; i < path.Length; i++)
                    {
                        node = node[path[i]];
                    }
                    return node.ToString();
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"Unable to retrieve secret {name}");
                    return string.Empty;
                }
                
            }
        }
    }
}
