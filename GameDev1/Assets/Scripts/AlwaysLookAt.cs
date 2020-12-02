using System;
using UnityEngine;

public class AlwaysLookAt : MonoBehaviour
{
    private TextMesh textMeshObject;
    public Transform textLookTargetTransform;

    
    
    public void FaceTextMeshToCamera(){
        textMeshObject = GetComponent<TextMesh>();
        Vector3 origRot = textMeshObject.transform.eulerAngles;
        textMeshObject.transform.LookAt(textLookTargetTransform);
        origRot.y = textMeshObject.transform.eulerAngles.y;
        textMeshObject.transform.eulerAngles = origRot;
    }
}
