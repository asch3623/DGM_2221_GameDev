using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ItemPickUp : MonoBehaviour
{
    public ItemObj item;
    public UnityEvent addedEvent;

    public GameObject textUi;
    
    private int seconds = 1;

    private Text t;
    private Color textColor = Color.green;

    private float textPosY;

    private void Start()
    {
        t = textUi.GetComponent<Text>();
        textPosY = t.gameObject.transform.position.y;
        textColor = t.color;
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.tag == "Player")
        {
            InventorySystem.instance.Add(item);
            addedEvent.Invoke();
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            gameObject.GetComponent<Collider>().enabled = false;
            Destroy(gameObject);

        }
    }
    
    public void CreateText()
    {
        Instantiate(textUi, UIReference.instance.transform);
        //gameObject.transform.parent = thisCanvas.transform;
        t.text = "Added: <color=#00ff00ff>" + item.name + "</color> to inventory!";
    }



}
