namespace iris_engine.Data {
    public class ProjectHeader {
        // <summary>
        // 作者名
        // </summary>
        [System.Xml.Serialization.XmlElement("Owner")]
        public string _Owner { get; set; }

        // <summary>
        // エンジンのバージョン
        // </summary>
        [System.Xml.Serialization.XmlElement("EngineVersion")]
        public string _EngineVersion { get; set; }

        // <summary>
        // バージョン(ユーザー指定バージョン)
        // </summary>
        [System.Xml.Serialization.XmlElement("Version")]
        public string _Version { get; set; }

        // <summary>
        // 最終更新 カスタム日時書式指定文字列(yyyy/MM/dd/HH/mm/ss)年/月/日/時/分/秒
        // </summary>
        [System.Xml.Serialization.XmlElement("Time")]
        public string _Time { get; set; }

        // <summary>
        // 開発コード(タイトル)
        // </summary>
        [System.Xml.Serialization.XmlElement("Title")]
        public string _Title { get; set; }

        
        public Tree getTree( ) {
            Tree tree = new Tree();

            tree.Key = "Header";
            {

                tree.Add("EngineVersion", this._EngineVersion);
                tree.Add("Owner", this._Owner);
                tree.Add("Version", this._Version);
                tree.Add("Time", this._Time);
                tree.Add("Title", this._Title);
            }

            return tree;
        }
    }
}
