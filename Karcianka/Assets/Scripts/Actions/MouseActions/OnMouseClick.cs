using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System.Collections.Generic;

[CreateAssetMenu(menuName = "Actions/OnMouseClick")]
public class OnMouseClick : Action
{
    //Does a raycast to see what element is below
    public override void Execute(float d)
    {
        if (Input.GetMouseButtonDown(0))
        {
            List<RaycastResult> results = Settings.GetUIObjects();
            
            IClickable c = null;

            foreach (RaycastResult result in results)
            {
                c = result.gameObject.GetComponentInParent<IClickable>();
                if (c != null)
                {
                    c.OnClick();
                    break;
                }
            }
        }
    }
}
