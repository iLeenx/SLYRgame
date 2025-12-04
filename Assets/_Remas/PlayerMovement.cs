using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class SonicController : MonoBehaviour
{
    public float moveSpeed = 8f;
    public float rotateSpeed = 12f;
    public float jumpForce = 7.5f;
    public float gravity = -25f;
    public Transform groundCheck;
    public float groundDistance = 0.25f;
    public LayerMask groundMask;

    private CharacterController controller;
    private Animator anim;
    private float yVelocity;
    private bool isGrounded;
    private int direction = 1;
    private bool isMovingHorizontal;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (Input.GetKeyDown(KeyCode.D)) direction = 1;
        if (Input.GetKeyDown(KeyCode.A)) direction = -1;

        isMovingHorizontal = (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A));

        if (isGrounded && yVelocity < 0)
            yVelocity = -2f;

        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            yVelocity = Mathf.Sqrt(jumpForce * -2f * gravity);
            anim.SetTrigger("Jump");
        }

        yVelocity += gravity * Time.deltaTime;

        Vector3 move;
        if (isGrounded)
        {
            // الحركة الأفقية الكاملة على الأرض
            float horizontalSpeed = (direction == 1) ? moveSpeed : -moveSpeed;
            move = new Vector3(horizontalSpeed, yVelocity, moveSpeed);
        }
        else
        {
            // الحركة في الهواء: تحافظ على السرعة الأمامية (Z) والسرعة العمودية (Y)، وإلغاء الحركة الجانبية (X) لمنع التزلج
            move = new Vector3(0, yVelocity, moveSpeed);
        }

        controller.Move(move * Time.deltaTime);

        Vector3 targetForward = new Vector3(direction, 0f, 1f).normalized;
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(targetForward), rotateSpeed * Time.deltaTime);

        // تحديث بارامترات الـ Animator
        anim.SetBool("isGrounded", isGrounded);
        anim.SetFloat("verticalSpeed", yVelocity);

        // تشغيل الركض فقط إذا كان على الأرض وهناك حركة
        anim.SetBool("isRunning", isGrounded && (direction == 1 || direction == -1));
    }
}