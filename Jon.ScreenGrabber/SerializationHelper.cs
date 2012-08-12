using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace Jon.ScreenGrabber
{
    abstract class SerializationHelper
    {

        public static T DeserializeFromXMLDoc<T>(string filePath) where T: new()
        {
            if (!File.Exists(filePath)) return new T();

            using (var sr = new StreamReader(filePath))
            {
                var ser = new XmlSerializer(typeof(T));
                return (T)ser.Deserialize(sr);                
            }
        }

        public static void SerializeToXMLDoc<T>(string filePath, T input) 
        {
            using (var sw = new StreamWriter(filePath, append: false))
            {
                var ser = new XmlSerializer(typeof(T));
                ser.Serialize(sw,input);
            }
        }

        public void ListFiles(string fileName, string path) 
        {
            using (var sw = new StreamWriter(fileName)) 
            {
                foreach (FileInfo fi in (new DirectoryInfo(path).GetFiles()))
                {
                    sw.WriteLine(fi.Name);
                    sw.WriteLine(Path.GetFileNameWithoutExtension(fi.Name));
                }
            }
        }


          
    }
}
