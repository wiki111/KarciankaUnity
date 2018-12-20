using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[CreateAssetMenu(menuName = "Actions/OnMouseHoldWithCard")]
public class OnMouseHoldWithCard : Action
{
    public State playerControlState;
    public SO.GameEvent onPlayerControlState;
    public CardVariable currentCard;
    public override void Execute(float d)
    {
        bool mouseIsDown = Input.GetMouseButton(0);

        if (!mouseIsDown)
        {
            List<RaycastResult> results = Settings.GetUIObjects();
            foreach (RaycastResult result in results)
            {
                //Check for droppable areas
                Area a = result.gameObject.GetComponentInParent<Area>();
                if(a != null)
                {
                    a.OnDrop();
                    break;
                }
            }
            currentCard.Get().gameObject.SetActive(true);
            currentCard.Set(null);
            Settings.gameManager.SetState(playerControlState);
            onPlayerControlState.Raise();
            return;
        }
    }
}
