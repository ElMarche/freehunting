using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectGround : MonoBehaviour
{
    public BrianController brianController;

    private void OnTriggerStay(Collider other)
    {
        brianController.grounded = true;
    }

    private void OnTriggerExit(Collider other)
    {
        brianController.grounded = false;
    }
}
