using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DollarController : MyBaseBehaviour,IDolar
{
    [SerializeField] Transform FileArea;
    [SerializeField] Transform[] DollarList = new Transform[8];
    [SerializeField] public float DollarActiveTime;

    [HideInInspector] public float Y_Axis;
    [HideInInspector] public int PaperIndex;

    private float Count;
    void Start()
    {
        GetDollarController();
    }

    public void GetDollarController()
    {
        for (int i = 0; i < DollarList.Length; i++)
        {
            DollarList[i] = transform.GetChild(i);
        }

        StartCoroutine(DollarDelay(DollarActiveTime));
    }

    IEnumerator DollarDelay(float _time)
    {
        while (Count < 200)
        {
            if (FileArea.childCount > 1)
            {
                GameObject obj = e_objectPool.ActivePoolObject(ObjectTag.Dollar, transform);
                obj.transform.parent = transform;
                obj.transform.position = transform.position;

                obj.transform.DOJump(new Vector3(DollarList[PaperIndex].transform.position.x, DollarList[PaperIndex].transform.position.y + Y_Axis,
                                                 DollarList[PaperIndex].transform.position.z), 2, 1, 0.5f);

                if (PaperIndex < 8)
                {
                    PaperIndex++;
                }

                else
                {
                    PaperIndex = 0;
                    Y_Axis += .15f;
                }
            }

            yield return new WaitForSeconds(_time);
        }
    }
}
