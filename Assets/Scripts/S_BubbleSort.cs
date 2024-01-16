using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Bubble Sort", menuName = "Sorting Methods/Bubble")]
public class S_BubbleSort : S_SortingMethod
{
    [HorizontalLine(color: EColor.Gray)]
    [SerializeField, ReadOnly]
    private bool _madechange = false;

    public override void Setup(int[] pArray)
    {
        base.Setup(pArray);
    }

    public override IEnumerator Sort(bool pLoop)
    {
        do
        {
            Step(Index);

            Index++;

            if (Index > Length - 2)
            {
                Index = 0;
                Progress++;

                if (!_madechange)
                {
                    Progress = Length;
                    InternalDoneSorting.Invoke();
                    break;
                }

                _madechange = false;
            }

            yield return null;
        } while (pLoop);
    }

    protected override void Step(int pIndex)
    {
        Comparisons += 1;
        if (Array[pIndex] > Array[pIndex + 1])
        {
            Swap(pIndex, pIndex + 1);
            _madechange = true;
        }
        base.Step(pIndex);
    }
}
