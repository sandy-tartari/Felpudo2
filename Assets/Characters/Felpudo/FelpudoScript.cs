using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FelpudoScript : MonoBehaviour
{
    public float jumpForce;
    private Rigidbody2D body;
    void Start()
    {
        this.body = GetComponent<Rigidbody2D>();
        this.body.isKinematic = true;
    }

    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            this.body.isKinematic = false;
            this.body.AddForce(new Vector2(0, this.jumpForce));
        }
        this.transform.rotation = Quaternion.Euler(0, 0, body.velocity.y * 3);
    }
    
}   