#include <iostream>
#include <omp.h>


int main()
{

	int shar = 40;
	int k = 20;
//
//#pragma omp parallel shared(shar) firstprivate(k) 
//	{
//		k++;
//		
//		int rank = omp_get_thread_num();
//		shar++;
//
//		printf("Hello from thread %d   shar = %d  k = %d\n", rank, shar, k);
//
//	}
//
//
//	printf("after parallel  shar = %d  k = %d\n", shar, k);

	const int N = 100000;
	int k1 = 0;
#pragma omp parallel 
	{
		//общий код
		//printf("shared thread - %d\n", omp_get_thread_num());



#pragma omp for //schedule(guided,4)
		for (int i = 0; i < N; i++)
#pragma omp critical
		{
			k1++;
		}
			//printf("iter %d thread - %d\n", i, omp_get_thread_num());

		printf("k1 =  %d\n", k1);



//#pragma omp sections
//		{
//#pragma omp section
//			{
//				printf("section 0 thread - %d\n", omp_get_thread_num());
//			}
//#pragma omp section
//			{
//				printf("section 1 thread - %d\n", omp_get_thread_num());
//			}
//#pragma omp section
//			{
//				printf("section 2 thread - %d\n", omp_get_thread_num());
//			}
//#pragma omp section
//			{
//				printf("section 3 thread - %d\n", omp_get_thread_num());
//			}
//#pragma omp section
//			{
//				printf("section 4 thread - %d\n", omp_get_thread_num());
//			}
//		}
		


	}











	return EXIT_SUCCESS;
}