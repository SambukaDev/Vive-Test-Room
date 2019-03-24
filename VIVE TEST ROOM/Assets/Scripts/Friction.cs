using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Friction : MonoBehaviour {

    public float FrictionMultiplier = 0.1f;

    private Rigidbody rb;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider.gameObject.tag == "Floor")
            rb.drag += FrictionMultiplier;
    }
}
