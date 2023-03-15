//长方形
Rectangle rectangle=new Rectangle();
rectangle.Width = 2;
rectangle.Height = 3;
Console.WriteLine(rectangle.GetArea());
Console.WriteLine(rectangle.IfReal());

//正方形
Square square=new Square();
square.Side = 0;
Console.WriteLine(square.GetArea());
Console.WriteLine(square.IfReal());

//三角形
Triangle triangle=new Triangle();
triangle.Width = 2;
triangle.Height = 3;
Console.WriteLine(triangle.GetArea());
Console.WriteLine(triangle.IfReal());

//抽象类
public abstract class Shaps
{
    public string Type { get; set; }
    public abstract double GetArea();
    public abstract bool IfReal();
}
//长方形
public class Rectangle:Shaps
{
    public double Width { get; set; }
    public double Height { get; set; }
   
    public override double GetArea()
    {
        return Width * Height;
    }
    public override bool IfReal()
    {
        if (Width<=0| Height<=0) return false;
        else return true;
    }
};

//正方形
class Square:Shaps
{
    public double side;
    public double Side
    {
        get { return side; }
        set { side = value; }
    }
    public override double GetArea()
    {
       return side*side;
    }
    public override bool IfReal()
    {
        if (Side <= 0) return false;
        else return true;
    }
}
//三角形
class Triangle:Shaps
{
    public double Width { get; set; }
    public double Height { get; set; }
    public override double GetArea()
    {
        return Width * Height / 2;
    }
    public override bool IfReal()
    {
        if (Width <= 0 | Height <= 0) return false;
        else return true;
    }
};