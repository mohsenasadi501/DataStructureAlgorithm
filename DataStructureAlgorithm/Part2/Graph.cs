using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructureAlgorithm.Part2
{
    public class Graph
    {
        public Dictionary<string, Node> nodes = new Dictionary<string, Node>();
        public Dictionary<Node, List<Node>> adjacencyList = new Dictionary<Node, List<Node>>();

        public class Node
        {
            public string Lable { get; set; }
            public Node(string Lable)
            {
                this.Lable = Lable;
            }
        }
        public void addLable(string lable)
        {
            var node = new Node(lable);
            nodes.Add(lable, node);
            adjacencyList.Add(node, new List<Node> { });
        }
        public void addEdge(string from, string to)
        {
            var fromNode = nodes.FirstOrDefault(x => x.Key == from);
            var toNode = nodes.FirstOrDefault(x => x.Key == to);
        }
    }
}
