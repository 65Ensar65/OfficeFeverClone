using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkTableType : MyBaseBehaviour, IInteract
{
    ObjectType objectType = ObjectType.WorkingTable;

    public void Interact(ObjectType type, Transform _transform, Action<ObjectType, Transform> action)
    {
        switch (type)
        {
            case ObjectType.Player:
                action.Invoke(objectType, transform);
                break;
            default:
                break;
        }
    }
}
