using iris_engine.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace iris_engine.Statistics
{
    [OnStartupSingletonInitialize]
    public class ProcessorInfomation
    {
        public class Processor
        {
            //コア数
            public int NumberOfCores { get; set; }

            //論理CPU数
            public int NumberOfLogicalProcessors { get; set; }

        }

        private static ProcessorInfomation instance  = null;

        public static ProcessorInfomation GetInstance()
        {
            if(instance == null)
            {
                instance = new ProcessorInfomation();
                instance.InitInfo();
            }
            return instance;
        }

        private List<Processor> processors = null;

        private ProcessorInfomation()
        {
        }

        public List<Processor> Processors
        {
            get
            {
                if (processors == null) processors = new List<Processor>();
                return processors;
            }

            set
            {
                processors = value;
            }
        }

        public void InitInfo()
        {
            ManagementClass mc = new ManagementClass("Win32_Processor");
            ManagementObjectCollection moc = mc.GetInstances();

            foreach (ManagementObject mo in moc)
            {
                int core = Convert.ToInt32(mo.GetPropertyValue("NumberOfCores"));
                int logProc = Convert.ToInt32(mo.GetPropertyValue("NumberOfLogicalProcessors"));
                this.processors.Add(new Processor() { NumberOfCores = core, NumberOfLogicalProcessors = logProc });
            }
        }

        public Processor this[int index]
        {
            get { return processors[index]; }
        }


    }
}
