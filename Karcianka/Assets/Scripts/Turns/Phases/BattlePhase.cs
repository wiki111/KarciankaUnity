using UnityEngine;
using System.Collections;

[CreateAssetMenu(menuName = "Turns/Battle Phase")]
public class BattlePhase : Phase
{
    public State battlePhaseControl;
    public Condition isBattleValid;

    public override bool IsComplete()
    {
        if (forceExit)
        {
            forceExit = false;
            return true;
        }
        return false;
    }

    public override void OnEndPhase()
    {
        if (isInit)
        {
            Settings.gameManager.SetState(null);
            isInit = false;
        }
    }

    public override void OnStartPhase()
    {
        if (!isInit)
        {
            forceExit = !isBattleValid.IsValid();
            Debug.Log(this.name + " starts");
            Settings.gameManager.SetState(
                (!forceExit) ? battlePhaseControl : null
            );
            Settings.gameManager.onPhaseChanged.Raise();
            isInit = true;
        }
    }
}
