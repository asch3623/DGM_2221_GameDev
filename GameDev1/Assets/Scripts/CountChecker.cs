using UnityEngine;
using UnityEngine.Events;

public class CountChecker : MonoBehaviour
{
    public IntData maxCount, count;
    public UnityEvent Event;
    public void CheckMaxAlpacas()
    {
        if (count.value == maxCount.value)
        {
            Event.Invoke();
        }
    }
    
}
