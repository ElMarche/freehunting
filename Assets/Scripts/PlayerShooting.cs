using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] GameObject prefab;
    [SerializeField] GameObject shootPoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void OnFire()
    {
        Instantiate(prefab, shootPoint.transform.position, shootPoint.transform.rotation);
    }
}
