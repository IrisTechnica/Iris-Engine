using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iris_engine.Managers
{
    public class CodeGeneratorManager
    {
        private static CodeGeneratorManager instance = new CodeGeneratorManager();

        private CodeGeneratorManager()
        {

        }

        public static CodeGeneratorManager GetInstance()
        {
            return instance;
        }
        
    }
}
