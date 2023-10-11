namespace TaskConsoleApp
{
    public class Content
    {
        public string Site { get; set; }
        public int Length { get; set; }
    };


    internal class Program
    {
        private async static Task Main(string[] ars)
        {
            await Console.Out.WriteLineAsync("Main thread:" + Thread.CurrentThread.ManagedThreadId);
            List<string> urlsList = new List<string>()
            {
                "https://www.google.com",
                "https://www.microsoft.com",
                "https://www.amazon.com",
                "https://www.n11.com",
                "https://www.haberturk.com"
            };
            List<Task<Content>> taskList = new List<Task<Content>>();
            urlsList.ToList().ForEach(url =>
            {
                taskList.Add(GetContentAsync(url));
            });
            var contents = Task.WhenAll(taskList.ToArray());
            await Console.Out.WriteLineAsync("WhenAll sonrası gerçekleşen  methodlar.");
            var data = await contents;
            data.ToList().ForEach(task =>
            {
                Console.WriteLine($"{task.Site} Length: {task.Length}");
            });

        }
        public static async Task<Content> GetContentAsync(string url)
        {
            Content content = new Content();
            var data = await new HttpClient().GetStringAsync(url);
            content.Site = url;
            content.Length = data.Length;
            await Console.Out.WriteLineAsync("GetContentAsync thread:" + Thread.CurrentThread.ManagedThreadId);
            return content;
        }
    }
}
