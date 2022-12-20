using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyBaseBehaviour : MonoBehaviour
{
    [HideInInspector] public Rigidbody e_rigidbody;
    [HideInInspector] public BoxCollider e_collider;
    [HideInInspector] public Animator e_animator;
    [HideInInspector] public Joystick e_joystick;
    [HideInInspector] public SphereCollider e_sphereCollider;
    [HideInInspector] public ObjectPool e_objectPool;
    [HideInInspector] public MeshRenderer e_meshRenderer;
    [HideInInspector] public PlayerStackController e_playerStack;
    [HideInInspector] public PrinterController e_printerControl;
    [HideInInspector] public PlayerMoveController e_playerMove;
    [HideInInspector] public WorkingAnimController e_workingAnim;
    [HideInInspector] public FileAreaController e_fileArea;
    [HideInInspector] public DollarController e_dolarControl;
    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        e_rigidbody = (GetComponent<Rigidbody>()) ? GetComponent<Rigidbody>() : null;
        e_collider = (GetComponent<BoxCollider>()) ? GetComponent<BoxCollider>() : null;
        e_animator = (GetComponent<Animator>()) ? GetComponent<Animator>() : null;
        e_meshRenderer = GetComponent<MeshRenderer>() ? GetComponent<MeshRenderer>() : null;
        e_sphereCollider = GetComponent<SphereCollider>() ? GetComponent<SphereCollider>() : null;
        e_joystick = (FindObjectOfType<Joystick>()) ? FindObjectOfType<Joystick>() : null;
        e_objectPool = (FindObjectOfType<ObjectPool>()) ? FindObjectOfType<ObjectPool>() : null;
        e_playerStack = (FindObjectOfType<PlayerStackController>()) ? FindObjectOfType<PlayerStackController>() : null;
        e_printerControl = (FindObjectOfType<PrinterController>()) ? FindObjectOfType<PrinterController>() : null;
        e_playerMove= (FindObjectOfType<PlayerMoveController>()) ? FindObjectOfType<PlayerMoveController>() : null;
        e_workingAnim = (FindObjectOfType<WorkingAnimController>()) ? FindObjectOfType<WorkingAnimController>() : null;
        e_fileArea = (FindObjectOfType<FileAreaController>()) ? FindObjectOfType<FileAreaController>() : null;
        e_dolarControl = (FindObjectOfType<DollarController>()) ? FindObjectOfType<DollarController>() : null;
    }
}
