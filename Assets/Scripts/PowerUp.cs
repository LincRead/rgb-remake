using UnityEngine;
using System.Collections;

public class PowerUp : MonoBehaviour {

    public Sprite[] sprites;
    public float moveSpeed = 1f;

    POWERUP type;
    SpriteRenderer spriteRenderer;

    public enum POWERUP
    {
        TRIPPLE,
        FAST,
        BOMB,
        NONE
    };

    // Use this for initialization
    void Start () {
        spriteRenderer = GetComponent<SpriteRenderer>();
        SetRandomType();
	}

    public void SetRandomType()
    {
        int ranNum = (int)((Random.value * 0.99f) * 3);

        switch (ranNum)
        {
            case 0: spriteRenderer.sprite = sprites[0]; type = POWERUP.FAST; break;
            case 1: spriteRenderer.sprite = sprites[1]; type = POWERUP.TRIPPLE;  break;
            case 2: spriteRenderer.sprite = sprites[2]; type = POWERUP.BOMB;  break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        MovePowerUp();

        if (transform.position.x + spriteRenderer.bounds.size.x / 2 < 0)
            Destroy(gameObject);
    }

    protected virtual void MovePowerUp()
    {
        transform.position -= new Vector3(moveSpeed * Time.deltaTime, 0.0f, 0.0f);
    }

    public void Kill()
    {
        Destroy(gameObject);
    }

    public POWERUP GetPowerUpType()
    {
        return type;
    } 
}
