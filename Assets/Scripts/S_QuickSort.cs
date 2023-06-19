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
    int iLow = 0;
    [SerializeField, ReadOnly]
    int iHigh = 0;

    public override void Setup(int[] pArray)
    {
        base.Setup(pArray);

        iLow = 0;
        iHigh = Length - 1;

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
        int high = iHigh;
        int p;

        if (iLow >= 0 && iHigh >= 0 && iLow < iHigh)
        {
            Step(Index);
            p = Index;
            iHigh = p;
            yield return Sort(); // Note: the pivot is now included
            iLow = p + 1;
            iHigh = high;
            yield return Sort();
        }
    }

    protected override void Step(int pIndex)
    {
        // Pivot value
        _pivot = Array[((iHigh - iLow) / 2) + iLow]; // The value in the middle of the array

        // Left index
        int i = iLow - 1;

        // Right index
        int j = iHigh + 1;


        while (true)
        {
            // Move the left index to the right at least once and while the element at
            // the left index is less than the pivot
            do { i = i + 1; } while (Array[i] < _pivot);

            // Move the right index to the left at least once and while the element at
            // the right index is greater than the pivot
            do { j = j - 1; } while (Array[j] > _pivot);

            // If the indices crossed, return
            if (i >= j)
            {
                Index = j;
                break;
            }
            else
            {
                // Swap the elements at the left and right indices
                Swap(i, j);
            }
        }


        base.Step(pIndex);
    }
}
