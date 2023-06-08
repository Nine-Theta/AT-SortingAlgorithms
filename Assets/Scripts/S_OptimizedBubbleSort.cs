using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Optimized Bubble Sort", menuName ="Sorting Methods/Optimized Bubble")]
public class S_OptimizedBubbleSort : S_SortingMethod
{
    
    [SerializeField]
    private int _maxLength = 0;

    [ShowNonSerializedField]
    private bool _madechange = false;
    public bool isSetup { get; private set; } = false;

    

    public override void Setup(int[] pArray )
    {
        base.Setup( pArray );
        _maxLength = Length - 1;
        isSetup = true;
    }

    public override IEnumerator Sort()
    {
        Step(Index);
        Index++;

        if (Index > _maxLength - 1)
        {
            if (!_madechange)
            {
                isSetup = false;
                Progress = Length;
                Debug.Log("Sorting done");
                IsDone= true;
            }
            Index = 0;
            _madechange = false;
        }

        yield return null;
    }

    protected override void Step(int pIndex)
    {
        if (Array[pIndex] > Array[pIndex + 1])
        {
            Comparisons += 1;

            (Array[pIndex], Array[pIndex + 1]) = (Array[pIndex + 1], Array[pIndex]);
            ArrayWrites += 2;
            _madechange = true;

            if (pIndex + 1 == _maxLength)
            {
                _maxLength--;
                Progress++;
            }
        }
        base.Step(pIndex);
    }
}
