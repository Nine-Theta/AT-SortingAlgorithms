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
    public void Setup()
    {
        SortingMethod.Setup(Data.Sortee);
    }

    [Button]
    public void SortStep()
    {
        StartCoroutine(SortingMethod.Sort());
    }

    [Button]
    public void AutoSort()
    {
        SortingMethod.Setup(Data.Sortee);        
        _doSort = !_doSort;
    }

    public void FixedUpdate()
    {
        if (_doSort)
        {
            StartCoroutine(SortingMethod.Sort());
            _doSort = !SortingMethod.IsDone;
        }
    }
}
