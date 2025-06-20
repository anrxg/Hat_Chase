using UnityEngine;

public class Player : MonoBehaviour
{
    private float speed = 3f;
    private float jumpForce;
    [SerializeField] private Transform cameraTransform;
    Rigidbody rb;
    Animator animator;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        Movement();
        Animations();
    }

    void Movement()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");
        Vector3 move = new Vector3(inputX, 0, inputY);

        if (move != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(move, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, toRotation, 15f * Time.deltaTime);
        }
        transform.Translate(move * speed * Time.deltaTime, Space.World);
    }

    void Animations()
    {
        bool isMoving = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D);
        animator.SetBool("isRunning", isMoving);
    }
}
