using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerStackController : MyBaseBehaviour,IPlayerStack
{
    ObjectType playerType = ObjectType.Player;

    private Transform otherTable;
    private Transform workTable;
    private float y_Axis;
    private float _delay;

    [HideInInspector] public bool IsAnim;

    [SerializeField] List<Transform> PaperList = new List<Transform>();
    [SerializeField] Transform PaperPlace;
    [SerializeField] float LerpSpeed;
    private void Update()
    {
        GetPaperStackControl();
    }
    public void GetPaperAddControl(ObjectType type,Transform other)
    {
        otherTable = other;

        if (PaperList.Count < 21)
        {
            for (int i = otherTable.childCount; i >= 1; i--)
            {
                PaperList.Add(otherTable.GetChild(i - 1));

                if (PaperList.Count > 21)
                    break;
            }
        }

        if (e_printerControl.PaperCount > 1)
            e_printerControl.PaperCount--;

        if (e_printerControl.Y_Axis > 0)
            e_printerControl.Y_Axis = 0.25f;

        IsAnim = true;
    }

    public void GetPaperStackControl()
    {
        if (PaperList.Count > 1)
        {
            for (int i = 1; i < PaperList.Count; i++)
            {
                PaperList[i].parent = null;

                var FirstPos = PaperList.ElementAt(i - 1);
                var SecondPos = PaperList.ElementAt(i);

                SecondPos.position = new Vector3(Mathf.Lerp(SecondPos.transform.position.x, FirstPos.transform.position.x, LerpSpeed * Time.deltaTime),
                                                 Mathf.Lerp(SecondPos.transform.position.y, FirstPos.transform.position.y + .1f, LerpSpeed * Time.deltaTime),
                                                                                            FirstPos.transform.position.z);
            }
        }
    }

    public void GetTablePaperStack(ObjectType type , Transform _transform)
    {
        if (PaperList.Count > 1)
        {
            workTable = _transform;

            if (workTable.childCount > 0)
                y_Axis = workTable.transform.GetChild(workTable.childCount - 1).position.y;

            else
                y_Axis = workTable.position.y;


            for (int i = PaperList.Count - 1; i >= 1; i--)
            {
                PaperList[i].DOJump(new Vector3(workTable.position.x, y_Axis, workTable.position.z), 2f, 1, .2f).SetDelay(_delay).SetEase(Ease.Flash);
                PaperList.ElementAt(i).parent = workTable;
                PaperList.RemoveAt(i);

                y_Axis += 0.1f;
                _delay += 0.01f;

            }

            PaperPlace.parent = transform;
            e_workingAnim.GetTyping();
            IsAnim = false;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        other.GetComponent<IInteract>()?.Interact(playerType, transform, GetPlayerFuncSelect);

    }
    void GetPlayerFuncSelect(ObjectType type, Transform _transform)
    {
        switch (type)
        {
            case ObjectType.Table:
                GetPaperAddControl(playerType, _transform);
                transform.PlayAnim((int)PlayerState.BOXIDLE);
                break;

            case ObjectType.WorkingTable:
                GetTablePaperStack(playerType, _transform);
                transform.PlayAnim((int)PlayerState.BOXIDLE);
                break;

            case ObjectType.Dolar:
                PlayerPrefs.SetInt("money", PlayerPrefs.GetInt("money") + 10);
                break;

            case ObjectType.WorkAreaActive:
                break;
            default:
                break;
        }
    }
}
