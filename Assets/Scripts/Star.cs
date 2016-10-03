using UnityEngine;
using System.Collections;

public class Star : MonoBehaviour {

    public Sprite[] starSprites;

    SpriteRenderer spriteRenderer;
    float moveSpeed = 1f;

	// Use this for initialization
	void Start () {
        spriteRenderer = GetComponent<SpriteRenderer>();
        moveSpeed = 20f + (Random.value * 4f);
	}
	
	// Update is called once per frame
	void Update () {
        transform.position -= new Vector3(moveSpeed * Time.deltaTime, 0.0f, 0.0f);

        if(transform.position.x - spriteRenderer.bounds.size.x < 0)
        {
            float sizey = spriteRenderer.bounds.size.y;
            float posx = 19.2f + (spriteRenderer.bounds.size.x * 2);
            float posy = (sizey / 2) + (Random.value * (10.8f - sizey));
            transform.position = new Vector3(posx, posy, 0.0f);

            // Set random sprite
            int ranSpriteIndex = (int)((Random.value * 0.99f) * 6);
            spriteRenderer.sprite = starSprites[ranSpriteIndex];
        }
    }
}
