using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableType : MyBaseBehaviour, IInteract
{
    ObjectType objectType = ObjectType.Table;
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
