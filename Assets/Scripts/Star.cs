using UnityEngine;
using System.Collections;

// Background objects that moves from right to left side of thr screen.
// When it gets to the left, it changes sprite, and move to the right side of the screen.
public class Star : MonoBehaviour {

    public Sprite[] starSprites;

    SpriteRenderer spriteRenderer;
    public float moveSpeed = 1f;

	void Start () {
        spriteRenderer = GetComponent<SpriteRenderer>();
        moveSpeed = moveSpeed + (Random.value * 1f);
	}
	
	// Update is called once per frame
	void Update () {
        transform.position -= new Vector3(moveSpeed * Time.deltaTime, 0.0f, 0.0f);
        
        // Outside left side of screen
        if(transform.position.x + (spriteRenderer.bounds.size.x / 2) < 0)
        {
            // New pos
            float sizey = spriteRenderer.bounds.size.y;
            float posx = 19.2f + (spriteRenderer.bounds.size.x * 2);
            float posy = (sizey / 2) + (Random.value * (10.8f - sizey));
            transform.position = new Vector3(posx, posy, 0.0f);

            // Set random sprite
            int ranSpriteIndex = (int)((Random.value * 0.99f) * starSprites.Length);
            spriteRenderer.sprite = starSprites[ranSpriteIndex];
        }
    }
}
