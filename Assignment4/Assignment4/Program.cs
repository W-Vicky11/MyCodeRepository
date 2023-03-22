//整型List
GenericList<int> intlist = new GenericList<int>();
for(int x = 0; x < 10; x++)
{
    intlist.Add(x);
}
//打印链表元素
intlist.Foreach(m=>Console.Write(m+" "));
Console.WriteLine();
//求最大值
int max=0;
intlist.Foreach(m => { if (max < m) max = m; });
Console.WriteLine(max);
//求最小值
int min = 0;
intlist.Foreach(m => { if (min > m) min = m; });
Console.WriteLine(min);
//求和
int sum = 0;
intlist.Foreach(m => sum += m);
Console.WriteLine(sum);

//链表节点
public class Node<T>
{
    public Node<T> Next { get; set; }
    public T Data { get; set; }
    public Node(T t)
    {
        Next = null;
        Data = t;
    }
}
//泛型链表类
public class GenericList<T>
{
    private Node<T> head;
    private Node<T> tail;

    public GenericList()
    {
        tail = head = null;
    }
    public Node<T> Head
    {
        get => head;
    }
    public void Add(T t)
    {
        Node<T> n = new Node<T>(t);
        if (tail == null)
        {
            head = tail = n;
        }
        else
        {
            tail.Next = n;
            tail = n;
        }
    }
    public void Foreach(Action<T>action)
    {
        for(Node<T> n = head; n != null; n = n.Next)
        {
            action(n.Data);
        }
    }
}