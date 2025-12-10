using UnityEngine;

public class SamiController : MonoBehaviour
{
    public float sideSpeed = 10f;
    public float jumpForce = 15f;
    public float gravity = 20f;

    public float minX = -4f;
    public float maxX = 4f;

    private CharacterController characterController;
    private Vector3 moveVector;
    private Animator animator;
    private Transform graphicsTransform;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();

        if (animator != null)
        {
            graphicsTransform = animator.transform;
        }
        else
        {
            graphicsTransform = transform;
        }
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        moveVector.x = horizontalInput * sideSpeed;

        if (characterController.isGrounded)
        {
            moveVector.y = -1f;

            if (Input.GetButtonDown("Jump"))
            {
                moveVector.y = jumpForce;
                animator.SetTrigger("Jump");
            }
        }
        else
        {
            moveVector.y -= gravity * Time.deltaTime;
        }

        characterController.Move(moveVector * Time.deltaTime);

        Vector3 currentPosition = transform.position;

        currentPosition.x = Mathf.Clamp(currentPosition.x, minX, maxX);

        transform.position = currentPosition;

        float currentSpeed = Mathf.Abs(horizontalInput);
        if (currentSpeed > 0.01f)
        {
            animator.SetFloat("Speed", 1f);
        }
        else
        {
            animator.SetFloat("Speed", 0f);
        }

        if (graphicsTransform != null)
        {
            if (horizontalInput > 0)
            {
                graphicsTransform.localScale = new Vector3(1, 1, 1);
            }
            else if (horizontalInput < 0)
            {
                graphicsTransform.localScale = new Vector3(-1, 1, 1);
            }
        }
    }
}