//Реализовать быструю сортировку.
//Сложность: О(n log n) или О(n*n) для упорядочения больших случайных списков

#include <stdio.h>
#include <stdlib.h>

void quickSort(int* numbers, int left, int right)
{
    int pivot; 
    int l_hold = left; 
    int r_hold = right; 
    pivot = numbers[left];
    while (left < right) 
    {
        while ((numbers[right] >= pivot) && (left < right))
            right--; 
        if (left != right) 
        {
            numbers[left] = numbers[right]; 
            left++; 
        }
        while ((numbers[left] <= pivot) && (left < right))
            left++; 
        if (left != right)
        {
            numbers[right] = numbers[left];
            right--; 
        }
    }
    numbers[left] = pivot;
    pivot = left;
    left = l_hold;
    right = r_hold;
    if (left < pivot)
        quickSort(numbers, left, pivot - 1);
    if (right > pivot)
        quickSort(numbers, pivot + 1, right);
}
int main()
{
    int a[10];
    for (int i = 0; i < 10; i++)
        a[i] = rand() % 20 - 10;

    for (int i = 0; i < 10; i++)
        printf("%d ", a[i]);
    printf("\n");
    quickSort(a, 0, 9); 

    for (int i = 0; i < 10; i++)
        printf("%d ", a[i]);
    printf("\n");
    getchar();
    return 0;
}
