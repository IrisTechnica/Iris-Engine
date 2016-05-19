using iris_engine.IO;
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

        private NotificationMemoryStream memory = null;

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
            }
            set
            {
                Memory.SetLength(0);
                Writer.Write(value);
                this.OnPropertyChanged(nameof(LogText));
            }
        }

        public StreamWriter Writer
        {
            get
            {
                if (writer == null)
                {
                    writer = new StreamWriter(Memory);
                    writer.AutoFlush = true;
                }
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

        public NotificationMemoryStream Memory
        {
            get
            {
                if (memory == null)
                {
                    memory = new NotificationMemoryStream();
                    memory.WriteCompleted += (sender,e) => { this.OnPropertyChanged(nameof(LogText)); };
                }
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
