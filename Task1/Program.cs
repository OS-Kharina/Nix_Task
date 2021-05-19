using System;
using System.Reflection;
using Library1;
namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            Assembly assem = Assembly.LoadFrom(@"D:\2 course\Library12\LibraryCalc\bin\Debug\net5.0\LibraryCalc.dll");
            Console.WriteLine(assem.FullName);
            var types = assem.GetTypes();
            foreach(var type in types)
            {
                Console.WriteLine($"Name: {type.Name}, Assembly: {type.Assembly}, Typeinfo: {type.GetTypeInfo()}");
            }
            Type t = assem.GetType("LibraryCalc.CalcMethod", true, true);
            var obj = Activator.CreateInstance(t);
            MethodInfo method = t.GetMethod("Calc");
            var param = method.GetParameters();
            Console.Write($"Method {method.Name}(");
            foreach (var p in param)
            {
                Console.Write($"{p.ParameterType.Name } {p.Name}, ");
            }
            Console.WriteLine("\b)");
            var result = method.Invoke(obj, new object[] { 5, -42 });
            //Console.WriteLine(result);
            Type t1 = typeof(User);
            Console.WriteLine($"Name: {t1.Name}");
            User user1 = new User("Sasha",18);
            user1.GetInfo();
            Console.ReadKey();
        }
    }
}
