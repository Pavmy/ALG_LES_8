//* Реализовать сортировку слиянием.
//Сложность: О(n log n)
# include <stdio.h>
# include <string.h>

 void merge(const int* srcA, size_t cntA, const int* srcB, size_t cntB, int* dst)
{
    while (cntA)
    {
        if (cntB)
        {
            if (*srcA < *srcB)
            {
                *dst++ = *srcA++;
                --cntA;
            }
            else if (*srcA > *srcB)
            {
                *dst++ = *srcB++;
                --cntB;
            }
            else
            {
                *dst++ = *srcA++;
                *dst++ = *srcB++;
                --cntA;
                --cntB;
            }
        }
        else
        {
            *dst++ = *srcA++;
            --cntA;
        }
    }
    while (cntB)
    {
        *dst++ = *srcB++;
        --cntB;
    }
}

int* merge_sort(int* array, size_t count)
{
    if (count > 1)
    {
        int tmp[count];
        merge(merge_sort(array, count / 2), count / 2, merge_sort(array + count / 2, count - count / 2), count - count / 2, tmp);
        memcpy(array, tmp, sizeof(int) * count);
    }
    return array;
}

void dump(const int* array, size_t count)
{
    while (count--)
        printf("%d%c", *array++, (count) ? ' ' : '\n');
}

#define elements_count(a) ( sizeof(a) / sizeof(*(a)) )

int main(void)
{
    int arr[] = { 3, 5, 2, 4, 2, 9, 1, 0, 6, 9, 0, 2 };

    printf("Unsorted: ");
    dump(arr, elements_count(arr));
    printf("Sorted:   ");
    dump(merge_sort(arr, elements_count(arr)), elements_count(arr));

    return 0;
}
