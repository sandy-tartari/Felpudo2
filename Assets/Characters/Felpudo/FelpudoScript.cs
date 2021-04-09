using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FelpudoScript : MonoBehaviour
{
    
    public float jumpForce;
    public bool startGame, gameOver;
    private Rigidbody2D body;
    private SpriteRenderer render;
    private GameObject gameController;
    void Start()
    {
        this.body = GetComponent<Rigidbody2D>();
        this.render = GetComponent<SpriteRenderer>();
        this.body.isKinematic = true;
        this.startGame = false;
        this.gameOver = false;
        this.gameController = GameObject.FindGameObjectWithTag("GameController");
    }

    void Update()
    {
        if (Input.GetButton("Fire1") && !this.gameOver)
        {
            if (!this.startGame)
            {
                this.startGame = true;
                this.body.isKinematic = false;
                this.gameController.SendMessage("StartGame");
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
        this.gameController.SendMessage("EndGame");
        Debug.Log(string.Format("Colidiu com {0}", other.gameObject.name));
    }
}   
