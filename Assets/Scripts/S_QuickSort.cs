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
    private int _iLow = 0;
    [SerializeField, ReadOnly]
    private int _iHigh = 0;

    public override void Setup(int[] pArray)
    {
        base.Setup(pArray);

        _iLow = 0;
        _iHigh = Length - 1;
    }

    public override IEnumerator Sort(bool pLoop = true)
    {
        int high = _iHigh;
        int p;

        Comparisons += 3;
        if (_iLow >= 0 & _iHigh >= 0 & _iLow < _iHigh)
        {
            Step(Index);
            p = Index;
            _iHigh = p;
            yield return Sort(); // Note: the pivot is now included
            _iLow = p + 1;
            _iHigh = high;
            yield return Sort();
        }
        else if(_iLow == Length-1)
        {
            InternalDoneSorting.Invoke();
        }
    }

    protected override void Step(int pIndex)
    {
        // Pivot value
        _pivot = Array[((_iHigh - _iLow) / 2) + _iLow]; // The value in the middle of the array

        // Left index
        int i = _iLow - 1;

        // Right index
        int j = _iHigh + 1;


        while (true)
        {
            // Move the left index to the right at least once and while the element at
            // the left index is less than the pivot
            do { i = i + 1; Comparisons++; } while (Array[i] < _pivot);

            // Move the right index to the left at least once and while the element at
            // the right index is greater than the pivot
            do { j = j - 1; Comparisons++; } while (Array[j] > _pivot);

            // If the indices crossed, return
            Comparisons++;
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
