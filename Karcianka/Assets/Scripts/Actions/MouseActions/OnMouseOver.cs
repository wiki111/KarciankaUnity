using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System.Collections.Generic;

[CreateAssetMenu(menuName = "Actions/OnMouseOver")]
public class OnMouseOver : Action
{

    //Does a raycast to see what element is below
    public override void Execute(float d)
    {
        List<RaycastResult> results = Settings.GetUIObjects();
        
        IClickable c = null;

        foreach(RaycastResult result in results){
            c = result.gameObject.GetComponentInParent<IClickable>();
            if(c != null)
            {
                c.OnHighlight();
                break;
            }
        }
    }
}
