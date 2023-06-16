using NaughtyAttributes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class DataToSort : MonoBehaviour
{
    //public GameObject Cube;

    [MinValue(0)]
    public int ArraySize = 10;
    public int randomRange = 100;

    public bool UseSeed = false;
    [ShowIf("UseSeed")]
    public int RandomSeed;

    [Range(1,20)]
    public int StairStepSize = 1;

    [HorizontalLine(color: EColor.Orange)]
    public int[] ArrayToSort;

    [Button]
    public void PopulateArrayRandomValues()
    {
        if(UseSeed)
            UnityEngine.Random.InitState(RandomSeed);

        ArrayToSort = new int[ArraySize];

        for(int i = 0; i< ArraySize; i++)
        {
            ArrayToSort[i] = UnityEngine.Random.Range(0,randomRange);
        }
    }

    [Button]
    public void PopulateArrayRandomOrder() //Fisher-Yates Shuffle
    {
        PopulateArrayInverted();
        ShuffleArray();        
    }

    [Button]
    public void PopulateArrayInverted()
    {
        ArrayToSort = new int[ArraySize];
        for (int i = 0; i < ArraySize; i++)
        {
            ArrayToSort[i] = ArraySize - i;
        }
    }

    [Button]
    public void PopulateArrayTriangle()
    {
        ArrayToSort = new int[ArraySize];

        int i;

        for (i = 0; i < ArraySize*0.5; i++)
        {
            ArrayToSort[i] = i*2;
        }

        while (i < ArraySize)
        {
            ArrayToSort[i] = ArraySize*2 - i*2 -1;
            i++;
        }
    }

    [Button]
    public void PopulateArrayStair()
    {
        ArrayToSort = new int[ArraySize];

        int k = ArraySize / StairStepSize +1;

        for(int i = 0; i < ArraySize; i++)
        {
            ArrayToSort[i] = (i % k)*StairStepSize;
        }
    }


    [Button]
    public void ShuffleArray()
    {
        if (UseSeed)
            UnityEngine.Random.InitState(RandomSeed);

        int rand = 0;
        int item = 0;

        for (int i = ArrayToSort.Length; i > 1;)
        {
            rand = UnityEngine.Random.Range(0, i--);
            item = ArrayToSort[i];
            ArrayToSort[i] = ArrayToSort[rand];
            ArrayToSort[rand] = item;
        }
    }

    [Button]
    public void ReverseArray()
    {
        Array.Reverse(ArrayToSort);
    }

    public void DoCube()
    {
        for(int i = 0; i < ArrayToSort.Length; i++)
        {
            //Instantiate(Cube, new Vector3(ArrayToSort[i],0,0), Quaternion.identity);
        }
    }
}
