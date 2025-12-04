using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class SonicController : MonoBehaviour
{
    public float moveSpeed = 8f;
    public float rotateSpeed = 15f;
    public float jumpForce = 5.5f;
    public float gravity = -20f;
    public Transform groundCheck;
    public float groundDistance = 0.2f;
    public LayerMask groundMask;

    private int direction = 1;
    private CharacterController controller;
    private Animator anim;
    private float yVelocity;
    private bool canJump = true;
    private bool isGrounded;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (Input.GetKeyDown(KeyCode.D)) direction = 1;
        else if (Input.GetKeyDown(KeyCode.A)) direction = -1;

        Vector3 move = new Vector3(direction * moveSpeed, 0, moveSpeed);

        if (isGrounded && yVelocity < 0)
        {
            yVelocity = -2f;
            canJump = true;
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded && canJump)
        {
            yVelocity = Mathf.Sqrt(jumpForce * -2f * gravity);
            anim.SetTrigger("Jump");
            canJump = false;
        }

        yVelocity += gravity * Time.deltaTime;
        move.y = yVelocity;

        controller.Move(move * Time.deltaTime);

        Vector3 targetForward = new Vector3(direction, 0, 1).normalized;
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(targetForward), rotateSpeed * Time.deltaTime);

        anim.SetBool("isRunning", true);
        anim.SetBool("isGrounded", isGrounded);
        anim.SetFloat("verticalSpeed", yVelocity);
    }
}