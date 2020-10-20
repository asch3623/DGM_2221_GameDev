﻿using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(TrailRenderer))]
public class CharacterMovement : MonoBehaviour
{
  private Rigidbody rb;
  public float moveSpeed = 30f;
  private int seconds = 1, coolDownSeconds = 7;
  public BoolData coolDown, isDarting;
  private TrailRenderer trail;
  private int jumpCount;
  private int jumpCountMax = 2;
  public float jumpForce = 3f;
  private bool isGrounded = true;
  private Vector3 jumpMove;

  private void Start()
  {
    rb = GetComponent<Rigidbody>();
    trail = GetComponent<TrailRenderer>();
   trail.emitting = false;
    coolDown.value = false;
    jumpMove = new Vector3(0f, 2f, 0f);
    
  }

  private void FixedUpdate()
  
  {
   float moveH = Input.GetAxis("Horizontal");
   float moveV = Input.GetAxis("Vertical");
    var movement = new Vector3(moveH, 0f, moveV)* Time.fixedDeltaTime * moveSpeed;
   
    transform.Translate (movement * moveSpeed * Time.fixedDeltaTime, Space.World);
    
    if (rb.velocity != Vector3.zero)
    { 
      transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), 0.3F);
    }
   

    if (Input.GetKeyDown(KeyCode.LeftShift) && !isDarting.value && !coolDown.value)
    {
             isDarting.value = true;
             trail.emitting = true;
             moveSpeed = 50f;
             StartCoroutine(Dart());
    }

    if (!Input.GetKeyDown(KeyCode.Space) || jumpCount >= jumpCountMax) return;
    rb.AddForce(jumpMove * jumpForce, ForceMode.Impulse);
    jumpCount++;
  }

  private void OnCollisionEnter(Collision other)
  {
    jumpCount = 0;
  }


  private IEnumerator Dart()
  {
    yield return new WaitForSeconds(seconds);
    moveSpeed = 10f;
    isDarting.value = false;
    trail.emitting = false;
    coolDown.value = true;
    yield return new WaitForSeconds(coolDownSeconds);
    coolDown.value = false;
  }
}