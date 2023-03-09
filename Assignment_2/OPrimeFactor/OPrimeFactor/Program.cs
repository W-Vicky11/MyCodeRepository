//判断是否是素数
bool if_Primenumber(int val)
{
    bool isPrime = true;
    int i = 2;
    while (i < val)
    {
        if (val % i == 0) isPrime = false;
        else i++;
    }
    return isPrime;
}

Console.WriteLine("输入你想验证的数字:");
int num;
num = Convert.ToInt32(Console.ReadLine());

//判断是否存在素数因子
bool exist = false;
int j = 2;
while (j < num)
{
    if (num % j == 0 && if_Primenumber(j) == true)//如果为素数因子
    {
        exist = true;
        Console.WriteLine("{0}的素数因子为：", num);
        break;
    }
    else j++;
}
if (exist == false) Console.WriteLine("{0}不存在素数因子。", num);

//如果存在就输出素数因子
for (int i = 2; i < num; i++)
{
    if (num % i == 0 && if_Primenumber(i) == true)
    {
        Console.WriteLine(i);
    }
}
