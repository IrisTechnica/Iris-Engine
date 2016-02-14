using NetworkModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;

namespace Data
{
    public class SelectedNode : AbstractModelBase
    {
        #region Internal Static Data Members

        private static SelectedNode instance = new SelectedNode();

        #endregion

        #region Public Static Members

        public static SelectedNode GetInstance()
        {
            return instance;
        }

        #endregion

        #region Internal Data Members

        private AbstractNodeViewModel selectedNode;

        #endregion

        #region Private Members

        private SelectedNode()
        {

        }

        #endregion

        #region Public Members

        public T GetAs<T>()
            where T : AbstractNodeViewModel
        {
            return selectedNode as T;
        }

        public AbstractNodeViewModel Value
        {
            get { return selectedNode; }
            set { this.SetProperty(ref selectedNode, value); }
        }

        #endregion

    }
}
