using UnityEngine;
using System.Collections;

public class Bomb : MonoBehaviour
{
    private float moveSpeed = 8f;

    SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        MoveMissile();

        if (transform.position.x - spriteRenderer.bounds.size.x / 2 > 19.2f)
            Destroy(gameObject);
    }

    protected virtual void MoveMissile()
    {
        transform.position += new Vector3(moveSpeed * Time.deltaTime, 0.0f, 0.0f);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
            other.GetComponent<Enemy>().Damage(COLOR.ALL, 1);
        }
    }
}
