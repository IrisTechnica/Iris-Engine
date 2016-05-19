using NetworkModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;

namespace iris_engine.Data
{
    public class NodesSolver
    {
        #region Private Data Members
        private ImpObservableCollection<AbstractNodeViewModel> endOfNodes = null;

        private List<AbstractNodeViewModel> removeRequestNodes = null;

        #endregion

        #region Private Methods

        /// <summary>
        /// Recursive Solve single node calculation
        /// </summary>
        /// <param name="node"></param>
        /// <returns>Is success solved</returns>
        private bool UnitSolve(AbstractNodeViewModel node,ConnectorViewModel invokerConnector = null)
        {
            {
                bool isSuccessed = true;

                if (node.InputConnectors.Count != 0)
                {
                    foreach (var connector in node.InputConnectors)
                    {
                        // Exist input connectors, so check whether this attached to any node
                        if (connector.AttachedConnections.Count != 0)
                        {
                            // Attached input

                            // Attached num check
                            if (connector.AttachedConnections.Count > 1)
                            {
                                // Usually not reached point
                                throw new NotImplementedException("now input connection must has single attached.");
                            }
                            //So call the self recursively in terms of get this node's destination of the node
                            foreach (var connection in connector.AttachedConnections)
                            {
                                AbstractNodeViewModel outputNode = null;
                                if (connection.DestConnector.Type == ConnectorType.Output)
                                    outputNode = connection.DestConnector.ParentNode;
                                else
                                    outputNode = connection.SourceConnector.ParentNode;

                                isSuccessed = UnitSolve(outputNode, connector);
                            }

                        }
                    }
                }

                /// If could not solved of just before node, cancel solve
                //if (!isSuccessed) return false;
            }

            /// Execute Calculation
            node.Calculate();

            /// Check node is be able to solve of static 
            //if(node.SolverType != NodeCalculationType.Dynamic)
            //{
            //    return false;
            //}

            /// Propagate data to invoker
            foreach(var connector in node.OutputConnectors)
            {
                foreach(var connection in connector.AttachedConnections)
                {
                    ConnectorViewModel outputConnector = null;
                    ConnectorViewModel inputConnector = null;
                    if (connection.DestConnector.Type == ConnectorType.Output)
                    {
                        outputConnector = connection.DestConnector;
                        inputConnector = connection.SourceConnector;
                    }
                    else
                    {
                        outputConnector = connection.SourceConnector;
                        inputConnector = connection.DestConnector;
                    }
                    if (inputConnector == invokerConnector && connection.DestConnector.DataType == invokerConnector.DataType)
                    {
                        invokerConnector.NoRaiseEntity = outputConnector.Entity;
                    }
                }
            }

            return true;


        }

        private void SolveEndOfNode()
        {
            /// Check if longer at the End of Node
            foreach (AbstractNodeViewModel item in EndOfNodes)
            {
                foreach (var output in item.OutputConnectors)
                {
                    if (output.AttachedConnections.Count != 0)
                    {
                        /// Node was not end
                        RemoveRequestNodes.Add(item);
                    }
                }
            }
            foreach (var removeitem in RemoveRequestNodes)
            {
                EndOfNodes.Remove(removeitem);
            }
        }

        #endregion

        #region Public Properties

        public ImpObservableCollection<AbstractNodeViewModel> EndOfNodes
        {
            get
            {
                if (endOfNodes == null)
                {
                    endOfNodes = new ImpObservableCollection<AbstractNodeViewModel>();
                }
                return endOfNodes;
            }

            set
            {
                endOfNodes = value;
            }
        }

        internal List<AbstractNodeViewModel> RemoveRequestNodes
        {
            get
            {
                if (removeRequestNodes == null) removeRequestNodes = new List<AbstractNodeViewModel>();
                return removeRequestNodes;
            }

            set
            {
                removeRequestNodes = value;
            }
        }

        #endregion

        #region Public Methods

        public NodesSolver()
        {
        }

        public async void Solve()
        {
            Console.WriteLine("------------------------------");
            SolveEndOfNode();
            foreach(var node in EndOfNodes)
            {
                await Task.Run(() => UnitSolve(node));
            }
            Console.WriteLine("------------------------------");
            Console.Out.Flush();
        }

        public void DetectEndOfNode(AbstractNodeViewModel node)
        {
            /// Check OutputConnectors Count
            foreach(var output in node.OutputConnectors)
            {
                if (output.AttachedConnections.Count != 0) return;/// not end
            }
            if(EndOfNodes.IndexOf(node) < 0)
                EndOfNodes.Add(node);
        }
        #endregion
    }
}
