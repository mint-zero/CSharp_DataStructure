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
        }
    }
}