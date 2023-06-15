using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class S_SortingMethod : ScriptableObject
{
    public int[] Array { get; protected set; }

    public int Length { get; protected set; } = 0;

    public bool IsDone { get; protected set; } = false;

    [SerializeField, ProgressBar("Index", "_lengthDisplay", EColor.Green)]
    protected int Index = 0;
    [SerializeField, ProgressBar("Progress", "Length", EColor.White)]
    protected int Progress = 0;

    private int _lengthDisplay = 0;

    [SerializeField, EnableIf("_enableFieldEdit")]
    private int _stepsTaken = 0;

    [SerializeField, EnableIf("_enableFieldEdit")]
    protected int Comparisons = 0;

    [SerializeField, EnableIf("_enableFieldEdit")]
    protected int ArrayWrites = 0;

    protected bool _enableFieldEdit { get; private set; } = false;


    public virtual void Setup(int[] pArray)
    {
        Array = pArray;
        Length = pArray.Length;
        _lengthDisplay = pArray.Length - 1;
        Index = 0;
        Progress = 0;
        IsDone= false;
        _stepsTaken= 0;
        Comparisons = 0;
        ArrayWrites = 0;
    }
    public abstract IEnumerator Sort(bool pLoop = true);
    protected virtual void Step(int pIndex)
    {
        _stepsTaken++;
    }
}
