using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleTimer
{
    private float _startTime = 0;
    private float _endTime = 0;

    public void Start()
    {
        _startTime = Time.unscaledTime;
        //Debug.Log("started timer");
    }

    public float Stop()
    {
        //Debug.Log("stopped timer");
        return (Time.unscaledTime - _startTime);
    }
}
