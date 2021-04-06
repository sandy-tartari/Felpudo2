using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinhocaScript : MonoBehaviour
{
    public float velocity;
    private Rigidbody2D body;
    void Start()
    {
        this.body = GetComponent<Rigidbody2D>();
        this.body.velocity = new Vector2(this.velocity,0);
    }

    void Update()
    {
        
    }
}
