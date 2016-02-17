using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;

namespace iris_engine.Serializer
{
    /// <summary>設定情報を JSON で出力する機能を提供します。</summary>
    /// <typeparam name="T">シリアライズするクラスの型。</typeparam>
    public class PortableSettingsJsonSerializer<T> : IPortableSettingsSerializer<T>
        where T : class
    {
        #region Members

        /// <summary>PortableSettingsJsonSerializer クラスの新しいインスタンスを作成します。</summary>
        public PortableSettingsJsonSerializer()
        {
            KnownTypes = new List<Type>();
            MaxItemsInObjectGraph = Int32.MaxValue;
        }

        /// <summary>指定した IDataContractSurrogate インスタンスで現在アクティブなサロゲート型を取得または設定します。サロゲートは、シリアル化または逆シリアル化プロセスを拡張できます。</summary>
        public IDataContractSurrogate DataContractSurrogate { get; set; }

        /// <summary>逆シリアル化時に未知のデータを無視するかどうか、およびシリアル化時に IExtensibleDataObject インターフェイスを無視するかどうかを指定する値を取得または設定します。</summary>
        public bool IgnoreExtensionDataObject { get; set; }

        /// <summary>DataContractJsonSerializer のこのインスタンスを使用してシリアル化されるオブジェクト グラフ内に存在可能な型のコレクションを取得します。</summary>
        public IList<Type> KnownTypes { get; private set; }

        /// <summary>シリアライザーが 1 回の読み取りまたは書き込みの呼び出しでシリアル化または逆シリアル化するオブジェクト グラフ内の項目の最大数を取得または設定します。</summary>
        public int MaxItemsInObjectGraph { get; set; }

        /// <summary>型情報を出力するかどうかを指定する値を取得または設定します。</summary>
        public bool AlwaysEmitTypeInformation { get; set; }

        /// <summary>指定のインスタンスを保存します。</summary>
        /// <param name="path">シリアライズした内容を保存するパス。</param>
        /// <param name="instance">シリアライズする対象のインスタンス。</param>
        public void Serialize(string path, T instance)
        {
            var serializer = GetSerializer();
            using (MemoryStream ms = new MemoryStream())
            {
                serializer.WriteObject(ms, instance);
                string json = Encoding.UTF8.GetString(ms.ToArray());
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
        private DataContractJsonSerializer GetSerializer()
        {
            return new DataContractJsonSerializer(typeof(T), KnownTypes, MaxItemsInObjectGraph, IgnoreExtensionDataObject, DataContractSurrogate, AlwaysEmitTypeInformation);
        }

        #endregion
    }
}
