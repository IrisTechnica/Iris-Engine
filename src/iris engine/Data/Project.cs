using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml;
using System.Windows;

namespace iris_engine.Data {

    [System.Xml.Serialization.XmlRoot("root")]
    public class Project {

        private string _filePath;
        public string FilePath
        {
            get
            {
                return _filePath;
            }

        }

        Tree tree;

        [System.Xml.Serialization.XmlElement("Header")]
        public ProjectHeader _ProjectHeader { get; set; }

        public ProjectHeader Header { get { return this._ProjectHeader; } set { this._ProjectHeader = value; } }
        //public List<Project>
        public Project( ) {
            this.tree = new Tree();
        }
        public bool Load(string path) {
            this._filePath = path;
            try {
                System.IO.FileStream fs = new System.IO.FileStream(path, System.IO.FileMode.Open);
                System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(Project));
                Project xml = (Project)serializer.Deserialize(fs);
                this._ProjectHeader = xml._ProjectHeader;
                this.tree.Add(this._ProjectHeader);
                fs.Close();
            } catch ( FileNotFoundException e ) {
                MessageBox.Show(e.FileName + "が見つかりません。", "ファイル読み込みエラー");
            }
            return true;
        }
        public bool Store(string path) {
            
            System.IO.FileStream stream = new System.IO.FileStream(path, System.IO.FileMode.Create);
            System.IO.StreamWriter writer = new System.IO.StreamWriter(stream, System.Text.Encoding.UTF8);

            //シリアライズ
            System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(Project));
            serializer.Serialize(writer, this);

            writer.Flush();
            writer.Close();

            return true;
        }
        
    }
}
