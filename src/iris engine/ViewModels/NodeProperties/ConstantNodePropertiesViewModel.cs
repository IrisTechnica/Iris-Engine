using NetworkModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iris_engine.ViewModels
{
    public class ConstantNodePropertiesViewModel : NodePropertiesViewModel
    {
        public float Entity
        {
            get
            {
                var viewmodel = GetAs<ConstantNodeViewModel>();
                if (viewmodel != null)
                    return viewmodel.Outputs.ConstantValue.Entity;
                return 0;
            }
            set
            {
                var viewmodel = GetAs<ConstantNodeViewModel>();
                if(viewmodel != null)
                {
                    viewmodel.Outputs.ConstantValue.Entity = value;
                    Raise();
                }
            }
        }
    }
}
