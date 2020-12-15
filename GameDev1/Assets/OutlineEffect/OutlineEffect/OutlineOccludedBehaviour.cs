using cakeslice;
using UnityEngine;

public class OutlineOccludedBehaviour : MonoBehaviour
{
    public Outline playerOutline;

    private void Start()
    {
        playerOutline.enabled = false;
    }

    private void Update()
    {
        if (Physics.Raycast(transform.position, transform.forward, 7f, LayerMask.GetMask("CamWall")))
        {
            playerOutline.enabled = true;
        }
        else
        {
            playerOutline.enabled = false;
        }
    }
}