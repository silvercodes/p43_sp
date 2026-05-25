#include <iostream>

//int main()
//{
//    //int a{ 5 };
//
//    //std::cout << &a << '\n';
//
//    //int* ptr = &a;
//    //std::cout << ptr;
//
//    //*ptr = 12;
//
//
//    //int** ptr = new int* {};
//
//    //int* p = new int{ 14 };
//
//    //void* x{};
//
//
//    //int* arr = new int[10];
//
//    //for (int i{}; i < 10; ++i)
//    //{
//    //    *(arr + i) = i * 100;
//    //    // >>> EQUALS <<<
//    //    arr[i] = i * 100;
//    //}
//
//
//}




// typedef int(*FuncPtr)(int, int);
using FuncPtr = int(*)(int, int);

int sum(int a, int b)
{
	return a + b;
}
int mul(int x, int y)
{
	return x * y;
}

void execute(int a, FuncPtr fp)
{
	//
	//
	std::cout << fp(a, a);
}

int main()
{
	//int (*fPtr)(int, int) = sum;
	//int res1 = fPtr(3, 4);
	//std::cout << res1 << '\n';

	//std::cout << fPtr << '\n';

	//fPtr = mul;
	//int res2 = fPtr(3, 4);
	//std::cout << res2 << '\n';

	//FuncPtr f1 = sum;

	sum(3, 4);

	FuncPtr f1;
	//
	//
	f1(3, 4);

	return 0;
}

