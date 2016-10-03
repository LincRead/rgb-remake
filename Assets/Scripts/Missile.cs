using UnityEngine;
using System.Collections;

public class Missile : MonoBehaviour {

    public Sprite[] sprites;
    private float moveSpeed = 12f;
    private float velocityY = 0.0f;

    SpriteRenderer spriteRenderer;
    COLOR missileColor;

    // Use this for initialization
    void Start () {

    }

    public void SetColor(COLOR color)
    {
        missileColor = color;
        spriteRenderer = GetComponent<SpriteRenderer>();

        switch (missileColor)
        {
            case COLOR.RED: spriteRenderer.sprite = sprites[0]; break;
            case COLOR.GREEN: spriteRenderer.sprite = sprites[1]; break;
            case COLOR.BLUE: spriteRenderer.sprite = sprites[2]; break;
        }
    }

    public void SetVelocityY(float velY)
    {
        velocityY = velY;
    }

    // Update is called once per frame
    void Update()
    {
        MoveMissile();

        if (transform.position.x - spriteRenderer.bounds.size.x / 2 > 19.2f)
            Destroy(gameObject);
    }

    protected virtual void MoveMissile()
    {
        transform.position += new Vector3(moveSpeed * Time.deltaTime, velocityY * Time.deltaTime, 0.0f);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
            other.GetComponent<Enemy>().Damage(missileColor, 1);
        }
    }
}
