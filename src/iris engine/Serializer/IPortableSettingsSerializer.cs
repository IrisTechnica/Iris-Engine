using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Xml;


namespace iris_engine.Serializer
{
    /// <summary>設定情報を XML で出力する機能を提供します。</summary>
    /// <typeparam name="T">シリアライズするクラスの型。</typeparam>
    public interface IPortableSettingsSerializer<T>
        where T : class
    {
        /// <summary>指定のインスタンスを保存します。</summary>
        /// <param name="path">シリアライズした内容を保存するパス。</param>
        /// <param name="instance">シリアライズする対象のインスタンス。</param>
        void Serialize(string path, T instance);

        /// <summary>指定のパスからインスタンスを取得します。</summary>
        /// <param name="path">デシリアライズする内容を読み込むパス。</param>
        /// <returns>デシリアライズしたインスタンス。</returns>
        T Desilialize(string path);
    }

}
