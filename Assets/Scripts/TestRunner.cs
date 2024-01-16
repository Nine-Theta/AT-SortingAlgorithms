using NaughtyAttributes;
using System;
using System.IO;
using System.Text.RegularExpressions;
using UnityEngine;

public enum DataSets
{
    Inverted_,
    Pyramid__,
    RndOrder_,
    StairTwo_,
    StairFive,
    Half_Half,
    AllZero__,
    RndValues,
    Sorted___,
}

public class TestRunner : MonoBehaviour
{

    [SerializeField]
    private Sorter _sorter;

    [SerializeField]
    private DataToSort _data;

    [SerializeField]
    private int _DataSize = 20;

    [SerializeField]
    private int _iterationsPerData = 1;

    [SerializeField]
    private S_SortingMethod[] _methodsToTest;

    private int _methodCounter = 0;
    private int _iterationCounter = 0;
    private int _setCounter = 0;

    private string _filename = "";

    [Button]
    public void RunTests()
    {
        _filename = String.Format("{0} [{1}-{2}]", System.DateTime.Now.ToString(), _DataSize, _iterationsPerData) ;

        Regex pattern = new Regex("[;,:/]");
        _filename = pattern.Replace(_filename, "-");

        _methodCounter = 0;
        _iterationCounter = 0;
        _setCounter = 0;

        _sorter.SortingMethod = _methodsToTest[_methodCounter];

        _sorter.SortingMethod.DoneSorting.AddListener(OnSortingDone);

        RunNextTest();
    }

    private void RunNextTest()
    {
        PopulateArray((DataSets)_setCounter);
        _sorter.Sort();
    }

    private void OnSortingDone()
    {
        Debug.Log("Done for this sort");

        WriteToLog(_methodsToTest[_methodCounter], (DataSets)_setCounter);

        _iterationCounter++;

        if (_iterationCounter >= _iterationsPerData)
        {
            _iterationCounter = 0;
            _setCounter++;
        }

        if (_setCounter >= 9)
        {
            _setCounter = 0;
            _methodCounter++;

            _sorter.SortingMethod.DoneSorting.RemoveListener(OnSortingDone);

            if (_methodCounter < _methodsToTest.Length)
            {
                _sorter.SortingMethod = _methodsToTest[_methodCounter];
                _sorter.SortingMethod.DoneSorting.AddListener(OnSortingDone);
            }
            else
            {
                Debug.Log("All tests done!");
                return;
            }
        }

        RunNextTest();
    }


    private void PopulateArray(DataSets pDataSet)
    {
        switch (pDataSet)
        {
            case DataSets.Inverted_: //Inverted
                _data.PopulateArrayInverted();
                break;
            case DataSets.Pyramid__: //Pyramid
                _data.PopulateArrayTriangle();
                break;
            case DataSets.RndOrder_: //Random Order
                _data.PopulateArrayRandomOrder();
                break;
            case DataSets.StairTwo_: //Stair 2
                _data.StairStepSize = 2;
                _data.PopulateArrayStair();
                break;
            case DataSets.StairFive: //Stair 5
                _data.StairStepSize = 5;
                _data.PopulateArrayStair();
                break;
            case DataSets.Half_Half: //Half-n-Half
                _data.StairStepSize = _data.ArraySize;
                _data.PopulateArrayStair();
                break;
            case DataSets.AllZero__: //All 0
                _data.randomRange = 0;
                _data.PopulateArrayRandomValues();
                break;
            case DataSets.RndValues: //Random Values 0-100
                _data.randomRange = 100;
                _data.PopulateArrayRandomValues();
                break;
            case DataSets.Sorted___: //Sorted
                _data.PopulateArrayInverted();
                _data.ReverseArray();
                break;
        }
    }

    private void WriteToLog(S_SortingMethod pMethod, DataSets pDataSet)
    {
        string path = Application.dataPath + "/Resources/";

        //Write some text to the test.txt file
        StreamWriter writer = new StreamWriter(path + _filename + ".txt", true);

        string text = String.Format("{0} | {1} [{2}] | Writes: [{3}] | Comparisons: [{4}] | Time: [{5}]", pMethod.name, pDataSet, pMethod.Length, pMethod.ArrayWrites, pMethod.Comparisons, pMethod.ElapsedTime);// "Method, Size, variation, arraywrites, time";

        writer.WriteLine(text);
        writer.Close();
    }
}