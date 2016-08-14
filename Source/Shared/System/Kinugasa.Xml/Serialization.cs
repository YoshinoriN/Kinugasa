using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace Kinugasa.Xml
{
    /// <summary>
    /// This class is provide serialization of xml.
    /// </summary>
    public class Serialization
    {
        /// <summary>
        /// Serialize class instance to xml.
        /// </summary>
        /// <typeparam name="T">Type of class.</typeparam>
        /// <param name="T1">Class of instance.</param>
        /// <param name="path">xml file's path.</param>
        public static void Serialize<T>(T T1, string path)
        {
            var xmlSerializer = new XmlSerializer(T1.GetType());

            var settings = new XmlWriterSettings();
            settings.OmitXmlDeclaration = true;
            settings.Indent = true;

            using (var writer = XmlWriter.Create(path, settings))
            {
                xmlSerializer.Serialize(writer, T1);
            }
        }

        /// <summary>
        /// Deserialize xml to class instance.
        /// </summary>
        /// <typeparam name="T">Type of class.</typeparam>
        /// <param name="path">xml file's path.</param>
        /// <returns>Class instance, after desialize.</returns>
        public static T Deserialize<T>(T T1, string path)
            where T : class
        {
            if (!System.IO.File.Exists(path))
            {
                throw new FileNotFoundException("The file doesn't exitst.");
            }

            using (var fs = new FileStream(path, FileMode.Open))
            {
                var serializer = new XmlSerializer(T1.GetType());
                T obj = serializer.Deserialize(fs) as T;
                return obj;
            }
        }
    }
}
