using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScript : MonoBehaviour
{
    private float screenWidth;
    void Start()
    {
        Rigidbody2D body = GetComponent<Rigidbody2D>();
        SpriteRenderer renderer = GetComponent<SpriteRenderer>();

        // Pegando o tamanho da imagem
        float imageWidth = renderer.sprite.bounds.size.x;
        float imageHeight = renderer.sprite.bounds.size.y;

        // Pegando o tamanho da tela
        float screenHeight = Camera.main.orthographicSize * 2;
        this.screenWidth = screenHeight / Screen.height * Screen.width;

        // Reescalando o tamanho da imagem para o tamanho da tela
        Vector2 newScale = this.transform.localScale;
        newScale.x = screenWidth / imageWidth + 0.25f;
        newScale.y = screenHeight / imageHeight;
        this.transform.localScale = newScale;

        // Adicionando movimento
        body.velocity = new Vector2(-3, 0);

        if (this.name == "Background2")
        {
            this.transform.position = new Vector2(screenWidth, 0);
        }

    }
        void Update()
    {
        if (this.transform.position.x <= -screenWidth)
        {
            this.transform.position = new Vector2(screenWidth, 0);
        }
        
    }
}