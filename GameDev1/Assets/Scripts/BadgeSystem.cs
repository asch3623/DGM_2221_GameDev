using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadgeSystem : MonoBehaviour
{
    
    void Start()
    {
        CheckIfHasBadge();
    }

    public void CheckIfHasBadge()
    {
        int i = 0;
        foreach (Transform child in gameObject.transform)
        {
            BadgeMouseOver badge = child.GetComponent<BadgeMouseOver>();

            if (i <= 9)
            {
                if (badge.badge.isObtained)
                {
                    badge.im.sprite = badge.badge.sprite;
                }
            }
            i++;
        }
    }
}
