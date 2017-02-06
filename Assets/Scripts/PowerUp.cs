using UnityEngine;
using System.Collections;

public class PowerUp : MonoBehaviour {

    public Sprite[] sprites;
    public float moveSpeed = .8f;

    POWERUP_TYPE type;
    SpriteRenderer spriteRenderer;

    public enum POWERUP_TYPE
    {
        TRIPPLE,
        FAST,
        BOMB,
        DAMAGE_ALL,
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
            case 0: type = POWERUP_TYPE.DAMAGE_ALL; spriteRenderer.sprite = sprites[2]; break;
            case 1: type = POWERUP_TYPE.FAST; spriteRenderer.sprite = sprites[0]; break;
            case 2: type = POWERUP_TYPE.TRIPPLE; spriteRenderer.sprite = sprites[1]; break;
        }
    }

    void Update()
    {
        MovePowerUp();

        float scale = 1.2f + (Mathf.Sin(Time.time * 5f) * 0.2f);
        transform.localScale = new Vector3(scale, scale, scale);

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

    public POWERUP_TYPE GetPowerUpType()
    {
        return type;
    } 
}
