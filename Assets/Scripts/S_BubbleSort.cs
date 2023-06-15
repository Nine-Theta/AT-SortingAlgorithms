using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Bubble Sort", menuName = "Sorting Methods/Bubble")]
public class S_BubbleSort : S_SortingMethod
{
    [SerializeField, EnableIf("_enableFieldEdit")]
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
                    Debug.Log("Sorting done");
                    IsDone = true;
                    break;
                }

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
        }
        Comparisons += 1;
        base.Step(pIndex);
    }
}
