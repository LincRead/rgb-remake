using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

    public Sprite[] sprites;
    public float moveSpeed = 0.1f;
    public int HP = 1;
    public GameObject explosionPrefab;

    SpriteRenderer spriteRenderer;
    COLOR enemyColor;

	// Use this for initialization
	void Start () {

    }

    public void SetColor(COLOR color)
    {
        enemyColor = color;
        spriteRenderer = GetComponent<SpriteRenderer>();

        switch (enemyColor)
        {
            case COLOR.RED: spriteRenderer.sprite = sprites[0]; break;
            case COLOR.YELLOW: spriteRenderer.sprite = sprites[1]; break;
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
        transform.position -= new Vector3(moveSpeed * Time.deltaTime, 0.0f, 0.0f);
    }

    public void Damage(COLOR missileColor, int damage)
    {
        if(missileColor == enemyColor || missileColor == COLOR.ALL)
        {
            HP--;
            if (HP <= 0)
                Kill();
        }
    }

    public void Kill()
    {
        Destroy(gameObject);

        GameObject explosionEffect = GameObject.Instantiate(explosionPrefab, transform.position, Quaternion.identity) as GameObject;
        explosionEffect.GetComponent<Explosion>().CreateExplosion(enemyColor, 0.3f, 12);
    }
}
