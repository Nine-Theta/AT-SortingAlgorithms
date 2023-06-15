using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Selection Sort", menuName = "Sorting Methods/Selection")]
public class S_SelectionSort : S_SortingMethod
{
    [SerializeField, EnableIf("_enableFieldEdit")]
    private int _indexLowest = 0;

    public int i;


    public override void Setup(int[] pArray)
    {
        base.Setup(pArray);
        _indexLowest = 0;
    }

    public override IEnumerator Sort(bool pLoop = true)
    {
        do
        {
            Step(Index);

            if (Index >= Array.Length - 1)
            {
                IsDone = true;
                break;
            }

            Index++;

            yield return null;
        } while (pLoop);
    }

    protected override void Step(int pIndex)
    {
        _indexLowest = pIndex;

        for (i = 0; i + pIndex < Length; i++)
        {
            Comparisons += 1;
            if (Array[i + pIndex] < Array[_indexLowest])
            {
                _indexLowest = i + pIndex;
            }
        }

        if (_indexLowest != pIndex)
        {
            (Array[pIndex], Array[_indexLowest]) = (Array[_indexLowest], Array[pIndex]);
            ArrayWrites += 2;
        }

        base.Step(pIndex);
    }
}
