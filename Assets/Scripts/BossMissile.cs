using UnityEngine;
using System.Collections;

public class BossMissile : MonoBehaviour
{

    private float moveSpeed = 8f;

    SpriteRenderer spriteRenderer;

    // Use this for initialization
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        transform.localScale = new Vector3(-1, 1f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x + (spriteRenderer.bounds.size.x / 2) < 0)
        {
            Destroy(gameObject);
            return;
        }

        MoveMissile();
    }

    protected virtual void MoveMissile()
    {
        transform.position += new Vector3(-moveSpeed * Time.deltaTime, 0.0f, 0.0f);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            other.GetComponent<Player>().Destroy();
        }
    }
}
