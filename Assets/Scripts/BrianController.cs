using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.InputSystem;

public class BrianController : MonoBehaviour
{
    [SerializeField] float moveVelocity = 10.0f;
    [SerializeField] float rotationVelocity = 200.0f;
    //[SerializeField] float x, y;
    [SerializeField] float jumpForce = 5.0f;
    [SerializeField] float extraGravity = 0.4f;
    public bool grounded;
    private Animator anim;
    private Rigidbody rb;
    private Vector2 movementValue;
    private float lookValue;

    // Start is called before the first frame update
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        Cursor.visible= false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    //Update is called once per frame
    void Update()
    {
        //x = Input.GetAxis("Horizontal");
        //y = Input.GetAxis("Vertical");
        //transform.Rotate(0, x * Time.deltaTime * rotationVelocity, 0);
        //transform.Translate(0, 0, y * Time.deltaTime * moveVelocity);
        transform.Translate(movementValue.x * Time.deltaTime,0, movementValue.y * Time.deltaTime);
        transform.Rotate(0, lookValue * Time.deltaTime, 0);

        anim.SetFloat("VelX", movementValue.x);
        anim.SetFloat("VelY", movementValue.y);
        anim.SetFloat("Blend", moveVelocity);

        //if (grounded)
        //{
        //    if (Input.GetKeyDown(KeyCode.Space))
        //    {
        //        anim.SetBool("isJumping", true);
        //        rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
        //    }
        //    anim.SetBool("isGrounded", true);
        //}
        //else
        //{
        //    Fall();
        //}
    }

    public void OnMove(InputValue value)
    {
        movementValue = value.Get<Vector2>() * moveVelocity;
    }

    public void OnLook(InputValue value)
    {
        lookValue = value.Get<Vector2>().x * rotationVelocity;
    }
    public void Fall()
    {
        anim.SetBool("isGrounded", false);
        anim.SetBool("isJumping", false);
    }
}
