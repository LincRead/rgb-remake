using UnityEngine;
using System.Collections;

public class BackGroundBarMovement : MonoBehaviour {

    SpriteRenderer spriteRenderer;
    public float moveSpeed = 20f;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        transform.position -= new Vector3(moveSpeed * Time.deltaTime, 0.0f, 0.0f);

        Bounds b = spriteRenderer.bounds;

        if (b.max.x < 0)
            transform.position = new Vector3(19.2f + 1.5f, transform.position.y, 0.0f);
    }
}
