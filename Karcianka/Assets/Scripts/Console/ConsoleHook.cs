using UnityEngine;
using System.Collections;

[CreateAssetMenu(menuName ="Console/Hook")]
public class ConsoleHook : ScriptableObject
{
    [System.NonSerialized]
    public ConsoleManager consoleManager;

    public void RegisterEvent(string s, Color color)
    {
        consoleManager.LoadEvent(s, color);
    }
}
