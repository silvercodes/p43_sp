#region Delegate

//int Add(int a, int b)
//{
//    return a + b;
//}

//MyDelegate del = Add;
//int a = del(3, 4);
//del?.Invoke(3, 4);


//delegate int MyDelegate(int a, int b);





//MyDelegate<int, string> del = .....

//delegate T MyDelegate<T, K>(T a, K b);

#endregion


#region Intro


void RenderPlus()
{
    for (int i = 0; i < 1000; i++)
        Console.Write('+');
}

Thread t = new Thread(RenderPlus);
t.Start();

for (int i = 0; i < 1000; i++)
    Console.Write('0');




#endregion
