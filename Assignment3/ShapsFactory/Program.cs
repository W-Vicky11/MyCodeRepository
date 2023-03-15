Shaps shap1,shap2,shap3,shap4,shap5,shap6,shap7,shap8,shap9,shap10;
shap1 = ShapsFactory.GetShaps("Rectangle");//通过工厂类创建产品对象
shap2 = ShapsFactory.GetShaps("Square");
shap3 = ShapsFactory.GetShaps("Triangle");
shap4 = ShapsFactory.GetShaps("Circular");
shap5 = ShapsFactory.GetShaps("Square");
shap6 = ShapsFactory.GetShaps("Triangle");
shap7 = ShapsFactory.GetShaps("Triangle");
shap8 = ShapsFactory.GetShaps("Square");
shap9 = ShapsFactory.GetShaps("Circular");
shap10 = ShapsFactory.GetShaps("Rectangle");
Console.WriteLine(shap1.GetArea() + shap2.GetArea() + shap3.GetArea()
    + shap4.GetArea() + shap5.GetArea() + shap6.GetArea() + shap7.GetArea()
    + shap8.GetArea() + shap9.GetArea() + shap10.GetArea());
abstract class Shaps
{
    public void MethodSame()
    {
        //公共方法
    }
    public abstract double GetArea();
}

class Rectangle : Shaps
{
    //实现业务方法
    public Rectangle(double width,double height)
    {
        this.Width = width;
        this.Height = height;
    }
    public double Width { get; set; } = 2;
    public double Height { get; set; } = 3;
    public override double GetArea()
    {
        if (IsValid() == false) throw new Exception("异常");
       else return Width * Height;
    }
    public bool IsValid()
    {
        return Width>0&Height>0;
    }
}
class Square : Shaps
{
    public double A { get; set; }= 1;
    public override double GetArea()
    {
        if (IsValid() == false) throw new Exception("异常");
        else return A * A;
    }
    public bool IsValid()
    {
        return A > 0;
    }
}
class Triangle : Shaps
{
    public double Width { get; set; } = 3;
    public double Height { get; set; } = 2;
    public override double GetArea()
    {
        if (IsValid() == false) throw new Exception("异常");
        else return Width * Height / 2;
    }
    public bool IsValid()
    {
        return Width > 0&Height>0;
    }
}
class Circular:Shaps
{
    public double R { get; set; } = 5;
    public override double GetArea()
    {
        if (IsValid() == false) throw new Exception("异常");
        else return R * R*Math.PI;
    }
    public bool IsValid()
    {
        return R > 0;
    }
}


class ShapsFactory
{
    public static Shaps GetShaps(string arg)
    {
        Shaps shap = null;
        if(arg.Equals("Rectangle"))
        {
            shap = new Rectangle(2,3);
            //初始化设置shap
        }
        else if(arg.Equals("Square"))
        {
            shap = new Square();
        }
        else if(arg.Equals("Triangle"))
        {
            shap=new Triangle();
        }
        else if (arg.Equals("Circular"))
        {
            shap = new Circular();
        }
        return shap;
    }
}