using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using System.Xml;

namespace iris_engine.Serializer
{
    /// <summary>設定情報を XML で出力する機能を提供します。</summary>
    /// <typeparam name="T">シリアライズするクラスの型。</typeparam>
    public class PortableSettingsXmlSerializer<T> : IPortableSettingsSerializer<T>
        where T : class
    {
        #region Members

        /// <summary>PortableSettingsXmlSerializer クラスの新しいインスタンスを作成します。</summary>
        public PortableSettingsXmlSerializer()
        {
            XmlWriterSettings = new XmlWriterSettings { Indent = true };
            KnownTypes = new List<Type>();
            MaxItemsInObjectGraph = Int32.MaxValue;
            IgnoreExtensionDataObject = true;
        }

        /// <summary>XML の出力形式を制御するために使用するコンポーネントを取得または設定します。</summary>
        public XmlWriterSettings XmlWriterSettings { get; set; }

        /// <summary>既知のコントラクト型に xsi:type 宣言を動的にマップするのに使用するコンポーネントを取得または設定します。</summary>
        public DataContractResolver DataContractResolver { get; set; }

        /// <summary>シリアル化または逆シリアル化プロセスを拡張できるサロゲート型を取得または設定します。</summary>
        public IDataContractSurrogate DataContractSurrogate { get; set; }

        /// <summary>クラスがシリアル化または逆シリアル化されるときに、そのクラスの拡張により提供されるデータを無視するかどうかを指定する値を取得または設定します。</summary>
        public bool IgnoreExtensionDataObject { get; set; }

        /// <summary>DataContractSerializer のこのインスタンスを使用してシリアル化されるオブジェクト グラフ内に存在可能な型のコレクションを取得します。</summary>
        public IList<Type> KnownTypes { get; private set; }

        /// <summary>シリアル化または逆シリアル化するオブジェクト グラフ内の項目の最大数を取得または設定します。</summary>
        public int MaxItemsInObjectGraph { get; set; }

        /// <summary>オブジェクトの参照データを保持するために非標準の XML コンストラクトを使用するかどうかを示す値を取得または設定します。</summary>
        public bool PreserveObjectReferences { get; set; }

        /// <summary>指定のインスタンスを保存します。</summary>
        /// <param name="path">シリアライズした内容を保存するパス。</param>
        /// <param name="instance">シリアライズする対象のインスタンス。</param>
        public void Serialize(string path, T instance)
        {
            var serializer = GetSerializer();
            using (MemoryStream stream = new MemoryStream())
            using (var writer = XmlWriter.Create(stream, XmlWriterSettings))
            {
                serializer.WriteObject(writer, instance);
                writer.Flush();
                string json = Encoding.UTF8.GetString(stream.ToArray());
                Directory.CreateDirectory(Path.GetDirectoryName(path));
                File.WriteAllText(path, json);
            }
        }

        /// <summary>指定のパスからインスタンスを取得します。</summary>
        /// <param name="path">デシリアライズする内容を読み込むパス。</param>
        /// <returns>デシリアライズしたインスタンス。</returns>
        public T Desilialize(string path)
        {
            if (File.Exists(path) == false)
            {
                return null;
            }

            var serializer = GetSerializer();
            byte[] bytes = Encoding.UTF8.GetBytes(File.ReadAllText(path, Encoding.UTF8));
            using (var stream = new MemoryStream(bytes))
            {
                return (T)serializer.ReadObject(stream);
            }
        }

        /// <summary>シリアライザのインスタンスを取得します。</summary>
        /// <returns>取得したシリアライザのインスタンス。</returns>
        private DataContractSerializer GetSerializer()
        {
            return new DataContractSerializer(typeof(T), KnownTypes, MaxItemsInObjectGraph, IgnoreExtensionDataObject, PreserveObjectReferences, DataContractSurrogate, DataContractResolver);
        }

        #endregion
    }
}
