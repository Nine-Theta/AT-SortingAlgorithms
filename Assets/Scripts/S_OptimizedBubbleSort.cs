using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Optimized Bubble Sort", menuName ="Sorting Methods/Optimized Bubble")]
public class S_OptimizedBubbleSort : S_SortingMethod
{

    [SerializeField, EnableIf("_enableFieldEdit")]
    private int _maxLength = 0;

    [SerializeField, EnableIf("_enableFieldEdit")]
    private bool _madechange = false;    

    public override void Setup(int[] pArray )
    {
        base.Setup( pArray );
        _maxLength = Length - 1;
    }

    public override IEnumerator Sort(bool pLoop)
    {
        do
        {
            Step(Index);
            Index++;

            if (Index > _maxLength - 1)
            {
                if (!_madechange)
                {
                    Progress = Length;
                    Debug.Log("Sorting done");
                    IsDone = true;
                    break;
                }
                Index = 0;
                _madechange = false;
            }

            yield return null;
        } while (pLoop);
    }

    protected override void Step(int pIndex)
    {
        if (Array[pIndex] > Array[pIndex + 1])
        {
            (Array[pIndex], Array[pIndex + 1]) = (Array[pIndex + 1], Array[pIndex]);
            ArrayWrites += 2;
            _madechange = true;

            if (pIndex + 1 == _maxLength)
            {
                _maxLength--;
                Progress++;
            }
        }
        Comparisons += 1;
        base.Step(pIndex);
    }
}
