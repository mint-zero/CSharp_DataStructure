using System;
using System.CodeDom.Compiler;
using System.Diagnostics;

//한 객체가 추가 될 떄마다 배열 길이를 한개씩 추가하는 배열
public class DynamicArrayFisrt
{
	private object[] mArr = new object[0];

	public void Add(object element)
    {
        var new_arr = new object[mArr.Length + 1];

        for(int i = 0; i < mArr.Length; ++i)
        {
            new_arr[i] = mArr[i];
        }

        new_arr[mArr.Length - 1] = element;

        mArr = new_arr;
    }
}

//배열의 할당량을 초과할 때마다 두배씩 늘리는 배열 
public class DynamicArray
{
    private static readonly int GROWTH_FACTOR = 2;    
    private object[] mArr = new object[2];
    private int mCount = 0;

    public void Add(object element)
    {
        if(mArr.Length >= mCount)
        {
            ExpandArr();
        }

        mArr[mCount] = element;

        mCount++;
    }

    public object Get(int index)
    {
        if(index >= mArr.Length)
        {
            throw new ApplicationException("index over");
        }
        return mArr[index];
    }

    private void ExpandArr()
    {
        var temp = new object[mArr.Length * GROWTH_FACTOR];

        for(int i = 0; i < mArr.Length; ++i)
        {
            temp[i] = mArr[i];
        }

        mArr = temp;
    }
}

//싱글 링크드 리스트 구현
public class SinglyLinkedListNode<T>
{
    public T Data { get; set; }
    public SinglyLinkedListNode<T> Next { get; set; }

    public SinglyLinkedListNode(T data)
    {
        Data = data;
        Next = null;
    }
}

public class SinglyLinkedList<T>
{
    private SinglyLinkedListNode<T> mHead;

    public void Add(SinglyLinkedListNode<T> newNode)
    {
        if(newNode == null)
        {
            return;
        }

        if(mHead == null)
        {
            mHead = newNode;
            mHead.Next = null;
        }
        else
        {
            AddNodeLast(newNode);
        }
    }

    public void Remove(SinglyLinkedListNode<T> removeNode)
    {
        if(removeNode == null)
        {
            return;
        }
        RemoveNode(removeNode);
    }

    public void Show()
    {
        Console.WriteLine($"----------------------Show!!------------------");
        var currentNode = mHead;
        while(currentNode != null)
        {
            Console.WriteLine($"{currentNode.Data}");
            currentNode = currentNode.Next;
        }
    }

    private void RemoveNode(SinglyLinkedListNode<T> removeNode)
    {
        var currentNode = mHead;

        while(currentNode.Next != removeNode)
        {
            if(currentNode == null)
            {
                new ApplicationException("노드를 찾을 수 없습니다!");
                return;
            }   

            currentNode = currentNode.Next;                    
        }

        var nextNode = currentNode.Next?.Next ?? null;
        currentNode.Next = nextNode;
    }

    private void AddNodeLast(SinglyLinkedListNode<T> newNode)
    {
        var currentNode = mHead;
        while(currentNode.Next != null)
        {
            currentNode = currentNode.Next;
        }

        currentNode.Next = newNode;
        newNode.Next = null;
    }
}