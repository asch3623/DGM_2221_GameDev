 using UnityEngine;
 using UnityEngine.Events;

 [CreateAssetMenu]
public class BadgeObj : ScriptableObject
{
    public string description;
    public bool isObtained;
    public UnityEvent useEvent;
    public Sprite sprite;

    public void ObtainBadge()
    {
        isObtained = true;
        useEvent.Invoke();
    }
}
