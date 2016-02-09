using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;
using System.Threading.Tasks;
using System.Runtime.Serialization.Json;

namespace iris_engine.Util
{
    using System.Windows;
    using JsonDictionary = Dictionary<string, string>;

    class Json
    {

        /// <summary>
        /// Jsonデータを読み込みます
        /// </summary>
        /// <param name="path">パス名</param>
        /// <param name="create">ファイルが存在しない場合、空ファイルを作成します。規定値はtrueです。</param>
        /// <returns>Directionaryオブジェクト</returns>
        static public JsonDictionary Load(string path,bool create = true)
        {
            var map = new Dictionary<string, string>();

            try
            {
                var file = new StreamReader(path, Encoding.UTF8);
                var json = file.ReadToEnd();

                XmlDictionaryReader xmlReader = JsonReaderWriterFactory.CreateJsonReader(
                    Encoding.UTF8.GetBytes(json), XmlDictionaryReaderQuotas.Max);


                string key = "";

                while (xmlReader.Read())
                {
                    switch (xmlReader.NodeType)
                    {
                        case XmlNodeType.Element:
                            // Depth = 0(rootノード)はスキップ
                            if (xmlReader.Depth == 0)
                            {
                                break;
                            }

                            // ノード名をmapのキー名にする
                            key = xmlReader.Name;

                            // itemアトリビュートに移動を試みる
                            if (xmlReader.MoveToAttribute("item"))
                            {
                                //移動できたらそこの値をmapのキーとして採用する
                                key = xmlReader.Value;
                            }
                            break;

                        case XmlNodeType.Text:
                            //mapに値を追加
                            map[key] = xmlReader.Value;
                            break;
                    }
                }


            }
            catch (FileNotFoundException e)
            {
                MessageBox.Show(e.FileName + "が見つかりません。", "ファイル読み込みエラー");
            }

            return map;
        }
        static public bool Store(string path,JsonDictionary map,bool overwrite = true)
        {

            MemoryStream stream = new MemoryStream();
            XmlDictionaryWriter xmlWriter = JsonReaderWriterFactory.CreateJsonWriter(stream);

            // 取得したXmlDictionaryWriterに対して、xmlを構築
            xmlWriter.WriteStartDocument();
            xmlWriter.WriteStartElement("root");
            xmlWriter.WriteAttributeString("type", "object");

            // mapのkeyをタグ名、valueを値としてnodeを作成
            foreach (KeyValuePair<string, string> pair in map)
            {

                // mapのキー名でタグを作成
                xmlWriter.WriteStartElement(pair.Key);
                // これはなくてもOKだった
                //xmlWriter.WriteAttributeString("type", "string");
                xmlWriter.WriteValue(pair.Value);
                xmlWriter.WriteEndElement();

            }

            // rootノードの閉じタグ
            xmlWriter.WriteEndElement();

            xmlWriter.Flush();

            // JSON形式の文字列を得る
            stream.Position = 0;

            // 上書きしない場合は存在チェック
            if(!overwrite)
            {
                if (File.Exists(path))
                    MessageBox.Show("指定したファイル[" + path + "]は既に存在します。", "ファイル書き込みエラー");
                return false;
            }

            // 書き込み
            var writer = new StreamWriter(path);
            writer.Write(new StreamReader(stream).ReadToEnd());

            return true;
        }
    }
}
