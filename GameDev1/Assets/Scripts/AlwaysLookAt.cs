using System;
using UnityEngine;

public class AlwaysLookAt : MonoBehaviour
{
    private Transform textMeshObject;
    public Transform myCameraTransform;
    

    public void FaceTextMeshToCamera()
    {
        textMeshObject = gameObject.transform;
        textMeshObject.forward = myCameraTransform.forward;
    }
}
