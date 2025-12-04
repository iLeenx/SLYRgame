using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class SonicController : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float jumpForce = 15f;
    public float gravity = -25f;

    private CharacterController characterController;
    private Vector3 moveVector;
    private Animator animator; 

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>(); 
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        
        moveVector.z = moveSpeed;

        
        moveVector.x = horizontalInput * moveSpeed;

        if (characterController.isGrounded)
        {
            moveVector.y = 0f;

            if (Input.GetButtonDown("Jump"))
            {
                moveVector.y = jumpForce;
               
                if (animator != null)
                {
                    animator.SetTrigger("Jump");
                }
            }
        }

        moveVector.y += gravity * Time.deltaTime;

        characterController.Move(moveVector * Time.deltaTime);

        
        if (animator != null)
        {
            
            animator.SetFloat("Speed", moveVector.z);
        }

        transform.rotation = Quaternion.Euler(0, 0, 0);

        if (horizontalInput > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (horizontalInput < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }
}