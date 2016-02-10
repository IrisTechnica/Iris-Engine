using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iris_engine.Data {

    class Node {
        public NodeData data { get; set; }
        private List<NodeDataType> _dataType{get;set;}
    }
}
