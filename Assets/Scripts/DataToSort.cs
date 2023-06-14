using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class DataToSort : MonoBehaviour
{
    //public GameObject Cube;

    [MinValue(0)]
    public int sortables = 10;

    public int randomRange = 100;    

    [ProgressBar("Progress", "sortables", EColor.White)]
    public int progress = 0;
    [EnableIf("isSorted")]
    public bool isSorted = false;

    public int[] Sortee;

    [Button]
    public void PopulateArrayRandom()
    {
        progress = 0;
        isSorted = false;
        Sortee = new int[sortables];
        for(int i = 0; i< sortables; i++)
        {
            Sortee[i] = Random.Range(0,randomRange);
        }
    }

    [Button]
    public void PopulateArrayInverted()
    {
        isSorted = false;
        progress = 0;
        Sortee = new int[sortables];
        for (int i = 0; i < sortables; i++)
        {
            Sortee[i] = sortables - i;
        }
        DoCube();
    }

    public void DoCube()
    {
        for(int i = 0; i < Sortee.Length; i++)
        {
            //Instantiate(Cube, new Vector3(Sortee[i],0,0), Quaternion.identity);
        }
    }
}
