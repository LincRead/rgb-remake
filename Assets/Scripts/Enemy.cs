using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

    public Sprite[] sprites;
    public float moveSpeed = 0.1f;
    public int HP = 1;

    SpriteRenderer spriteRenderer;
    COLOR enemyColor;

	// Use this for initialization
	void Start () {
        spriteRenderer = GetComponent<SpriteRenderer>();

        SetColor(COLOR.GREEN);
    }

    void SetColor(COLOR color)
    {
        enemyColor = color;

        switch (enemyColor)
        {
            case COLOR.RED: spriteRenderer.sprite = sprites[0]; break;
            case COLOR.GREEN: spriteRenderer.sprite = sprites[1]; break;
            case COLOR.BLUE: spriteRenderer.sprite = sprites[2]; break;
        }
    }
	
	// Update is called once per frame
	void Update () {
        MoveEnemy();

        if (transform.position.x + spriteRenderer.bounds.size.x / 2 < 0)
            Destroy(gameObject);
	}

    protected virtual void MoveEnemy()
    {
        transform.position = new Vector3(transform.position.x - moveSpeed, transform.position.y, transform.position.z);
    }

    public void Damage(COLOR missileColor, int damage)
    {
        if(missileColor == enemyColor)
        {
            HP--;
            if (HP <= 0)
                Kill();
        }
    }

    public void Kill()
    {
        Destroy(gameObject);
    }
}
