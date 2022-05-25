using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class Solution
    {
        public Node CloneGraph(Node node)
        {
            if (node == null)   // null(empty graph) as input, return null(empty graph)
            {
                return null;
            }
            Node graph = new Node();
            Dfs(node, new Dictionary<int, Node>(), graph);
            return graph;  
        }

        /// <summary>
        /// Iterates over a graph performing a DFS(Depth First Search) while creating a deep copy of the nodes of 
        /// the specified graph.
        /// </summary>
        /// <param name="node">Node of the graph to be copied</param>
        /// <param name="visitedNodes">Dictionary to keep track on the copy nodes. The dictionary has the values of
        /// the nodes as copies since they are unique for each node and the corresponding copy node as value.</param>
        /// <param name="copyNode">Node that represents a copy of the original node(first argument)</param>
        public void Dfs(Node node, Dictionary<int, Node> visitedNodes, Node copyNode)
        {   
            // Set the value of the copy node as the node of the node that we are visiting
            copyNode.val = node.val;
            // Dictionary allowing to keep track of the node copies created
            visitedNodes.Add(node.val, copyNode);

            int n = node.neighbors.Count;
            // Visit the neighbors to set the neighbords of the copy node
            for (int i = 0;i < n;i++)
            {
                Node currentNode = node.neighbors[i];
                try
                {
                    // Node was already visited, so we set it as neighbor of the node that is being visited
                    Node visitedNode = visitedNodes[currentNode.val];
                    copyNode.neighbors.Add(visitedNode);
                }
                catch (KeyNotFoundException)
                {
                    // Node has not been visited yet, so we have to create a new copy for this node and set it as 
                    // neighbor of the current copy
                    Node newCopyNode = new Node();
                    copyNode.neighbors.Add(newCopyNode);
                    Dfs(currentNode, visitedNodes, newCopyNode);
                }
            }
        }

    }
}
