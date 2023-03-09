using System.Numerics;
using System.Xml.Serialization;

Console.WriteLine("输入数组元素的值：");
string s = Console.ReadLine();
List<int> list = new List<int>();
string[] val = null;
val = s.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);//以逗号为分隔符
for (int i = 0; i < val.Length; i++) 
{
    list.Add(Convert.ToInt32(val[i]));
}

Console.WriteLine("请输入你要进行的操作：1、找最大值；2、找最小值；3、求平均值；4、求和");
int Q = Convert.ToInt32(Console.ReadLine());
switch(Q)
{
    case 1:
        Console.WriteLine(list.Max());
        break;
    case 2:
        Console.WriteLine(list.Min());
        break;
    case 3:
        Console.WriteLine(list.Average());
        break;
    case 4:
        Console.WriteLine(list.Sum());
        break;
    default:
        Console.WriteLine("无效操作");
        break;
}