using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iris_engine.Data {

    class Node {
        public NodeDataType DataType { get; set; }
        public List<NodePin> pin { get; set; }
        public NodeData data { get; set; }
        
    }
}
