namespace TaskConsoleApp
{
    public class Content
    {
        public string Site { get; set; }
        public int Length { get; set; }
    };
    public class Status
    {
        public int ThreadId { get; set; }
        public DateTime Date { get; set; }
    };

    internal class Program
    {
        private async static Task Main(string[] ars)
        {
            var myTask = Task.Factory.StartNew((obj) =>
            {
                Console.WriteLine("MyTask start");
                var status = obj as Status;
                status.ThreadId = Thread.CurrentThread.ManagedThreadId;
            }, new Status() { Date = DateTime.Now});
            await myTask;
            Status s = myTask.AsyncState as Status;
            Console.WriteLine(s.Date);
            Console.WriteLine(s.ThreadId);
        }
    }
}
