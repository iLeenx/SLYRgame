using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 5f;
    public float turnSpeed = 120f;
    public float jumpForce = 8f;
    public float gravity = -20f;

    private CharacterController controller;
    private Animator anim;

    private Vector3 velocity;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        AutoRun();
        ManualTurn();
        JumpHandler();
    }

    //الركض التلقائي
    void AutoRun()
    {
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        controller.Move(forward * moveSpeed * Time.deltaTime);

        anim.Play("Run");   //أنيميشن الركض دائمًا شغال
    }

    // اللف يمين ويسار
    void ManualTurn()
    {
        float turn = 0f;

        if (Input.GetKey(KeyCode.A))
            turn = -1f;

        if (Input.GetKey(KeyCode.D))
            turn = 1f;

        transform.Rotate(0, turn * turnSpeed * Time.deltaTime, 0);
    }

    //النط بالسبيس
    void JumpHandler()
    {
        if (controller.isGrounded)
        {
            velocity.y = -2f;  


            if (Input.GetKeyDown(KeyCode.Space))
            {
                velocity.y = jumpForce;
                anim.Play("Jump");
            }
        }
        else
        {
            velocity.y += gravity * Time.deltaTime;
        }

        controller.Move(velocity * Time.deltaTime);
    }
}
