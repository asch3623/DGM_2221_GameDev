using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CharacterController))]

public class CharControlMovement : MonoBehaviour
{
    public float speed = 6f;
    public float rotateSpeed = 1.5f;
    public float jumpSpeed = 8f;
    public float gravity = 20f;

    private Vector3 moveDirection = Vector3.zero;
    private CharacterController controller;
    private int jumps;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        
    }

    private void Update()
    {
        if (controller.isGrounded)
        {
                    moveDirection = new Vector3(0, 0, Input.GetAxis("Vertical"));
                    moveDirection = transform.TransformDirection(moveDirection);
                    moveDirection *= speed;
                    if (Input.GetButtonDown("Jump"))
                    {
                        moveDirection.y = jumpSpeed;
                    }
        }
        else
        {
            moveDirection = new Vector3(0, moveDirection.y, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection.x *= speed;
            moveDirection.z *= speed;
        }

        transform.Rotate(0, Input.GetAxis("Horizontal")*rotateSpeed,0);
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);

    }
}

