using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.CodeDom;
using System.CodeDom.Compiler;
using Microsoft.CSharp;

namespace iris_engine.Generator
{
    class Generator
    {
        private CodeCompileUnit compileUnit = new CodeCompileUnit();
        private CSharpCodeProvider codeProvider = new CSharpCodeProvider();
        private CodeGeneratorOptions generatorOpitons = new CodeGeneratorOptions();
    }
}
