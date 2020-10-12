using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPlayer : MonoBehaviour
{

    public float speed;
    private Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
    	rb.velocity = new Vector3(0, rb.velocity.y, speed);

        rb.AddForce(Vector3.down * 100f);
    }
}