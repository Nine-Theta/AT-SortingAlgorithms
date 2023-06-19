using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Sleep Sort", menuName = "Sorting Methods/Sleep")]
public class S_SleepSort : S_SortingMethod
{


    public override void Setup(int[] pArray)
    {
        base.Setup(pArray);
    }

    public override IEnumerator Sort(bool pLoop = true)
    {
        throw new System.NotImplementedException();
    }

    protected override void Step(int pIndex)
    {
        base.Step(pIndex);
    }
}
