using UnityEngine;
using System.Collections;

[CreateAssetMenu(menuName = "Cards/Creature")]
public class CreatureCard : CardType
{
    public override void OnSetType(CardViz viz)
    {
        base.OnSetType(viz);
        viz.statsHolder.SetActive(true);
        viz.resourceHolder.SetActive(true);
    }
}
