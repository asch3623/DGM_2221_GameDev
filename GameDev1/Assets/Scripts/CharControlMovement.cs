using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]

public class CharControlMovement : MonoBehaviour
    {
        private CharacterController controller;
        private Vector3 moveDirection;
        private float yVar;
        private float turnspeed = 180f;

        public GameObject player;

        public float gravity = 3f, jumpForce = 100f, roSpeed = 5f;
        public int jumpCount, jumpCountMax = 2;
        public FloatData moveSpeed, normalSpeed, fastSpeed;
        private CharacterController _controller;

        private void Start()
        {
            _controller = GetComponent<CharacterController>();
        }

        void Update()
        {

            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                moveSpeed.value = fastSpeed.value;
            }

            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                moveSpeed.value = normalSpeed.value;
            }

            var vInput = Input.GetAxis("Vertical");
            var hInput = Input.GetAxis("Horizontal");
            

            yVar -= gravity;
            
            float input_x = Input.GetAxisRaw("Horizontal");
            float input_y = Input.GetAxisRaw("Vertical");


            moveDirection = new Vector3 (Input.GetAxis ("Horizontal"), 0, Input.GetAxis ("Vertical"));

            if (moveDirection == Vector3.zero)
            {
                return;
            }
            else
            {
                player.transform.rotation = Quaternion.RotateTowards (player.transform.rotation, Quaternion.LookRotation (moveDirection), turnspeed * Time.deltaTime);
            }
                
                
                moveDirection.y -= gravity * Time.deltaTime;
                
                _controller.Move(moveDirection * moveSpeed.value * Time.deltaTime);

          

            if (_controller.isGrounded)
            {
                jumpCount = 0;
                yVar = -0.1f;
            }

            //double jump
            if (Input.GetButtonDown("Jump") && jumpCount < jumpCountMax)
            {
                yVar += Mathf.Sqrt(jumpForce * (-gravity));
                moveDirection.Set(moveSpeed.value * vInput, yVar, hInput);
                jumpCount++;
            }
        }
    }
