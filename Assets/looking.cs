using UnityEngine;

public class looking : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float rotationSpeed = 100f;
    public float jumpForce = 5f;

    private CharacterController controller;
    private float verticalVelocity;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        // الحركة قدام وورا
        float move = 0;
        if (Input.GetKey(KeyCode.W)) move = 1;
        if (Input.GetKey(KeyCode.S)) move = -1;

        Vector3 forwardMove = transform.forward * move * moveSpeed;

        // اللف يمين وشمال
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.up * -rotationSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
        }

        // الجاذبية
        if (controller.isGrounded)
        {
            verticalVelocity = -1f;

            // النط
            if (Input.GetKeyDown(KeyCode.Space))
            {
                verticalVelocity = jumpForce;
            }
        }
        else
        {
            verticalVelocity += Physics.gravity.y * Time.deltaTime;
        }

        Vector3 moveVector = forwardMove;
        moveVector.y = verticalVelocity;

        controller.Move(moveVector * Time.deltaTime);
    }
}