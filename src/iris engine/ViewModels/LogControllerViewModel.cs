using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using Utils;

namespace iris_engine.ViewModels
{
    public class LogControllerViewModel : AbstractModelBase
    {
        public class InternalFormat
        {
            public DependencyProperty textElementProperty;
            public object value;

            public InternalFormat(DependencyProperty prop,object value)
            {
                textElementProperty = prop;
                this.value = value;
            }
        }

        private Dictionary<String, List<InternalFormat>> regexTextFormats = null;

        private string logText = null;

        private MemoryStream memory = null;

        private StreamWriter writer = null;

        private StreamReader reader = null;

        internal Dictionary<String, List<InternalFormat>> RegexTextFormats
        {
            get
            {
                if (regexTextFormats == null) regexTextFormats = new Dictionary<String, List<InternalFormat>>();
                return regexTextFormats;
            }

            set
            {
                regexTextFormats = value;
            }
        }

        public string LogText
        {
            get
            {
                Memory.Position = 0;
                var text = Reader.ReadToEnd();
                Memory.Position = Memory.Length;
                return text;
                //if (logText == null) logText = "";
                //return logText;
            }
            set
            {
                this.SetProperty(ref logText, value);
            }
        }

        public StreamWriter Writer
        {
            get
            {
                if (writer == null) writer = new StreamWriter(Memory);
                return writer;
            }

            set
            {
                this.SetProperty(ref writer ,value);
            }
        }

        public StreamReader Reader
        {
            get
            {
                if (reader == null) reader = new StreamReader(Memory);
                return reader;
            }

            set
            {
                reader = value;
            }
        }

        public MemoryStream Memory
        {
            get
            {
                if (memory == null) memory = new MemoryStream();
                this.Raise();
                return memory;
            }

            set
            {
                this.SetProperty(ref memory, value);
            }
        }

        public LogControllerViewModel()
        {
        }
    }
}
