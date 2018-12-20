using UnityEngine;
using System.Collections;

public abstract class Phase : ScriptableObject
{
    [System.NonSerialized]
    protected bool isInit;
    public string phaseName;
    public bool forceExit;
    public abstract bool IsComplete();
    public abstract void OnStartPhase();
    public abstract void OnEndPhase();
}
