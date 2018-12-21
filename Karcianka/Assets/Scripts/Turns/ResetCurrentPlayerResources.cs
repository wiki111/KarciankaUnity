using UnityEngine;
using System.Collections;

[CreateAssetMenu(menuName = "Turns/Reset Resources Phase")]
public class ResetCurrentPlayerResources : Phase
{
    public override bool IsComplete()
    {
        Settings.gameManager.currentPlayer.MakeAllResourcesUsable();
        return true;
    }

    public override void OnEndPhase()
    {}

    public override void OnStartPhase()
    {}
}
