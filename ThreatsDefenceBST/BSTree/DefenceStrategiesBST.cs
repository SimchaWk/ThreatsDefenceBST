// Ignore Spelling: json

using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ThreatsDefenceBST.BSTree
{
    internal class DefenceStrategiesBST
    {
        public DSNode? root;
        private int _count = 0;

        public void Insert(int min, int max, List<string> defenses)
        {
            DSNode newNode = new(min, max, defenses);
            root = InsertRecursive(root, newNode);
        }

        private DSNode InsertRecursive(DSNode? currentRoot, DSNode newNode)
        {
            if (currentRoot == null)
            {
                _count++;
                return newNode;
            }

            if (newNode.MaxSeverity < currentRoot.MinSeverity)
            {
                currentRoot.Left = InsertRecursive(currentRoot.Left, newNode);
            }
            else if (newNode.MinSeverity > currentRoot.MaxSeverity)
            {
                currentRoot.Right = InsertRecursive(currentRoot.Right, newNode);
            }
            return currentRoot;
        }

        public void Remove(int min, int max)
        {
            root = RemoveRecursive(root, min, max);
        }

        private DSNode? RemoveRecursive(DSNode? currentRoot, int min, int max)
        {
            if (currentRoot == null)
            {
                return null;
            }
            if (max < currentRoot.MinSeverity)
            {
                currentRoot.Left = RemoveRecursive(currentRoot.Left, min, max);
            }
            else if (min > currentRoot.MaxSeverity)
            {
                currentRoot.Right = RemoveRecursive(currentRoot.Right, min, max);
            }
            else
            {
                if (currentRoot.Left == null && currentRoot.Right == null)
                {
                    return null;
                }
                else if (currentRoot.Left == null)
                {
                    _count--;
                    return currentRoot.Right;
                }
                else if (currentRoot.Right == null)
                {
                    _count--;
                    return currentRoot.Left;
                }
                else
                {
                    DSNode successor = GetSuccessor(currentRoot);
                    currentRoot.MinSeverity = successor.MinSeverity;
                    currentRoot.MaxSeverity = successor.MaxSeverity;
                    currentRoot.Right = RemoveRecursive(currentRoot.Right, successor.MinSeverity, successor.MaxSeverity);
                    _count--;
                }
            }
            return currentRoot;
        }

        private DSNode GetSuccessor(DSNode currentRoot)
        {
            currentRoot = currentRoot.Right;
            while (currentRoot.Left != null)
            {
                currentRoot = currentRoot.Left;
            }
            return currentRoot;
        }

        public List<DSNode> InOrder()
        {
            List<DSNode> resList = new();
            InOrderRecursive(root, resList);
            return resList;
        }

        private void InOrderRecursive(DSNode? currentRoot, List<DSNode> resList)
        {
            if (currentRoot == null) { return; }

            InOrderRecursive(currentRoot.Left, resList);
            resList.Add(currentRoot);
            InOrderRecursive(currentRoot.Right, resList);
        }

        public List<DSNode> PreOrder()
        {
            List<DSNode> resList = new();
            PreOrderRecursive(root, resList);
            return resList;
        }

        private void PreOrderRecursive(DSNode? currentRoot, List<DSNode> resList)
        {
            if (currentRoot == null) { return; }

            resList.Add(currentRoot);
            PreOrderRecursive(currentRoot.Left, resList);
            PreOrderRecursive(currentRoot.Right, resList);
        }

        public List<DSNode> PostOrder()
        {
            List<DSNode> resList = new();
            PostOrderRecursive(root, resList);
            return resList;
        }

        private void PostOrderRecursive(DSNode? currentRoot, List<DSNode> resList)
        {
            if (currentRoot == null) { return; }

            PostOrderRecursive(currentRoot.Left, resList);
            PostOrderRecursive(currentRoot.Right, resList);
            resList.Add(currentRoot);
        }

        public DSNode? SearchPreOrder(int targetValue) => SearchPreOrderRecursive(root, targetValue);

        private DSNode? SearchPreOrderRecursive(DSNode currentRoot, int targetValue)
        {
            if (currentRoot == null)
            {
                return null;
            }
            else if (currentRoot.IsInRange(targetValue))
            {
                return currentRoot;
            }
            else if (currentRoot.IsUnderRange(targetValue))
            {
                return SearchPreOrderRecursive(currentRoot.Left, targetValue);
            }
            else if (currentRoot.IsAboveRange(targetValue))
            {
                return SearchPreOrderRecursive(currentRoot.Right, targetValue);
            }
            return null;
        }

        public int Count() => _count;

        public void AddRange(List<DSNode> nodes) => 
            nodes.ForEach(node => Insert(node.MinSeverity, node.MaxSeverity, node.Defenses));

        public void BalanceTree()
        {
            List<DSNode> sortedNodes = InOrder();
            root = BuildBalancedTree(sortedNodes, 0, sortedNodes.Count - 1);
        }

        private DSNode? BuildBalancedTree(List<DSNode> sortedNodes, int start, int end)
        {
            if (start > end)
            {
                return null;
            }

            int mid = (start + end) / 2;
            DSNode node = sortedNodes[mid];

            node.Left = BuildBalancedTree(sortedNodes, start, mid - 1);

            node.Right = BuildBalancedTree(sortedNodes, mid + 1, end);

            return node;
        }

        public void PrintTreePreOrderVisual(int delay = 0)
        {
            PrintTreePreOrderVisualRecursive(root, "", "", true, delay, "Root -> ");
        }

        private void PrintTreePreOrderVisualRecursive(
            DSNode? currentNode, string indent, string nodeIndicator, bool isLast, int delay, string childIndicator
        )
        {
            if (currentNode == null) return;

            Console.Write(indent);
            if (nodeIndicator != "")
            {
                Console.Write(nodeIndicator);
                indent += isLast ? "    " : "│   ";
            }
            Console.WriteLine($"{childIndicator}({currentNode.MinSeverity}-{currentNode.MaxSeverity}) Defenses: [{string.Join(", ", currentNode.Defenses)}]");

            Thread.Sleep(delay * 1000);

            if (currentNode.Left != null)
            {
                PrintTreePreOrderVisualRecursive(currentNode.Left, indent, "├── ", currentNode.Right == null, delay, "Left -> ");
            }
            if (currentNode.Right != null)
            {
                PrintTreePreOrderVisualRecursive(currentNode.Right, indent, "└── ", true, delay, "Right -> ");
            }
        }
    }
}
