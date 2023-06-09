using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//public class ThirdPersonMovement : MonoBehaviour
//{
//    CharacterController controller;
//    public Transform cam;

//    public float speed = 6.0f;
//    public float turnSmoothTime = 0.1f;
//    float turnSmoothVelocity;
//    public float jumpHeight = 15f;
//    public float gravity = -20f;

//    private void Awake()
//    {
//        controller = GetComponent<CharacterController>();
//    }
//    // Update is called once per frame
//    void Update()
//    {
//        float horizontal = Input.GetAxisRaw("Horizontal");
//        float vertical = Input.GetAxisRaw("Vertical");
//        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

//        if(direction.magnitude >= 0.1f)
//        {
//            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
//            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
//            transform.rotation = Quaternion.Euler(0f, angle, 0f);

//            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
//            controller.Move(moveDir.normalized * speed * Time.deltaTime);
//        }

//        if (controller.isGrounded)
//        {
//            if (Input.GetButtonDown("Jump"))
//            {

//            }
//        }

//        //Gravity

//    }
//}

public class ThirdPersonMovement : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam;

    public float speed = 6;
    public float gravity = -9.81f;
    public float jumpHeight = 3;
    Vector3 velocity;
    public bool isGrounded;
    public Animator animator;
    //public bool canDouble;
    public bool canSprint;

    public Transform groundCheck;
    public float groundDistance = 0.01f;
    public LayerMask groundMask;

    float turnSmoothVelocity;
    public float turnSmoothTime = 0.1f;



    // Update is called once per frame
    void Update()
    {
        speed = 6;
        if (animator == null)
        {
            animator = GameObject.FindWithTag("SquirrelPreview").GetComponent<Animator>();
        }
        //jump
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        //if (isGrounded)
        //{
        //    canDouble = true;
        //}

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        }

        //if (Input.GetButtonDown("Jump") && !isGrounded && canDouble)
        //{
        //    velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        //    canDouble = false;
        //}
        //double jump

        //sprint
        if (Input.GetKey(KeyCode.LeftShift)){
            speed = 12;
        }

        //gravity
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        //walk
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
        }

        //animate run
        animator.SetFloat("Speed", direction.magnitude);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Car")
        {
            Cursor.visible = true;
            Destroy(gameObject);
            SceneManager.LoadScene("Lose");
        }
    }
}