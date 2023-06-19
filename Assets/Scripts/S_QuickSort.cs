using NaughtyAttributes;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Quick Sort", menuName = "Sorting Methods/Quick")]
public class S_QuickSort : S_SortingMethod
{
    [HorizontalLine(color: EColor.Blue)]

    [SerializeField, ReadOnly]
    private int _pivot;

    [SerializeField, ReadOnly]
    private int _partisionIndex = 0;

    [SerializeField, ReadOnly]
    private int _partisionSize;

    [SerializeField, ReadOnly]
    int iLow = 0;
    [SerializeField, ReadOnly]
    int iHigh = 0;

    public override void Setup(int[] pArray)
    {
        base.Setup(pArray);
        /*iLow = Length - 1;
        iHigh = 0;

        Comparisons++;
        if (Array[Length - 1] < Array[0])
        {
            Swap(0, Length - 1);
        }

        Comparisons++;
        if (Array[Length / 2] < Array[Length - 1])
        {
            Swap(Length / 2, Length - 1);
        }


        _pivot = Length - 1;
        _partisionIndex = 0;
        _partisionSize = Length;*/
    }

    public override IEnumerator Sort(bool pLoop = true)
    {
        do
        {
            quicksort(Array, 0, Length-1);
            //Step(Index);

            if (Index >= Array.Length - 1)
            {
                IsDone = true;
                break;
            }


            yield return null;
        } while (true);
    }

    protected override void Step(int pIndex)
    {


        for (int i = iHigh; i < _partisionSize; i++)
        {
            if (Array[i] >= Array[_pivot])
            {
                iHigh = i;
                break;
            }
        }

        for (int j = iLow = _partisionSize - 1; j > 0; j--)
        {
            if (Array[j] < Array[_pivot])
            {
                iLow = j;
                break;
            }
        }


        if (iLow <= iHigh)
        {
            Swap(iHigh, _pivot);
            //Partision(0, _pivot);
        }
        else
            Swap(iLow, iHigh);


        base.Step(pIndex);
    }


    // Sorts a (portion of an) array, divides it into partitions, then sorts those
    private void quicksort(int[] A, int lo, int hi)
    {
        if (lo >= 0 && hi >= 0 && lo < hi)
        {
            int p = partition(A, lo, hi);
            quicksort(A, lo, p); // Note: the pivot is now included
            quicksort(A, p + 1, hi);
        }
    }

    // Divides array into two partitions
    private int partition(int[] A, int lo, int hi)
    {
        // Pivot value
        _pivot = A[((hi - lo) / 2) + lo]; // The value in the middle of the array

        // Left index
        int i = lo - 1;

        // Right index
        int j = hi + 1;


        while (true)
        {
            // Move the left index to the right at least once and while the element at
            // the left index is less than the pivot
            do { i = i + 1; } while (A[i] < _pivot);

            // Move the right index to the left at least once and while the element at
            // the right index is greater than the pivot
            do { j = j - 1; } while (A[j] > _pivot);

            // If the indices crossed, return
            if (i >= j) return j;

            // Swap the elements at the left and right indices
            Swap(i, j);
        }
    }


}
