using System;
using UnityEngine;

public class AlwaysLookAt : MonoBehaviour
{
    private Transform textMeshObject;
    public Transform myCameraTransform;
    

    private void Update()
    {
        textMeshObject = gameObject.transform;
        textMeshObject.forward = myCameraTransform.forward;
    }
}
