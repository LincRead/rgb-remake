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
            case 0: type = POWERUP.DAMAGE_ALL; break;
            case 1: type = POWERUP.DAMAGE_ALL;  break;
            case 2: type = POWERUP.DAMAGE_ALL;  break;
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
