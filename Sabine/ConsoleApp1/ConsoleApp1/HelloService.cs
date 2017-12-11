namespace ConsoleApp1
{
    public class HelloService : IHelloService
    {
        public string Hello(string name)=> $"Hello, {name}";
    }
}