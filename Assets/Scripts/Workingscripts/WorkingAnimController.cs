using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkingAnimController : MyBaseBehaviour, IWorking
{
    public void GetIdle()
    {
        transform.PlayAnim((int)WorkingState.IDLE);
    }

    public void GetTyping()
    {
        transform.PlayAnim((int)WorkingState.TYPING);

    }
}
public enum WorkingState
{
    IDLE,
    TYPING
}
