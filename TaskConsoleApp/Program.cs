// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

// First Way
// GetStringAsync methodundan google com geldikten sonra ContinueWith çalışacak.
var myTask = new HttpClient().GetStringAsync("https://www.google.com").ContinueWith(data =>
{
    Console.WriteLine("Data Length: " + data.Result.Length);
});
Console.WriteLine("Arada yapılacak işler.");
await myTask;


// Second way (Best practice)
var myTask2 = new HttpClient().GetStringAsync("https://www.google.com");
Console.WriteLine("Arada yapılacak işler.2");
var data = await myTask2;
Console.WriteLine("Data Length2: " + data.Length);