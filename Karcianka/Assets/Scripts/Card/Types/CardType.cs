using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CardType : ScriptableObject {
    public string typeName;
    public bool canAttack;
    //public TypeLogic logic

    public virtual void OnSetType(CardViz viz)
    {
        Element t = Settings.GetResourcesManager().typeElement;
        CardVizProperties type = viz.GetProperty(t);
        type.text.text = typeName;
    }
    
    public bool TypeAllowsForAttack(CardInstance cardInst)
    {
        //e.g flying type can attack even if flatfooted
        /* bool r = logic.Execute(cardInst) -> if(cardInst) is flatfooted  / cardInst is flatfooted = false => return true */

        if (canAttack)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
