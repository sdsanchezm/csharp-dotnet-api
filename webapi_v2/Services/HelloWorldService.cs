namespace webapi.Services
{
    public class HelloWorldService : IHelloWorldService
    {
        public string GetHelloWorld()
        {
            Console.WriteLine("Hallo Welt!");
            return "Hallo Welt hier!";
        }

    }

    public interface IHelloWorldService
    {
        string GetHelloWorld();
    }
}
