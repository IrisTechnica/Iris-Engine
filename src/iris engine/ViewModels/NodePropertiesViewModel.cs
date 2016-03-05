using Data;
using NetworkModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Utils;

namespace iris_engine.ViewModels
{
    public class NodePropertiesViewModel : AbstractModelBase
    {

        protected T GetAs<T>()
            where T : AbstractNodeViewModel
        {
            return SelectedNode.GetInstance().GetAs<T>();
        }

        #region Private Members


        /// Raise Notifycate for all properties
        private void SelectedNode_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if(e.PropertyName == nameof(SelectedNode.Value))
            {
                var thisType = this.GetType();
                var propertList = thisType.GetProperties(BindingFlags.Public | BindingFlags.Instance);
                foreach(var property in propertList)
                {
                    this.Raise(property.Name);
                }
            }
        }

        #endregion

        public NodePropertiesViewModel()
        {
            SelectedNode.GetInstance().PropertyChanged += SelectedNode_PropertyChanged;
        }

        #region InOut Public Properties

        public string NodeName
        {
            get
            {
                return GetAs<AbstractNodeViewModel>()?.Name;
            }

            set
            {
                var viewmodel = GetAs<AbstractNodeViewModel>();
                if (viewmodel != null)
                {
                    viewmodel.Name = value;
                    Raise();
                }

            }
        }

        #endregion

        #region ReadOnly Properties

        public bool NotSelected
        {
            get { return GetAs<AbstractNodeViewModel>() == null; }
        }

        public bool AnySelected
        {
            get { return !NotSelected; }
        }

        public bool IsConstantNode
        {
            get { return GetAs<ConstantFloatNodeViewModel>() != null; }
        }

        #endregion

    }
}
