using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkingController : MyBaseBehaviour
{
    private int Count;

    public float Time;
    void Start()
    {
        StartCoroutine(Delay(Time));
    }

    void Update()
    {
        
    }

    IEnumerator Delay(float _time)
    {
        while (Count < 100)
        {
            yield return new WaitForSeconds(_time);
        }
    }
}
