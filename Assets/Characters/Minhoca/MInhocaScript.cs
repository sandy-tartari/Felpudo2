using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinhocaScript : MonoBehaviour
{
    public float velocity;
    private Rigidbody2D body;
    private GameObject player, gameController;
    private bool scoreUp;
    void Start()
    {
        this.body = GetComponent<Rigidbody2D>();
        this.body.velocity = new Vector2(this.velocity,0);
        this.player = GameObject.FindGameObjectWithTag("Player");
        this.gameController = GameObject.FindGameObjectWithTag("GameController");
        this.scoreUp = false;
    }

    void Update()
    {
        if (this.transform.position.x < -25)
        {
            Destroy(this.gameObject);
        } else 
        {
            if (this.transform.position.x < this.player.transform.position.x)
            {
                if(!this.scoreUp)
                {
                    this.gameController.SendMessage("ScorePlusOne");
                    this.scoreUp = true;
                }
            }
        }
        
    }
}
