using iris_engine.ViewModels;
using NetworkModel;
using NetworkUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace iris_engine.Controls
{
    /// <summary>
    /// NodeController.xaml の相互作用ロジック
    /// </summary>
    public partial class NodeController : UserControl
    {

        public NodeController()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Convenient accessor for the view-model.
        /// </summary>
        public NodeControllerViewModel ViewModel
        {
            get
            {
                return (NodeControllerViewModel)DataContext;
            }
        }

        private void NodeController_Loaded(object sender, RoutedEventArgs e)
        {
        }

        /// <summary>
        /// Event raised when the user has started to drag out a connection.
        /// </summary>
        private void networkControl_ConnectionDragStarted(object sender, ConnectionDragStartedEventArgs e)
        {
            var draggedOutConnector = (ConnectorViewModel)e.ConnectorDraggedOut;
            var curDragPoint = Mouse.GetPosition(networkControl);

            //
            // Delegate the real work to the view model.
            //
            var connection = this.ViewModel.ConnectionDragStarted(draggedOutConnector, curDragPoint);

            //
            // Must return the view-model object that represents the connection via the event args.
            // This is so that NetworkView can keep track of the object while it is being dragged.
            //
            e.Connection = connection;
        }

        /// <summary>
        /// Event raised, to query for feedback, while the user is dragging a connection.
        /// </summary>
        private void networkControl_QueryConnectionFeedback(object sender, QueryConnectionFeedbackEventArgs e)
        {
            var draggedOutConnector = (ConnectorViewModel)e.ConnectorDraggedOut;
            var draggedOverConnector = (ConnectorViewModel)e.DraggedOverConnector;
            object feedbackIndicator = null;
            bool connectionOk = true;

            this.ViewModel.QueryConnnectionFeedback(draggedOutConnector, draggedOverConnector, out feedbackIndicator, out connectionOk);

            //
            // Return the feedback object to NetworkView.
            // The object combined with the data-template for it will be used to create a 'feedback icon' to
            // display (in an adorner) to the user.
            //
            e.FeedbackIndicator = feedbackIndicator;

            //
            // Let NetworkView know if the connection is ok or not ok.
            //
            e.ConnectionOk = connectionOk;
        }

        /// <summary>
        /// Event raised while the user is dragging a connection.
        /// </summary>
        private void networkControl_ConnectionDragging(object sender, ConnectionDraggingEventArgs e)
        {
            Point curDragPoint = Mouse.GetPosition(networkControl);
            var connection = (ConnectionViewModel)e.Connection;
            this.ViewModel.ConnectionDragging(curDragPoint, connection);
        }

        /// <summary>
        /// Event raised when the user has finished dragging out a connection.
        /// </summary>
        private void networkControl_ConnectionDragCompleted(object sender, ConnectionDragCompletedEventArgs e)
        {
            var connectorDraggedOut = (ConnectorViewModel)e.ConnectorDraggedOut;
            var connectorDraggedOver = (ConnectorViewModel)e.ConnectorDraggedOver;
            var newConnection = (ConnectionViewModel)e.Connection;
            this.ViewModel.ConnectionDragCompleted(newConnection, connectorDraggedOut, connectorDraggedOver);
        }

        /// <summary>
        /// Event raised to delete the selected node.
        /// </summary>
        private void DeleteSelectedNodes_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            this.ViewModel.DeleteSelectedNodes();
        }

        #region Create New Node Methods

        private void CreateUVNode_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            CreateNode<UVNodeViewModel>();
        }
        //--------------Boolean--------------//
        private void CreateConstantBooleanNode_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            CreateNode<ConstantBooleanNodeViewModel>();
        }
        private void CreateViewBooleanNode_Executed(object sender, ExecutedRoutedEventArgs e) {
            CreateNode<ViewBooleanNodeViewModel>();
        }
        private void CreateAndBooleanNode_Executed(object sender, ExecutedRoutedEventArgs e) {
            CreateNode<AndBooleanNodeViewModel>();
        }
        private void CreateNotBooleanNode_Executed(object sender, ExecutedRoutedEventArgs e) {
            CreateNode<NotBooleanNodeViewModel>();
        }
        private void CreateOrBooleanNode_Executed(object sender, ExecutedRoutedEventArgs e) {
            CreateNode<OrBooleanNodeViewModel>();
        }
        private void CreateXorBooleanNode_Executed(object sender, ExecutedRoutedEventArgs e) {
            CreateNode<XorBooleanNodeViewModel>();
        }
        //--------------Integer--------------//
        private void CreateConstantIntegerNode_Executed(object sender, ExecutedRoutedEventArgs e) {
            CreateNode<ConstantIntegerNodeViewModel>();
        }
        private void CreateAddIntegerNode_Executed(object sender, ExecutedRoutedEventArgs e) {
            CreateNode<AddIntegerNodeViewModel>();
        }
        private void CreateSubIntegerNode_Executed(object sender, ExecutedRoutedEventArgs e) {
            CreateNode<SubIntegerNodeViewModel>();
        }
        private void CreateDivIntegerNode_Executed(object sender, ExecutedRoutedEventArgs e) {
            CreateNode<DivIntegerNodeViewModel>();
        }
        private void CreateMulIntegerNode_Executed(object sender, ExecutedRoutedEventArgs e) {
            CreateNode<MulIntegerNodeViewModel>();
        }
        private void CreateResiIntegerNode_Executed(object sender, ExecutedRoutedEventArgs e) {
            CreateNode<ResidueIntegerNodeViewModel>();
        }
        //--------------Float--------------//
        /// <summary>
        /// Event raised to create a new node.
        /// </summary>
        private void CreateConstantFloatNode_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            CreateNode<ConstantFloatNodeViewModel>();
        }
        private void CreateAddFloatNode_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            CreateNode<AddFloatNodeViewModel>();
        }

        private void CreateMulFloatNode_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            CreateNode<MulFloatNodeViewModel>();
        }

        private void CreateDivFloatNode_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            CreateNode<DivFloatNodeViewModel>();
        }

        private void CreatePrintNode_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            CreateNode<PrintStringNodeViewModel>();
        }
        //--------------Vector--------------//
        /// <summary>
        /// Event raised to create a new node.
        /// </summary>

        private void CreateConstantVectorNode_Executed(object sender, ExecutedRoutedEventArgs e) {
            CreateNode<ConstantVectorNodeViewModel>();
        }
        private void CreateAddVectorNode_Executed(object sender, ExecutedRoutedEventArgs e) {
            CreateNode<AddVectorNodeViewModel>();
        }
        private void CreateSubVectorNode_Executed(object sender, ExecutedRoutedEventArgs e) {
            CreateNode<SubVectorNodeViewModel>();
        }
        private void CreateDivVectorNode_Executed(object sender, ExecutedRoutedEventArgs e) {
            CreateNode<DivVectorNodeViewModel>();
        }
        private void CreateMulVectorNode_Executed(object sender, ExecutedRoutedEventArgs e) {
            CreateNode<MulVectorNodeViewModel>();
        }
        //--------------Matrix--------------//
        /// <summary>
        /// Event raised to create a new node.
        /// </summary>
        private void CreateConstantMatrixNode_Executed(object sender, ExecutedRoutedEventArgs e) {
            CreateNode<ConstantMatrixNodeViewModel>();
        }
        private void CreateMulMatrixNode_Executed(object sender, ExecutedRoutedEventArgs e) {
            CreateNode<MulMatrixNodeViewModel>();
        }

        //--------------Light--------------//
        private void CreateConstantLightNode_Executed(object sender, ExecutedRoutedEventArgs e) {
            CreateNode<ConstantLightNodeViewModel>();
        }
        //--------------Sound--------------//
        private void CreateConstantSoundNode_Executed(object sender, ExecutedRoutedEventArgs e) {
            CreateNode<ConstantSoundNodeViewModel>();
        }
        //--------------Mesh --------------//
        private void CreateConstantMeshNode_Executed(object sender, ExecutedRoutedEventArgs e) {
            CreateNode<ConstantMeshNodeViewModel>();
        }
        //--------------Color--------------//
        private void CreateConstantColorNode_Executed(object sender, ExecutedRoutedEventArgs e) {
            CreateNode<ConstantColorNodeViewModel>();
        }
        #endregion

        /// <summary>
        /// Event raised to delete a node.
        /// </summary>
        private void DeleteNode_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            var node = (AbstractNodeViewModel)e.Parameter;
            this.ViewModel.DeleteNode(node);
        }

        /// <summary>
        /// Event raised to delete a connection.
        /// </summary>
        private void DeleteConnection_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            var connection = (ConnectionViewModel)e.Parameter;
            this.ViewModel.DeleteConnection(connection);
        }

        /// <summary>
        /// Creates a new node in the network at the current mouse location.
        /// </summary>
        private void CreateNode<T>()
            where T : AbstractNodeViewModel
        {
            var newNodePosition = Mouse.GetPosition(networkControl);
            this.ViewModel.CreateNode<T>(newNodePosition, true);
        }

        /// <summary>
        /// Event raised when the size of a node has changed.
        /// </summary>
        private void Node_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            //
            // The size of a node, as determined in the UI by the node's data-template,
            // has changed.  Push the size of the node through to the view-model.
            //
            var element = (FrameworkElement)sender;
            var node = (AbstractNodeViewModel)element.DataContext;
            node.Size = new Size(element.ActualWidth, element.ActualHeight);
        }

    }
}
