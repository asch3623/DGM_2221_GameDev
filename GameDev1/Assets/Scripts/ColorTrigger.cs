using System;
using UnityEngine;


[RequireComponent(typeof(MeshRenderer))]
public class ColorTrigger : MonoBehaviour
{

private MeshRenderer mat;
private Shader shad;
 
    void Start()
    {
        mat = GetComponent<MeshRenderer>();

    }

    private void OnTriggerEnter(Collider other)
    {
        mat.material.color = Color.green;
    }

    private void OnTriggerExit(Collider other)
    {
        mat.material.color = Color.white;
        mat.m
    }
}
