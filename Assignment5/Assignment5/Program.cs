using System;

OrderService orderService = new OrderService();
//添加订单
Console.WriteLine("添加第一个客户，id为1，名字为Max");
Order order1 = new Order(1, "Max");
Console.WriteLine("买了1个价钱为500的耳机，和2件价钱为300的裙子,和2根价钱为5的棒棒糖");
Console.WriteLine();
OrderDetails item1 = new OrderDetails("earphone", 500, 1);
OrderDetails item2 = new OrderDetails("stress",300 , 2);
OrderDetails item3 = new OrderDetails("lollipop", 2, 3);
order1.AddItem(item1);  
order1.AddItem(item2);
order1.AddItem(item3);

Console.WriteLine("添加第二个客户，id为2，名字为Linda");
Order order2 = new Order(2, "Linda");
Console.WriteLine("买了2本价钱为12的书，和3根价钱为5的棒棒糖");
Console.WriteLine();
OrderDetails item4 = new OrderDetails("book", 12, 2);
OrderDetails item5 = new OrderDetails("lollipop", 5, 3);
order2.AddItem(item4);
order2.AddItem(item5);


orderService.AddOrder(order1);
orderService.AddOrder(order2);

//查询
//List<Order> ordersPlus = orderService.orders.OrderBy(o => o.TotalAmount()).ToList();
orderService.Sort((o1, o2) => o1.TotalAmount() - o2.TotalAmount());//按照金额大小排序

Console.WriteLine("查询棒棒糖（按照金额大小进行排序）：");
foreach (Order item in orderService.QueryOrdersByGoodsName("lollipop"))
{
    Console.WriteLine(item);
}

Console.WriteLine("查询Max客户：");
foreach(Order item in orderService.QueryOrdersByCustomerName("Max"))
{
    Console.WriteLine(item);
}

Console.WriteLine("查询订单金额为39的订单：");
foreach(Order item in orderService.QueryOrdersByTotalAmount(39))
{
    Console.WriteLine(item);
}
//修改订单
Console.WriteLine("修改订单2的人名为Tom: ");
orderService.UpdateOrder(new Order(2,"Tom"));
Console.WriteLine(orderService);
//删除订单
Console.WriteLine("删除订单2后打印订单数据：");
orderService.RemoveOrder(2);
Console.WriteLine(orderService);

// Test cases for OrderService


public class Order//订单
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<OrderDetails> Details { get; set; }
    public Order(int id, string name)
    {
        Id = id;
        Name = name;
        Details = new List<OrderDetails>();
    }
    //添加明细
    public void AddItem(OrderDetails item)
    {
        if (this.Details.Contains(item))//如果订单明细已经存在，抛出异常
        {
            throw new ApplicationException($"OrderItem {item} already exists!");
        }
        Details.Add(item);
    }
    //删除明细
    public void RemoveItem(OrderDetails item)
    {
        Details.Remove(item);
    }
    //重写Equals函数，比较是否有相同的订单
    public override bool Equals(object obj)
    {
        var order = obj as Order;
        return order != null &&
               Id == order.Id &&
               Name == order.Name;
    }

    public override int GetHashCode()
    {
        var hashCode = -1328368111;
        hashCode = hashCode * -1521134295 + EqualityComparer<int>.Default.GetHashCode(Id);//得到Id的hashCode
        hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);//得到Name的hashCode
        return hashCode;
    }

    public override string ToString()
    {
        string result = $"Order ID: {Id}, Customer: {Name}\n";
        //输出明细
        foreach (OrderDetails item in Details)
        {
            result += item.ToString() + "\n";
        }
        return result;
    }
    //总价
    public int TotalAmount()
    {
        return Details.Sum(item => item.Price * item.Quantity);
    }
}

public class OrderDetails//订单明细
{
    public string GoodsName { get; set; }
    public int Price { get; set; }
    public int Quantity { get; set; }

    public OrderDetails(string goodsName, int price, int quantity)
    {
        this.GoodsName = goodsName;
        this.Price = price;
        this.Quantity = quantity;
    }
    //重写Equals函数，比较是否有相同的订单明细
    public override bool Equals(object obj)
    {
        var details = obj as OrderDetails;
        return details != null &&
               GoodsName == details.GoodsName &&
               Price == details.Price;
    }

    public override int GetHashCode()
    {
        var hashCode = -1603541664;
        hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(GoodsName);
        hashCode = hashCode * -1521134295 + Price.GetHashCode();
        return hashCode;
    }

    public override string ToString()
    {
        return $"Goods: {GoodsName}, Price: {Price}, Quantity: {Quantity}";
    }
}

public class OrderService//订单服务
{
    public List<Order> orders=new List<Order>();
    //添加订单
    public void AddOrder(Order order)
    {
        if (orders.Contains(order))
        {
            throw new ApplicationException($"Order {order} already exists!");
        }
        orders.Add(order);
    }
    //删除订单
    public Order GetOrderById(int Id)
    {
        //得到第一个对象,或者NULL
        return orders.FirstOrDefault(order => order.Id == Id);
    }

    public void RemoveOrder(int Id)
    {
        Order order = GetOrderById(Id);
        if (order != null)
        {
            orders.Remove(order);
        }
    }
    //更新订单
    public void UpdateOrder(Order order)
    {
        Order oldOrder = GetOrderById(order.Id);
        if (oldOrder != null)
        {
            orders.Remove(oldOrder);
            orders.Add(order);
        }
    }
    //查询订单（商品名）
    public List<Order> QueryOrdersByGoodsName(string goodsName)
    {
        return orders.Where(order => order.Details.Exists(item => item.GoodsName == goodsName)).ToList();
    }
    //查询订单（客户）
    public List<Order> QueryOrdersByCustomerName(string customerName)
    {
        return orders.Where(order => order.Name == customerName).ToList();
    }
    //查询订单(订单金额）
    public List<Order> QueryOrdersByTotalAmount(decimal totalAmount)
    {
        return orders.Where(order => order.TotalAmount() == totalAmount).ToList();
    }
    //按某种方法进行排序
    public void Sort(Comparison<Order> comparison)
    {
        orders.Sort(comparison);
    }

    public List<Order> QueryAllOrders()
    {
        return orders;
    }

    public override string ToString()
    {
        string result = "";
        foreach (Order order in orders)
        {
            result += order.ToString() + "\n";
        }
        return result;
    }
}

