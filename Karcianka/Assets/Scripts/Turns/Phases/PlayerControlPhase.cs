using UnityEngine;
using System.Collections;

[CreateAssetMenu(menuName ="Turns/Player Control Phase")]
public class PlayerControlPhase : Phase
{
    public State playerControlState;
    public override bool IsComplete()
    {
        //Things to do after player ends control phase
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
            Debug.Log(this.name + " starts");
            Settings.gameManager.SetState(playerControlState);
            Settings.gameManager.onPhaseChanged.Raise();
            isInit = true;
        }
    }
}
