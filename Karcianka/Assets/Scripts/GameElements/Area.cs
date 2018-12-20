using UnityEngine;
using UnityEditor;

public class Area : MonoBehaviour
{
    public AreaLogic logic;
    public void OnDrop()
    {
        logic.Execute();
    }
}