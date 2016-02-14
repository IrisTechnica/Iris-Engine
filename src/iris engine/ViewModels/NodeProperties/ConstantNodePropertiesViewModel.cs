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
        public float? Entity
        {
            get
            {
                return GetAs<ConstantNodeViewModel>()?.Outputs.ConstantValue.Entity; 
            }
            set
            {
                var viewmodel = GetAs<ConstantNodeViewModel>();
                if(viewmodel != null)
                {
                    viewmodel.Outputs.ConstantValue.Entity = value.GetValueOrDefault();
                    Raise();
                }
            }
        }
    }
}
