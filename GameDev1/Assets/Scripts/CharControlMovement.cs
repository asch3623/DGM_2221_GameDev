﻿
using System;
using System.Collections;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(CharacterController))]

public class CharControlMovement : MonoBehaviour
{
    public float rotateSpeed = 7f;
    public float jumpSpeed = 8f;
    public float gravity = 20f;

    private Vector3 moveDirection = Vector3.zero;
    private CharacterController controller;
    private int jumps;


    public float speed = 4f, climbSpeed = 2f;
    private Vector3 climbDirection;
    public FloatData climbSkill;
    private bool canClimb, canMove;
    public Image ClimbUi;
    private float timeLeft;

    private Transform _char;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        canMove = true;
        timeLeft = climbSkill.value;
        _char = gameObject.transform.Find("Player").transform;


    }
// old
    private void Update()
    {
        if (canMove)
        {
            if (controller.isGrounded)
            {
                moveDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
                moveDirection = transform.TransformDirection(moveDirection);
                moveDirection *= speed;
                if (Input.GetButtonDown("Jump"))
                {
                    moveDirection.y = jumpSpeed;
                }
            }
            else
            {
                       moveDirection = new Vector3(Input.GetAxisRaw("Horizontal"), moveDirection.y, Input.GetAxisRaw("Vertical"));
                       moveDirection = transform.TransformDirection(moveDirection);
                       moveDirection.x *= speed;
                       moveDirection.z *= speed;
            }
               
            
            if (moveDirection.magnitude <= 0.01f)
            {
                moveDirection.y -= gravity * Time.deltaTime;
                return;
            }
            Quaternion LookAtRotation = Quaternion.LookRotation( moveDirection );
            Quaternion LookAtRotationOnly_Y = Quaternion.Euler(_char.transform.rotation.eulerAngles.x, LookAtRotation.eulerAngles.y, _char.transform.rotation.eulerAngles.z);
               
            //_char.transform.rotation = LookAtRotationOnly_Y;
            _char.rotation = Quaternion.Lerp(_char.rotation, LookAtRotationOnly_Y, Time.deltaTime * rotateSpeed);
            moveDirection.y -= gravity * Time.deltaTime;
            controller.Move(moveDirection * Time.deltaTime);
        }
       
        if (canClimb)
        {
            Climb();
        }
    
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "ClimbWall")
        {
            canMove = false;
            canClimb = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "ClimbWall")
        {
            canMove = true;
            canClimb = false;
        }
    }


    private void Climb()
    {
        StartCoroutine(climbTime());
        
                if (timeLeft > 0)
                {
                    timeLeft -= Time.deltaTime;
                    ClimbUi.fillAmount = timeLeft / climbSkill.value;
                }
                
        climbDirection = new Vector3(0, Input.GetAxis("Vertical"), 0);
        climbDirection.y *= climbSpeed;
        controller.Move(climbDirection * Time.deltaTime);
                                    
        if (Input.GetKeyDown(KeyCode.Space))
        {
            canClimb = false;
                canMove = true;
                timeLeft = climbSkill.value;
        }
    }

    public void CanClimbTrue(bool setClimb)
    {
        canClimb = setClimb;
    }

    private IEnumerator climbTime()
    {
        yield return new WaitForSeconds(climbSkill.value);
        canClimb = false;
        canMove = true;
        timeLeft = climbSkill.value;
    }
    
    
    
    
    // made from using, https://www.mvcode.com/lessons/unity-rpg-character-controller-jamie, Unity RPG Tutorial from MVCode
    // private void Update()
    // {
    //     Movement();
    // }
    //
    // void Movement()
    // {
    //     float x = Input.GetAxisRaw("Horizontal");
    //     float z = Input.GetAxisRaw("Vertical");
    //     
    //     Vector3 direction = new Vector3(x,0,z).normalized;
    //     Vector3 velocity = direction * speed * Time.deltaTime;
    //     controller.Move(velocity);
    //
    //     if (velocity.magnitude > 0)
    //     {
    //        float yAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
    //        Vector3 targetRotationDirection = new Vector3(0, yAngle, 0);
    //        transform.localEulerAngles = Vector3.Slerp(transform.localEulerAngles, targetRotationDirection, Time.deltaTime * rotateSpeed);
    //                //transform.localEulerAngles = new Vector3(0, yAngle, 0); 
    //     }
    //     
    // }
}

