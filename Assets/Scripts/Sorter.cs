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

    private bool _doSort = false;


    [Button]
    public void Reset()
    {
        SortingMethod.Setup(Data.Sortee);
    }

    [Button]
    public void Sort()
    {
        SortingMethod.Setup(Data.Sortee);
        StartCoroutine(SortingMethod.Sort());
    }

    [Button]
    public void Step()
    {
        SortingMethod.Sort();
    }
}
