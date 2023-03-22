using System.Data;

var alarm = new AlarmClock();

alarm.Tick += (sender, e) => Console.WriteLine(e.Message);
alarm.Alarm += (sender, e) => Console.WriteLine(e.Message);

Console.WriteLine("输入闹钟时间（秒）");
int n=Convert.ToInt32(Console.ReadLine());
alarm.alarmTime = DateTime.Now.AddSeconds(n);//当前时间加n
Console.WriteLine("AlarmClock start!");

alarm.Start();
Console.ReadKey();
alarm.Stop();
Console.WriteLine("AlarmClock is stop!");

//用于传递参数
public class EventArgs 
{
    public string Message { get; set; }
    public EventArgs(string message)
    {
        Message= message;
    }
}
public class AlarmClock
{
    public event EventHandler <EventArgs> Tick;
    public event EventHandler <EventArgs> Alarm;
    private bool isRunning;
    //定时器
    private Timer timer;
    //设置闹钟时间
    public DateTime alarmTime { get; set; }

    //开始闹钟
    public void Start()
    {
        if(isRunning) return;
        isRunning = true;
        // 使用定时器，每秒触发一次 Tick 事件
        timer = new System.Threading.Timer(
            callback: (state) =>
            {
                if (DateTime.Now >= alarmTime)
                {
                    // 到达闹钟时间，触发 Alarm 事件
                    Alarm(this, new EventArgs("Ring Ring Ring!!!"));
                }
                else
                {
                    // 没有到达闹钟时间，触发 Tick 事件
                    Tick(this, new EventArgs("Tick Tock Tick Tock"));
                }
            },
            state: null,
            dueTime: 0,
            period: 1000
        );
    }
    //停止闹钟
    public void Stop()
    {
        if(!isRunning) return;
        isRunning=false;
        timer.Dispose();
        timer = null;
    }
}
