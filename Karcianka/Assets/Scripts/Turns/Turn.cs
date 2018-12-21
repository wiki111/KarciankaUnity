using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Turns/Turn")]
public class Turn : ScriptableObject {
    public Phase[] phases;
    [System.NonSerialized]
    public int currentPhaseIndex = 0;
    public PhaseVariable currentPhase;
    public PlayerHolder player;
    public PlayerAction[] startActions;

    public void OnTurnStart()
    {
        if(startActions == null || startActions.Length == 0)
        {
            return;
        }

        foreach (PlayerAction action in startActions)
        {
            action.Execute(player);
        }
    }

    public bool Execute()
    {
        currentPhase.value = phases[currentPhaseIndex];
        phases[currentPhaseIndex].OnStartPhase();
        bool phaseComplete = phases[currentPhaseIndex].IsComplete();
        bool result = false;
        if (phaseComplete)
        {
            phases[currentPhaseIndex].OnEndPhase();
            currentPhaseIndex++;
            if (currentPhaseIndex > phases.Length - 1)
            {
                currentPhaseIndex = 0;
                result = true;
            }
        }
        return result;
    }

    public void EndCurrentPhase()
    {
        phases[currentPhaseIndex].forceExit = true;
    }
}
