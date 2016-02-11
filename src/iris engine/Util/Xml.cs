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
        static public XmlDicionary Load(string path,bool create = true) {
            var map = new Dictionary<string, string>();
            try {
            } catch ( FileNotFoundException e ) {
                MessageBox.Show(e.FileName + "が見つかりません。", "ファイル読み込みエラー");
            }
            return map;
        }
        static public bool Store(string path ,XmlDicionary map,bool overwrite = true) {



            return true;
        }
    }
}
