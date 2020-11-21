using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu]

public class GameAction : ScriptableObject
{
    public UnityAction action;
    //whenever it is invoked, any handlers will handle it in whatever way
     public void Raise()
     {
         action?.Invoke();
     }
}
