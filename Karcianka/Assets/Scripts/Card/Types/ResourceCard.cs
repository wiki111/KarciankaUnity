using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Cards/Resources")]
public class ResourceCard : CardType {
    public override void OnSetType(CardViz viz)
    {
        base.OnSetType(viz);
        viz.statsHolder.SetActive(false);
        viz.resourceHolder.SetActive(false);
    }
}
