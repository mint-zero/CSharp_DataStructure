using System;

namespace CSharp_DataStructure
{
    class Program
    {
        static void Main(string[] args)
        {
            //싱글 링크드리스트 테스트
            SinglyLinkedList<int> singlyList = new SinglyLinkedList<int>();
            var node1 = new SinglyLinkedListNode<int>(1);
            var node2 = new SinglyLinkedListNode<int>(2);
            var node3 = new SinglyLinkedListNode<int>(3);
            var node4 = new SinglyLinkedListNode<int>(4);
            var node5 = new SinglyLinkedListNode<int>(5);
            singlyList.Add(node1);
            singlyList.Add(node2);
            singlyList.Add(node3);
            singlyList.Add(node4);
            singlyList.Show();
            singlyList.Remove(node2);
            singlyList.Remove(node4);
            singlyList.Show();

            //더블 원형 링크드리스트 테스트
            DoublyLinkedList<int> doubleList =  new DoublyLinkedList<int>();
            var doublyNode1 = new DoublyLinkedNode<int>(1);
            var doublyNode2 = new DoublyLinkedNode<int>(2);
            var doublyNode3 = new DoublyLinkedNode<int>(3);
            var doublyNode4 = new DoublyLinkedNode<int>(4);
            var doublyNode5 = new DoublyLinkedNode<int>(5);

            doubleList.Add(doublyNode1);
            doubleList.Add(doublyNode3);
            doubleList.AddAfter(doublyNode1, doublyNode2);
            doubleList.AddAfter(doublyNode3, doublyNode4);
            doubleList.Add(doublyNode5);

            doubleList.Remove(doubleList.GetNode(0));
            Console.WriteLine(doubleList.Count);
            Console.WriteLine("\n");
            for(int i = 0; i < doubleList.Count; ++i)
            {
                Console.WriteLine(doubleList.GetNode(i).Data);
            }
        }
    }
}