using NaughtyAttributes;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sorter : MonoBehaviour
{
    public DataToSort Data;
    [Expandable]
    public S_SortingMethod SortingMethod;

    [Button]
    public void Reset()
    {
        SortingMethod.Setup(Data.ArrayToSort);
    }

    [Button]
    public void Sort()
    {
        SortingMethod.Setup(Data.ArrayToSort);
        StartCoroutine(SortingMethod.Sort());
    }

    [Button]
    public void Step()
    {
        StartCoroutine(SortingMethod.Sort(false));
    }
}
