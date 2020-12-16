using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BadgeMouseOver : MonoBehaviour
{
    public GameObject description;
    private Text t;
    public BadgeObj badge;
    public Image im;
    void Awake()
    {
        t = description.transform.GetComponentInChildren<Text>();
        im = GetComponent<Image>();
    }

    public void DisplayInfo()
    {
        description.SetActive(true);
        var x = Input.mousePosition.x + 2 ;
        var y = Input.mousePosition.y + 2;
        description.transform.position = new Vector3(x, description.transform.position.y, description.transform.position.z);
        t.text = badge.description;
    }
    public void OnMouseExit()
    {
        description.gameObject.SetActive(false);
    }
    

}
