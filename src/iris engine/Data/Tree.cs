using System.Collections.Generic;

namespace iris_engine.Data {
    public class Tree {
        public Tree( ) {
            this.Key = "";
            this.Value = "";
            this.child = new List<Tree>();
        }
        public string Key { get; set;}
        public string Value { get; set; }
        public List<Tree> child;
        public Tree Add(string key, string value) {
            Tree tree = new Tree();
            tree.Value = value;
            tree.Key = key;
            this.child.Add(tree);
            return tree;
        }

        public void Add(ProjectHeader ph) {
            Tree tree = ph.getTree();
            this.child.Add(tree);
        }

         static public Tree New(string key,string value ) {
            Tree tree = new Tree();
            tree.Value = value;
            tree.Key = key;
            return tree;
        }

    }
}
