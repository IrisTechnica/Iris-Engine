using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Xml;
namespace iris_engine.Util {
    using System.Windows;
    using XmlDicionary = Dictionary<string, string>;
    class Xml {
        /// <summary>
        /// Jsonデータを読み込みます
        /// </summary>
        /// <param name="path">パス名</param>
        /// <param name="create">ファイルが存在しない場合、空ファイルを作成します。規定値はtrueです。</param>
        /// <returns>Directionaryオブジェクト</returns>
        static public XmlDicionary Load(string path, bool create = true) {
            var map = new Dictionary<string, string>();

            return map;
        }
        static public bool Store(string path, XmlDicionary map, bool overwrite = true) {




            return true;
        }
    }
}
