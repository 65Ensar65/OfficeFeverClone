using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FileAreaController : MyBaseBehaviour
{
    private void Start()
    {
        GetInvoke();
    }
    public void GetInvoke()
    {
        InvokeRepeating("GetWork", .005f, 1);
    }
    private void GetWork()
    {
        if (transform.childCount > 1)
        {
            GameObject obj = e_objectPool.ReturnPoolObject(ObjectTag.Paper, transform.GetChild(transform.childCount - 1).gameObject);
            Debug.Log("Delay Active");
        }

        else if (transform.childCount == 1)
        {
            e_workingAnim.GetIdle();
        }
    }

}
