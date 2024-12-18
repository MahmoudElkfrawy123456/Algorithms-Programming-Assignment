using System;

class Program
{
    static void Main()
    {
        int[] arr = { 4, 9, 2, 7, 4, 3 };

        Console.WriteLine("unsorted array: ");
        Print(arr);
        HeapSort(arr);

        Console.WriteLine("Sorted array: ");
        Print(arr);
    }

    static void BuildMaxHeap(int[] arr)
    {
        int n = arr.Length;
        for (int i = n / 2 - 1; i >= 0; i--)
        {
            Heapify(arr, n, i);
        }
    }

    static void HeapSort(int[] arr)
    {
        int n = arr.Length;
        BuildMaxHeap(arr);

        for (int i = n - 1; i > 0; i--)
        {
            int temp = arr[0];
            arr[0] = arr[i];
            arr[i] = temp;

            Heapify(arr, i, 0);
        }
    }
    static void Print(int[] arr)
    {
        foreach (var item in arr)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();
    }
    static void Heapify(int[] arr, int n, int i)
    {
        int largest = i;
        int left = 2 * i + 1;
        int right = 2 * i + 2;

        if (left < n && arr[left] > arr[largest])
        {
            largest = left;
        }

        if (right < n && arr[right] > arr[largest])
        {
            largest = right;
        }

        if (largest != i)
        {
            int temp = arr[i];
            arr[i] = arr[largest];
            arr[largest] = temp;

            Heapify(arr, n, largest);
        }
    }
}