using System;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class InventoryAnimationController : MonoBehaviour
{
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("isOpen", false);
    }

    public void OpenInventory()
    {
        anim.SetBool("isOpen", true);
    }

    public void CloseInventory()
    {
        anim.SetBool("isOpen", false);
    }
}
