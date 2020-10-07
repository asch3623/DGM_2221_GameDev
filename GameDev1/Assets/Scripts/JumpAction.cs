using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class JumpAction : MonoBehaviour
{

   
    private Rigidbody rb;
    private int jumpCount;
    private int jumpCountMax = 2;
    public float jumpForce = 3f;
    private bool isGrounded = true;
    private Vector3 jumpMove;
   
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        jumpMove = new Vector3(0f, 2f, 0f);

    }

    private void OnCollisionEnter(Collision other)
    {
        isGrounded = true;
        jumpCount = 0;
        
    }
    
    private void OnCollisionExit(Collision other)
    {
        isGrounded = false;
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space) && jumpCount < jumpCountMax)
        {
            rb.AddForce(jumpMove * jumpForce, ForceMode.Impulse);
            jumpCount++;
        }
    }
}