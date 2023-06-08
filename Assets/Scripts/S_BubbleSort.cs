using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Bubble Sort", menuName = "Sorting Methods/Bubble")]
public class S_BubbleSort : S_SortingMethod
{
    [SerializeField, EnableIf("_enableFieldEdit")]
    private bool _madechange = false;
    public bool isSetup { get; private set; } = false;


    public override void Setup(int[] pArray)
    {
        base.Setup(pArray);
        isSetup = true;
    }

    public override IEnumerator Sort()
    {
        while (true)
        {

            Step(Index);
            

            yield return null;
        }
    }

    protected override void Step(int pIndex)
    {
        if (Array[pIndex] > Array[pIndex + 1])
        {
            Comparisons += 1;

            (Array[pIndex], Array[pIndex + 1]) = (Array[pIndex + 1], Array[pIndex]);
            ArrayWrites += 2;
            _madechange = true;
        }

        Index++;

        if (Index > Length - 2)
        {

            Index = 0;
            Progress++;

            if (!_madechange)
            {
                isSetup = false;
                Progress = Length;
                Debug.Log("Sorting done");
                IsDone = true;
                return;
            }

            _madechange = false;

        }
        base.Step(pIndex);
    }
}