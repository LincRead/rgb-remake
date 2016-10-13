using UnityEngine;
using System.Collections;

public class BackGroundBarMovement : MonoBehaviour {

    SpriteRenderer spriteRenderer;
    float moveSpeed = 2f;

    // Use this for initialization
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        moveSpeed = 5f; // + (Random.value * 1f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position -= new Vector3(moveSpeed * Time.deltaTime, 0.0f, 0.0f);

        Bounds b = spriteRenderer.bounds;

        if (b.max.x < 0)
            transform.position = new Vector3(19.2f + (b.size.x / 2), transform.position.y, 0.0f);
    }
}
