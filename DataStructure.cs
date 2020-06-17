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

//원형 이중 링크드 리스트 구현 준비
//노드이름은 DoublyLinkedNode<T>
//리스트 이름은 DoublyLinkedList<T>
//Add(DoublyLinkedNode<T> newNode) -> 가장 끝에 새로운 노드 추가
//AddAfter(DoublyLinkedNode<T> currentNode, DoublyLinkedNode<T> newNode) -> CurrentNode 뒤에 newNode 연결 추가
//Remove(DoublyLinkedNode<T> removeNode) -> 해당 노드 제거
// DoublyLinkedNode<T> GetNode(int index) -> 해당 Index에 있는 Node 반환
//int Count() -> 해당 리스트의 배열카운트 반환

public class DoublyLinkedNode<T>
{
    public DoublyLinkedNode<T> PrevNode{get; set;}
    public DoublyLinkedNode<T> NextNode{get; set;}
    public T Data;

    public DoublyLinkedNode(T data)
    {
        Data = data;
    }
}

public class DoublyLinkedList<T>
{
    public DoublyLinkedNode<T> mHead = null;
    public int Count => GetCount();
    public void Add(DoublyLinkedNode<T> newNode)
    {
        if(mHead == null)
        {
            mHead = newNode;
            mHead.PrevNode = newNode;
            mHead.NextNode = newNode;
            return;
        }

        DoublyLinkedNode<T> prevNode = mHead.PrevNode;
        
        prevNode.NextNode = newNode;
        mHead.PrevNode = newNode;
        newNode.PrevNode = prevNode;
        newNode.NextNode = mHead;
    }

    public void AddAfter(DoublyLinkedNode<T> currentNode, DoublyLinkedNode<T> newNode)
    {
        if(mHead == null)
        {
            return;
        }

        var selectedNode = mHead;
        while(selectedNode.NextNode != mHead)
        {
            if(currentNode == selectedNode)
            {
                newNode.PrevNode = selectedNode;
                newNode.NextNode = selectedNode.NextNode;
                selectedNode.NextNode.PrevNode = newNode;
                selectedNode.NextNode = newNode;
                return;
            }
            selectedNode = selectedNode.NextNode;
        }
    }

    public void Remove(DoublyLinkedNode<T> removeNode)
    {
        if(mHead == null)
        {
            return;
        }

        var selectedNode = mHead;
        while(selectedNode.NextNode != mHead)
        {
            if(removeNode == selectedNode)
            {
                selectedNode.NextNode.PrevNode = selectedNode.PrevNode;
                selectedNode.PrevNode.NextNode = selectedNode.NextNode;
                selectedNode = null;
                return;
            }
            selectedNode = selectedNode.NextNode;
        }
    }

    public DoublyLinkedNode<T> GetNode(int index)
    {
        //인덱스값을 넘어가더라도 원형이니까 뱅글뱅글 돌아서 노드를 반환해야 하나?
        //아니면 null을 반환해야 하나..
        if(mHead == null)
        {
            return null;
        }
        var currentNode = mHead;
        for(int i = 0; i < index; ++i)
        {
            currentNode = currentNode.NextNode;
        }

        return currentNode;
    }

    private int GetCount()
    {
        if(mHead == null)
        {
            return 0;
        }

        int count = 1;

        var selectedNode = mHead;
        while(selectedNode.NextNode != mHead)
        {
            ++count;
            selectedNode = selectedNode.NextNode;
        }
        return count;
    }
}