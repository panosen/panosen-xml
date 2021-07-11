using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Panosen.Xml
{
    /// <summary>
    /// Xml转换器
    /// </summary>
    public static class XmlConvert
    {
        /// <summary>
        /// 将序列化的字符串解析成对应的对象
        /// </summary>
        /// <typeparam name="T">目标对象类型</typeparam>
        /// <param name="xml">要解析的字符串</param>
        /// <returns>解析结果</returns>
        public static T DeserializeObject<T>(string xml)
        {
            if (string.IsNullOrEmpty(xml))
            {
                throw new ArgumentNullException(nameof(xml));
            }

            byte[] bytes = Encoding.UTF8.GetBytes(xml);

            using (MemoryStream stream = new MemoryStream(bytes))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));

                return (T)serializer.Deserialize(stream);
            }
        }

        /// <summary>
        /// 将对象转换成相应的Xml序列化后的字符串
        /// </summary>
        /// <param name="obj">要转换的对象</param>
        /// <exception cref="System.ArgumentNullException">参数为空</exception>
        /// <exception cref="System.InvalidOperationException">非法操作</exception>
        /// <returns>转换后的Xml字符串</returns>
        public static string SerializeObject(object obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj));
            }

            XmlWriterSettings settings = new XmlWriterSettings
            {
                Encoding = Encoding.UTF8
            };

            using (MemoryStream stream = new MemoryStream())
            {
                using (XmlWriter xmlWriter = XmlWriter.Create(stream, settings))
                {
                    XmlSerializer serializer = new XmlSerializer(obj.GetType());

                    serializer.Serialize(xmlWriter, obj);

                    return Encoding.UTF8.GetString(stream.GetBuffer());
                }
            }
        }
    }
}
