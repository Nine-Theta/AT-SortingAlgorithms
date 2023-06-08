using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.WSA;

public class Sorter : MonoBehaviour
{
    public DataToSort Data;

    [ShowNonSerializedField]
    int holder = 0;
    [ShowNonSerializedField]
    int index = 0;
    [ShowNonSerializedField]
    int maxLength = 0;
    [ShowNonSerializedField]
    bool madechange = false;
    [ShowNonSerializedField]
    bool isSetup = false;

    [Button]
    public void BubbleSort()
    {
        if (Data.isSorted) return;
        if (!isSetup)
        {
            maxLength = Data.Sortee.Length-1;
            Data.progress = 0;
            holder = 0;
            index = 0;
            isSetup = true;
        }

        StartCoroutine(Bubble());
    }

    public IEnumerator Bubble()
    {
        if (index > maxLength - 1)
        {
            if (!madechange)
            {
                isSetup = false;
                Data.isSorted = true;
                Data.progress = Data.sortables;
                Debug.Log("Sorting done");
                StopCoroutine(Bubble());
            }
            index = 0;
            madechange = false;
        }

        BubbleStep(index);
        index++;
        yield return null;
    }

    public void BubbleStep(int i)
    {
        Debug.Log(Data.Sortee[i] + " - " + i);
        if (Data.Sortee[i] > Data.Sortee[i + 1])
        {
            holder = Data.Sortee[i];
            Data.Sortee[i] = Data.Sortee[i + 1];
            Data.Sortee[i + 1] = holder;
            madechange = true;
            if (i + 1 == maxLength)
            {
                maxLength--;
                Data.progress++;
            }
        }
    }
}
