using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
// code from DGM 2670;
public class GameActionHandler : MonoBehaviour
{
    public GameAction[] gameAction;
    public UnityEvent[] handlerEvent;
    public float holdTime;

    private void Start()
    {
        gameAction[a].action += ActionHandler;
    }

    private void ActionHandler()
    {
        Invoke(nameof(OnActionHandler), holdTime);
    }

    private void OnActionHandler()
    {
        handlerEvent.Invoke();
    }
}
