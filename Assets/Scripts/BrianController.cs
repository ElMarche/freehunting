using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class BrianController : MonoBehaviour
{
    [SerializeField] float moveVelocity = 10.0f;
    [SerializeField] float rotationVelocity = 200.0f;
    [SerializeField] float x, y;
    [SerializeField] float jumpForce = 5.0f;
    [SerializeField] float extraGravity = 0.4f;
    public bool grounded;
    private Animator anim;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");
        transform.Rotate(0, x * Time.deltaTime * rotationVelocity, 0);
        transform.Translate(0, 0, y * Time.deltaTime * moveVelocity);

        anim.SetFloat("VelX", x);
        anim.SetFloat("VelY", y);
        anim.SetFloat("Blend", moveVelocity);

        if (grounded)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                anim.SetBool("isJumping", true);
                rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
            }
            anim.SetBool("isGrounded", true);
        }
        else
        {
            Fall();
        }
    }

    public void Fall()
    {
        anim.SetBool("isGrounded", false);
        anim.SetBool("isJumping", false);
    }
}
