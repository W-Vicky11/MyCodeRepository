int[] aa = new int[101];
aa[2] = 0;
int k = 2, tt = 0;
while(tt<101)
{
    for(int i=1; i<aa.Length; i++)//将不是素数的数筛选出来
    {
        if (i % k == 0 && i != k) aa[i] = 1;
    }
    for(int i=1;i<aa.Length; i++)//将筛选后的第一个数当成新的筛子
    {
        if(i>k&&aa[i] == 0)
        {
            k = i;
            break;
        }
    }
    tt++;
}
for (int i = 1; i < aa.Length; i++)
    if (aa[i] == 0) Console.WriteLine(i);