using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class SonicController : MonoBehaviour
{
    public float sideSpeed = 10f;
    public float jumpForce = 15f;
    public float gravity = -25f;

    private CharacterController characterController;
    private Vector3 moveVector;
    private Animator animator;

    // حدود الطريق
    private float minX = -5f;
    private float maxX = 5f;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        
        moveVector.z = 0f;

        // حركة يمين ويسار فقط
        moveVector.x = horizontalInput * sideSpeed;

        // القفز
        if (characterController.isGrounded)
        {
            moveVector.y = 0f;

            if (Input.GetButtonDown("Jump"))
            {
                moveVector.y = jumpForce;
                animator?.SetTrigger("Jump");
            }
        }

        // الجاذبية
        moveVector.y += gravity * Time.deltaTime;

        // التحريك
        characterController.Move(moveVector * Time.deltaTime);

        // منع الحركة خارج الطريق
        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, minX, maxX);

        // منع اللاعب يرجع للخلف إذا انزاح من اصطدام
        pos.z = 0f;

        transform.position = pos;

        // الأنيميشن
        animator?.SetFloat("Speed", Mathf.Abs(horizontalInput));

        // تثبيت الدوران
        transform.rotation = Quaternion.Euler(0, 0, 0);

        // تلف الشخصية يمين ويسار
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
