using PluginInterface;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace MDIPaint
{
    [Serializable]
    public class PluginConfig
    {
        public bool AutoLoad { get; set; } = true;
        public List<PluginInfo> Plugins { get; set; } = new List<PluginInfo>();

        public static PluginConfig Load(string path)
        {
            if (!File.Exists(path))
            {
                var config = new PluginConfig();
                config.Save(path);
                return config;
            }

            try
            {
                var serializer = new XmlSerializer(typeof(PluginConfig));
                using (var reader = new StreamReader(path))
                {
                    return (PluginConfig)serializer.Deserialize(reader);
                }
            }
            catch
            {
                return new PluginConfig();
            }
        }

        public void Save(string path)
        {
            var serializer = new XmlSerializer(typeof(PluginConfig));
            using (var writer = new StreamWriter(path))
            {
                serializer.Serialize(writer, this);
            }
        }
    }

    [Serializable]
    public class PluginInfo
    {
        public string Name { get; set; }
        public string Author { get; set; }
        public string Version { get; set; }
        public string Path { get; set; }
        public bool Enabled { get; set; }
    }
}
