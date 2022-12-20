using System;
using UnityEngine;

public interface IPlayerMove
{
    void GetMoveController();
}

public interface IPrinter
{
    void GetPrintController();
}

public interface IPlayerStack
{
    void GetPaperAddControl(ObjectType type, Transform other);
    void GetPaperStackControl();
    void GetTablePaperStack(ObjectType type, Transform _transform);
}

public interface IWorking
{
    void GetIdle();
    void GetTyping();
}

public interface IInteract
{
    void Interact(ObjectType type, Transform _transform, Action<ObjectType, Transform> action);
}

public interface IDolar
{
    void GetDollarController();
}

public enum ObjectType
{
    Player,
    Table,
    Dolar,
    WorkingTable,
    DollarParticle,
    WorkAreaActive
}
