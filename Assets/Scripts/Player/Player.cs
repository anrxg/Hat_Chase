using UnityEngine;
using Photon.Pun;

public class Player : MonoBehaviourPunCallbacks
{
    public float speed = 1f;
    private Rigidbody rb;
    private Animator animator;

    public float fireRange = 30f;
    public GameObject bulletPrefab;
    public Transform firePoint;
    public Transform hatPosition;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        Movement();
        Animations();
        if (Input.GetMouseButtonDown(0))
        {
            Fire();
        }
    }

    void Movement()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputZ = Input.GetAxis("Vertical");

        Vector3 move = new Vector3(inputX, 0f, inputZ);

        if (move.magnitude > 1f)
            move = move.normalized;

        if (move != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(move, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, toRotation, 10f * Time.deltaTime);
        }

        Vector3 targetPosition = rb.position + move * speed * Time.fixedDeltaTime;
        rb.MovePosition(targetPosition);
    }

    void Animations()
    {
        bool isMoving = Input.GetAxis("Horizontal") != 0f || Input.GetAxis("Vertical") != 0f;
        animator.SetBool("isRunning", isMoving);
    }

    void Fire()
    {
        GameObject bullet = PhotonNetwork.Instantiate(bulletPrefab.name, firePoint.position, firePoint.rotation);
    }
}
