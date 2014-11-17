using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using TransaqModelComponent.Infrastructure;

namespace TransaqModelComponent.Helpers
{
    public static class StringHelper
    {
        public static T ToObject<T>(this string textXML)
        {
            if (String.IsNullOrEmpty(textXML))
                throw new TransaqConnectorException();

            using (var stringReader = new StringReader(textXML))
            using (var xmlReader = new XmlTextReader(stringReader))
            {
                /*Type typeElement = typeof(T);

                XmlRootAttribute xRoot = new XmlRootAttribute();
                xRoot.ElementName = typeElement.Name.ToLower();
                xRoot.Namespace = String.Empty;
                xRoot.IsNullable = true;*/

                var serializer = new XmlSerializer(typeof(T));
                var obj = (T)serializer.Deserialize(xmlReader);

                return obj;
            }
        }

        public static string ToXml<T>(this T obj) where T : class
        {
            using (var memoryStream = new MemoryStream())
            using (var xmlWriter = new XmlTextWriter(memoryStream, Encoding.UTF8) { Namespaces = true })
            {
                var xmlNamespace = new XmlSerializerNamespaces();

                // Add an empty namespace and empty value
                xmlNamespace.Add(String.Empty, String.Empty);

                var serializer = new XmlSerializer(typeof(T));

                serializer.Serialize(xmlWriter, obj, xmlNamespace);

                string xml = Encoding.UTF8.GetString(memoryStream.GetBuffer());
                xml = xml.Substring(xml.IndexOf(Convert.ToChar(60)));
                xml = xml.Substring(0, (xml.LastIndexOf(Convert.ToChar(62)) + 1));

                return xml;
            }
        }
    }
}
