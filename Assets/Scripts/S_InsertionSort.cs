using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Insertion Sort", menuName = "Sorting Methods/Insertion")]
public class S_InsertionSort : S_SortingMethod
{
    [SerializeField, ReadOnly, HorizontalLine(color: EColor.Yellow)]
    private int _selected = 0;

    public override void Setup(int[] pArray)
    {
        base.Setup(pArray);
        Index = 1;
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
        _selected = Array[pIndex];

        for (int i = 1; i <= pIndex; i++)
        {
            Comparisons += 1;
            if (_selected < Array[pIndex - i])
            {
                Array[pIndex - i + 1] = Array[pIndex - i];
                ArrayWrites += 1;
            }
            else
            {
                Array[pIndex - i + 1] = _selected;
                ArrayWrites += 1;
                break;
            }

            if(i == pIndex)
            {
                Array[pIndex - i] = _selected;
                ArrayWrites += 1; 
                break;
            }
        }
        base.Step(pIndex);
    }
}
