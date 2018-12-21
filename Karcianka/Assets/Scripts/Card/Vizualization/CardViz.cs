using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CardViz : MonoBehaviour
{
    public Card card;
    public CardVizProperties[] properties;
    public GameObject statsHolder;
    public GameObject resourceHolder;
    
    public void LoadCard(Card c)
    {

        if (c == null)
            return;

        card = c;
        c.cardType.OnSetType(this);
        CloseAll();

        for (int i = 0; i < c.properties.Length; i++)
        {
            CardProperties cp = c.properties[i];
            CardVizProperties p = GetProperty(cp.element);
            if(p == null)
                continue;

            if(cp.element is ElementText)
            {
                p.text.text = cp.stringVal;
                p.text.gameObject.SetActive(true);
            }

            if (cp.element is ElementImage)
            {
                p.img.sprite = cp.sprite;
                p.img.gameObject.SetActive(true);
            }

            if (cp.element is ElementInt)
            {
                p.text.text = cp.intVal.ToString();
                p.text.gameObject.SetActive(true);
            }
        }
    }

    public CardVizProperties GetProperty(Element e)
    {
        CardVizProperties result = null;

        for(int i = 0; i < properties.Length; i++)
        {
            if(properties[i].element == e && properties[i].element.name == e.name)
            {
                result = properties[i];
                break;
            }
        }

        return result;
    }
    
    public void CloseAll()
    {
        foreach (CardVizProperties property in properties)
        {
            if(property.img != null)
            {
                property.img.gameObject.SetActive(false);
            }

            if(property.text != null)
            {
                property.text.gameObject.SetActive(false);
            }
        }
    }
}
