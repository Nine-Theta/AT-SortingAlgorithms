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

    public bool UseSeed = false;
    [ShowIf("UseSeed")]
    public int RandomSeed;

    [HorizontalLine(color: EColor.Orange)]
    public int[] Sortee;

    [Button]
    public void PopulateArrayRandomValues()
    {
        if(UseSeed)
            Random.InitState(RandomSeed);

        Sortee = new int[sortables];

        for(int i = 0; i< sortables; i++)
        {
            Sortee[i] = Random.Range(0,randomRange);
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
        Sortee = new int[sortables];
        for (int i = 0; i < sortables; i++)
        {
            Sortee[i] = sortables - i;
        }
    }

    [Button]
    public void PopulateArrayTriangle()
    {
        Sortee = new int[sortables];

        int i;

        for (i = 0; i < sortables*0.5; i++)
        {
            Sortee[i] = i*2;
        }

        for (i = i; i < sortables; i++)
        {
            Sortee[i] = sortables*2 - i*2 -1;
        }
    }


    [Button]
    public void ShuffleArray()
    {
        if (UseSeed)
            Random.InitState(RandomSeed);

        int rand = 0;
        int item = 0;

        for (int i = Sortee.Length; i > 1;)
        {
            rand = Random.Range(0, i--);
            item = Sortee[i];
            Sortee[i] = Sortee[rand];
            Sortee[rand] = item;
        }
    }

    public void DoCube()
    {
        for(int i = 0; i < Sortee.Length; i++)
        {
            //Instantiate(Cube, new Vector3(Sortee[i],0,0), Quaternion.identity);
        }
    }
}
