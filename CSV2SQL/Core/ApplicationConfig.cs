using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CSV2SQL.Core
{
    [XmlRoot("config")]
    public class ApplicationConfig
    {
        private const string DEF_SEPARATOR = ";";
        private const string DEF_SCHEMA = "dbo";

        public static ApplicationConfig Instance;

        [XmlElement("DefaultSeparator")]
        public string DefaultSeparator { get; set; }

        [XmlElement("DefaultSchema")]
        public string DefaultSchema { get; set; }

        [XmlElement("FirstTimeOpen")]
        public bool FirstTimeOpen { get; set; }

        [XmlElement("ShowOptions")]
        public bool ShowOptions { get; set; }

        [XmlElement("ShowSchema")]
        public bool ShowSchema { get; set; }

        [XmlElement("connection")]
        public List<ConfigDBConnection> Connections { get; set; }

        [XmlElement("ChangeTableNameForSameFile")]
        public bool ChangeTableNameForSameFile { get; set; } = false;

        [XmlElement("PreviewRowCount")]
        public int PreviewRowCount { get; set; } = 100;

        public ApplicationConfig()
        {
            DefaultSchema = DEF_SCHEMA;
            DefaultSeparator = DEF_SEPARATOR;
            Connections = new List<ConfigDBConnection>();
        }

        public static void Initialize()
        {
            bool isFileCreated = false;

            // Create configuration file if not exists
            if (!File.Exists(CSV2SQL.Properties.Resources.ConfigurationFileName))
            {
                isFileCreated = true;
                File.Create(CSV2SQL.Properties.Resources.ConfigurationFileName).Close();
            }

            XmlSerializer serializer = new XmlSerializer(typeof(ApplicationConfig));
            try
            {
                using (TextReader reader = new StringReader(File.ReadAllText(CSV2SQL.Properties.Resources.ConfigurationFileName)))
                {
                    Instance = (ApplicationConfig)serializer.Deserialize(reader);
                    Instance.FirstTimeOpen = isFileCreated;
                };
            }
            catch {
                Instance = new ApplicationConfig()
                {
                    Connections = new List<ConfigDBConnection>(),
                    FirstTimeOpen = isFileCreated
                };
            }
        }

        public static void Save()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ApplicationConfig));
            using (var writer = new StreamWriter(CSV2SQL.Properties.Resources.ConfigurationFileName))
            {   
                serializer.Serialize(writer, Instance);
            }
        }
    }

    public class ConfigDBConnection
    {
        [XmlElement("server")]
        public string Server { get; set; }
        [XmlElement("database")]
        public string Database { get; set; }
        [XmlElement("method")]
        public Enums.AuthenticationMethod AuthenticationMethod { get; set; }
        [XmlElement("user")]
        public string UserName { get; set; }
        [XmlElement("password")]
        public string Password { get; set; }

        public DatabaseConnection Connection
        {
            get
            {
                return new DatabaseConnection(Server, Database, AuthenticationMethod)
                {
                    UserName = UserName,
                    Password = Security.SecurityHelper.StringToSecureString(Password)
                };
            }
        }
    }
}
