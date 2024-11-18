using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieTestAnimator : MonoBehaviour
{
    [SerializeField] ForwardMovement movementScript;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        movementScript = GetComponent<ForwardMovement>();
        animator.SetBool("isAlive", true);
    }

    // Update is called once per frame
    void Update()
    {
        
        
        animator.SetFloat("speed", movementScript.speed);

        
    }
}
