﻿using UnityEngine;
using System.Collections;

public class ExplosionPixel : MonoBehaviour {

    public Sprite[] sprites;
    float fadeOutSpeed = 1f;
    float moveSpeed = 2f;

    COLOR pixelColor;
    Color colorValues; // Rendered color values
    float alphaValue = 1.0f;
    Vector2 velocity = Vector2.zero;

    SpriteRenderer spriteRenderer;

    // Use this for initialization
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void Setup(Vector2 velocity, COLOR color)
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        this.velocity = velocity;

        // Rotate towards direction

        SetColor(color);
    }

    public void SetColor(COLOR color)
    {
        pixelColor = color;

        switch (pixelColor)
        {
            case COLOR.RED: spriteRenderer.sprite = sprites[0]; break;
            case COLOR.GREEN: spriteRenderer.sprite = sprites[1]; break;
            case COLOR.BLUE: spriteRenderer.sprite = sprites[2]; break;
            default: spriteRenderer.sprite = sprites[0]; break;
        }

        colorValues = spriteRenderer.color;
    }

    // Update is called once per frame
    void Update()
    {
        alphaValue -= fadeOutSpeed * Time.deltaTime;

        spriteRenderer.color = new Color(colorValues.r, colorValues.g, colorValues.b, alphaValue);

        // Move
        transform.position += new Vector3(velocity.x, velocity.y, 0.0f) * moveSpeed * Time.deltaTime;

        if (alphaValue <= 0)
            Destroy(gameObject);
    }
}