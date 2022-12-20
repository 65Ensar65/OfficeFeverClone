using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DollarTypeController : MyBaseBehaviour,IInteract
{
    ObjectType objectType = ObjectType.Dolar;

    public void Interact(ObjectType type, Transform _transform, Action<ObjectType, Transform> action)
    {
        switch (type)
        {
            case ObjectType.Player:
                e_objectPool.ActivePoolObject(ObjectTag.DollarParticle, transform);
                e_objectPool.ReturnPoolObject(ObjectTag.DollarParticle, gameObject);
                e_dolarControl.PaperIndex = 0;
                e_dolarControl.Y_Axis = 0;
                action.Invoke(objectType, transform);
                break;
            default:
                break;
        }
    }
}
