

#region AppDomain

//using System.Reflection;

//AppDomain domain = AppDomain.CurrentDomain;

//Console.WriteLine($"{domain.FriendlyName}\t{domain.BaseDirectory}");

//Console.WriteLine("ASSEMBLIES:");

//foreach (Assembly a in domain.GetAssemblies())
//    Console.WriteLine($"{a.GetName().Name}\t{a.GetName().Version}");

#endregion


#region Static loading

//using System.Reflection;
//using _03_MathLib;

//AppDomain domain = AppDomain.CurrentDomain;
//Console.WriteLine($"{domain.FriendlyName}\t{domain.BaseDirectory}");
//Console.WriteLine("ASSEMBLIES:");
//foreach (Assembly a in domain.GetAssemblies())
//    Console.WriteLine($"{a.GetName().Name}\t{a.GetName().Version}");


//Calculator calc = new Calculator();
//Console.WriteLine(calc.Sum(3, 4));

#endregion


#region Dynamic loading

using System.Reflection;
using System.Runtime.Loader;

Console.WriteLine("============= BEFORE LOADING");
RenderAssemblies();

AssemblyLoadContext ctx = new AssemblyLoadContext("lib_ctx", true);
Assembly assembly = ctx.LoadFromAssemblyPath(Path.Combine(Directory.GetCurrentDirectory(), "03_MathLib.dll"));

ctx.Unloading += ctx => Console.WriteLine("=-=-=-=-=CTX UNLOADED-=-=-=-=-=-");

Console.WriteLine("============= AFTER LOADING");
RenderAssemblies();

Type? type = assembly.GetType("_03_MathLib.Calculator");

// -- static call
//MethodInfo? method = type?.GetMethod("Factorial");
//int? result = (int?)method.Invoke(assembly, new object[] { 5 });
//Console.WriteLine($"Factorial = {result}");

// -- non-static call
MethodInfo? method = type?.GetMethod("Sum");
object? calc = Activator.CreateInstance(type);
int? result = (int?)method.Invoke(calc, new object[] { 5, 6 });
Console.WriteLine($"Sum = {result}");

ctx.Unload();
GC.Collect();

Console.WriteLine("============= AFTER UNLOADING");
RenderAssemblies();


void RenderAssemblies()
{
    AppDomain domain = AppDomain.CurrentDomain;
    Console.WriteLine($"{domain.FriendlyName}\t{domain.BaseDirectory}");
    Console.WriteLine("ASSEMBLIES:");
    foreach (Assembly a in domain.GetAssemblies())
        Console.WriteLine($"{a.GetName().Name}\t{a.GetName().Version}");
}

#endregion


