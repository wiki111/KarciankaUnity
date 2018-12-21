using UnityEngine;
using System.Collections;

public abstract class PlayerAction : ScriptableObject
{
    public abstract void Execute(PlayerHolder playerHolder);
}
