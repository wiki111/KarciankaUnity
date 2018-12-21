using UnityEngine;
using System.Collections;
using SO.UI;
using SO;
using UnityEngine.UI;

public class UpdateTextFromPhase : UIPropertyUpdater
{
    public PhaseVariable currentPhase;
    public Text targetText;

    public override void Raise()
    {
        targetText.text = currentPhase.value.phaseName;
    }
}