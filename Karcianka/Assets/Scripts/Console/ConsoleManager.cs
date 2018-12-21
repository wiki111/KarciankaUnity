using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConsoleManager : MonoBehaviour {
    public Transform consoleGrid;
    public GameObject prefab;
    Text[] textObjects;
    int index;
    public ConsoleHook hook;

    private void Awake()
    {
        hook.consoleManager = this;
        textObjects = new Text[5];
        for (int i = 0; i < textObjects.Length; i++)
        {
            GameObject go = Instantiate(prefab) as GameObject;
            textObjects[i] = go.GetComponent<Text>();
            go.transform.SetParent(consoleGrid);
        }
    }

    public void LoadEvent(string s, Color color)
    {
        index++;
        if(index > textObjects.Length - 1)
        {
            index = 0;
        }
        textObjects[index].color = color;
        textObjects[index].text = s;
        textObjects[index].gameObject.SetActive(true);
        textObjects[index].transform.SetAsLastSibling();
    }
}
