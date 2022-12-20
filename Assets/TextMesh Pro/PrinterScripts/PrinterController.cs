using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrinterController : MyBaseBehaviour,IPrinter
{
    [SerializeField] Transform[] Printer = new Transform[6];
    [SerializeField] float PaperTime;
    [SerializeField] public float Y_Axis;
    [HideInInspector] public float PaperCount = 0;
    void Start()
    {
        GetPrintController();
    }

    public void GetPrintController()
    {
        for (int i = 0; i < Printer.Length; i++)
        {
            Printer[i] = transform.GetChild(0).GetChild(i);
        }

        StartCoroutine(PaperDelay(PaperTime));
    }

    public IEnumerator PaperDelay(float Time)
    {
        
        var PaperIndex = 0;

        while (PaperCount < 200)
        {
            GameObject obj = e_objectPool.ActivePoolObject(ObjectTag.Paper, transform);
            obj.transform.position = transform.GetChild(0).position;
            obj.transform.parent = transform.GetChild(1);

            obj.transform.DOJump(new Vector3(Printer[PaperIndex].transform.position.x, Printer[PaperIndex].transform.position.y + Y_Axis,
                                             Printer[PaperIndex].transform.position.z), 2, 1, 0.5f);

            if (PaperIndex < 5)
            {
                PaperIndex++;
            }

            else
            {
                PaperIndex = 0;
                Y_Axis += .1f;
            }

            yield return new WaitForSeconds(Time);
        }
    }
}
