using System;

namespace LambdaSample
{
    public delegate int MyMethodInvoker(int x, int y);

    class Program
    {
        public int State { get; set; }

        static void Main(string[] args)
        {
            MyMethodInvoker invoker = Add;
            invoker += new MyMethodInvoker(Subtract);
            int result = invoker.Invoke(38, 4);

            foreach (MyMethodInvoker inv in invoker.GetInvocationList())
            {
                result = inv.Invoke(38, 4);
            }
            Console.WriteLine(result);

            Program p = new Program();
            p.State = 1;
            invoker += new MyMethodInvoker(p.Foo);

            invoker -= new MyMethodInvoker(Add);
            invoker -= Subtract;
            invoker(11, 22);

            Program p2 = new Program();
            p2.State = 2;

            Bar(Add);


            MyMethodInvoker invoker2 = (int x, int y) =>
            {
                return x / y;
            };

        }

        static int Add(int x, int y)
        {
            return x + y;
        }

        static int Subtract(int x, int y)
        {
            return x - y;
        }

        int Foo(int x, int y)
        {
            return x * y;
        }

        int Foo(int x)
        {
            return x * x;
        }

        static void Bar(Func<int, int, int> f1)
        {
            int result = f1(11, 12);
        }
    }
}
