using System.Collections;
using JetBrains.Annotations;
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
  public int jumpCount;
  private int jumpCountMax = 2;
  public float jumpForce = 300f;
  private bool isGrounded = true;
  private Vector3 jumpMove;
  private Vector3 targetRot;
  private float gravity = -3f;
  private float zero  = 0f; 

  private void Start()
  {
    rb = GetComponent<Rigidbody>();
    trail = GetComponent<TrailRenderer>();
   trail.emitting = false;
    coolDown.value = false;
    jumpMove = new Vector3(0f, 2f, 0f);
   targetRot = new Vector3(0,0,0);
    
  }

  private void FixedUpdate()
  
  {
      float rot = Input.GetAxisRaw("Horizontal");
      float v = Input.GetAxisRaw("Vertical");

      Vector3 tempVect = new Vector3(rot, 0, v);
      tempVect = tempVect.normalized * moveSpeed * Time.fixedDeltaTime;
      rb.MovePosition(transform.position + tempVect);

      rot *= Time.fixedDeltaTime;
      transform.Rotate(0, rot*100f, 0);

      //Vector3 lookDirection = (tempVect + gameObject.transform.position);
    //gameObject.transform.LookAt(lookDirection);
    
    

   

    if (Input.GetKey(KeyCode.LeftShift) && !isDarting.value && !coolDown.value)
    {
             isDarting.value = true;
             trail.emitting = true;
             moveSpeed = 50f;
             StartCoroutine(Dart());
    }

    if (Input.GetKeyDown(KeyCode.Space) && jumpCount < jumpCountMax)
    {
      rb.AddForce(new Vector3(0, jumpForce, 0));
          jumpCount++;
    }
   
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
