using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5.0f;
    [SerializeField] private float jumpForce = 5.0f;
    [SerializeField] private float gravity = -9.81f;

    [SerializeField] private Transform camera;

    private CharacterController controller;
    private bool isGrounded = true;
    private Vector3 velocity;

    private Animator animator;
    private int speedHash = Animator.StringToHash("moveSpeed");
    private int jumpHash = Animator.StringToHash("isJumping");

    private void Awake()
    {
        animator = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        isGrounded = controller.isGrounded;
        if (isGrounded && velocity.y < 0)
        {
            animator.SetBool(jumpHash, false);
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 forward = camera.forward;
        Vector3 right = camera.right;

        forward.y = 0.0f;
        right.y = 0.0f;

        Vector3 dir = forward * z + right * x;

        if (dir.magnitude > 0.1f)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                moveSpeed = 10.0f;
            }
            else 
            {
                moveSpeed = 5.0f;
            }
                controller.Move(dir.normalized * moveSpeed * Time.deltaTime);
            animator.SetFloat(speedHash, moveSpeed);
            transform.rotation = Quaternion.LookRotation(dir);
        }
        else 
        {
            animator.SetFloat(speedHash, 0.0f);
        }

        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            isGrounded = false;
            animator.SetBool(jumpHash, true);
            velocity.y = jumpForce;
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
