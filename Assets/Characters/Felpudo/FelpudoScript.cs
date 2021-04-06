using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FelpudoScript : MonoBehaviour
{
    public float jumpForce;
    public bool startGame, gameOver;
    public Text mainText;
    private Rigidbody2D body;
    private SpriteRenderer render;
    void Start()
    {
        this.body = GetComponent<Rigidbody2D>();
        this.render = GetComponent<SpriteRenderer>();
        this.body.isKinematic = true;
        this.startGame = false;
        this.gameOver = false;
    }

    void Update()
    {
        if (Input.GetButton("Fire1") && !this.gameOver)
        {
            if (!this.gameOver)
            {
                this.startGame = true;
                this.body.isKinematic = false;
                this.mainText.text = string.Empty;
            }
            this.body.AddForce(new Vector2(0, this.jumpForce));
        }
        this.transform.rotation = Quaternion.Euler(0, 0, body.velocity.y * 3);
    }
    
    void OnCollisionEnter2D(Collision2D other) {
        this.gameOver = true;
        this.body.velocity = Vector2.zero;
        this.body.AddForce(new Vector2(-400, 400));
        this.body.AddTorque(500);
        this.render.color = new Color(1, 0.75f, 0.75f, 1);
        this.mainText.text = "Fim de Jogo!";
    }
}   
