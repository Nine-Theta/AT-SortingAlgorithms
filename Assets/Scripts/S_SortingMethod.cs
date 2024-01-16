using NaughtyAttributes;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public abstract class S_SortingMethod : ScriptableObject
{
    [HideInInspector]
    public UnityEvent DoneSorting = new UnityEvent();

    protected UnityEvent InternalDoneSorting = new UnityEvent();

    public int[] Array { get; protected set; }

    public int Length { get; protected set; } = 0;

    protected SimpleTimer Timer = new SimpleTimer();

    [SerializeField, ProgressBar("Index", "_lengthDisplay", EColor.Green)]
    protected int Index = 0;
    [SerializeField, ProgressBar("Progress", "Length", EColor.White)]
    protected int Progress = 0;

    private int _lengthDisplay = 0;

    [SerializeField, ReadOnly]
    private bool _isDone = false;

    [SerializeField, ReadOnly]
    private int _stepsTaken = 0;

    [SerializeField, ReadOnly]
    public int Comparisons = 0;

    [SerializeField, ReadOnly]
    public int ArrayWrites = 0;

    [SerializeField, ReadOnly]
    protected int Swaps = 0;

    [SerializeField, ReadOnly]
    public float ElapsedTime = 0f;



    public virtual void Setup(int[] pArray)
    {
        Array = pArray;
        Length = pArray.Length;
        _lengthDisplay = pArray.Length - 1;
        Index = 0;
        Progress = 0;
        _isDone = false;
        _stepsTaken = 0;
        Comparisons = 0;
        ArrayWrites = 0;
        Swaps = 0;
        InternalDoneSorting.AddListener(OnDoneSorting);
        Timer.Start();
    }
    public abstract IEnumerator Sort(bool pLoop = true);
    protected virtual void Step(int pIndex)
    {
        _stepsTaken++;
    }

    protected void Swap(int pIndexA, int pIndexB)
    {
        (Array[pIndexA], Array[pIndexB]) = (Array[pIndexB], Array[pIndexA]);
        ArrayWrites += 2;
        Swaps++;
    }

    private void OnDoneSorting()
    {
        _isDone = true;
        ElapsedTime = Timer.Stop();
        InternalDoneSorting.RemoveListener(OnDoneSorting);
        DoneSorting.Invoke();
    }
}
