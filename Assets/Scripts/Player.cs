using UnityEngine;
using System.Collections;

public enum COLOR
{
    RED,
    GREEN,
    BLUE,
    ALL
};

public class Player : MonoBehaviour {

    public float moveSpeed = 3f;

    [Header("Missile settings")]
    private float timeBetweenMissileFire = 0.2f;
    private float currTimeBetweenMissileFire;
    public GameObject missilePrefab;

    float timeSinceLastMissileFire;
    SpriteRenderer spriteRenderer;

    // PowerUp
    PowerUp.POWERUP currPowerUp = PowerUp.POWERUP.NONE;
    float timePowerUpsLast = 6f;
    float timeSincePowerUpActivated = 0.0f;


    // Use this for initialization
    void Start () {
        currTimeBetweenMissileFire = timeBetweenMissileFire;
        timeSinceLastMissileFire = currTimeBetweenMissileFire;

        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveShip();
        KeepWithinScreenRectangle();
        HandleFireButtons();
        HandlePowerUps();
    }

    void MoveShip()
    {
        Vector3 velocity = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        velocity = transform.TransformDirection(velocity);
        velocity *= moveSpeed;
        transform.position += velocity;
    }

    void KeepWithinScreenRectangle()
    {
        Transform t = transform;
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        if (t.position.x - sr.bounds.size.x / 2 < 0)
            t.position = new Vector3(0 + sr.bounds.size.x / 2, t.position.y, t.position.z);
        if (t.position.x + sr.bounds.size.x / 2 > 19.2f)
            t.position = new Vector3(19.2f - sr.bounds.size.x / 2, t.position.y, t.position.z);
        if (t.position.y - sr.bounds.size.y / 2 < 0)
            t.position = new Vector3(t.position.x, 0 + sr.bounds.size.y / 2, t.position.z);
        if (t.position.y + sr.bounds.size.y / 2 > 10.8f)
            t.position = new Vector3(t.position.x, 10.8f - sr.bounds.size.y / 2, t.position.z);
    }

    void HandleFireButtons()
    {
        timeSinceLastMissileFire += Time.deltaTime;
        if(timeSinceLastMissileFire >= currTimeBetweenMissileFire)
        {
            if (currPowerUp == PowerUp.POWERUP.DAMAGE_ALL)
            {
                if (Input.GetButton("Fire1") || Input.GetButton("Fire2") || Input.GetButton("Fire3"))
                    FireMissile(COLOR.ALL);
            }

            else
            {
                if (Input.GetButton("Fire1"))
                    FireMissile(COLOR.GREEN);
                else if (Input.GetButton("Fire2"))
                    FireMissile(COLOR.RED);
                else if (Input.GetButton("Fire3"))
                    FireMissile(COLOR.BLUE);
            }
        }
    }

    void HandlePowerUps()
    {
        if(currPowerUp != PowerUp.POWERUP.NONE)
        {
            timeSincePowerUpActivated += Time.deltaTime;
            if (timeSincePowerUpActivated >= timePowerUpsLast)
            {
                currPowerUp = PowerUp.POWERUP.NONE;
            }
        }

        if (currPowerUp == PowerUp.POWERUP.FAST)
            currTimeBetweenMissileFire = timeBetweenMissileFire / 2;
        else
            currTimeBetweenMissileFire = timeBetweenMissileFire;
    }

    void FireMissile(COLOR missileColor)
    {
        GameObject newMissile = GameObject.Instantiate(missilePrefab,
            transform.position + new Vector3(spriteRenderer.bounds.size.x / 2, 0f, 0f),
            Quaternion.identity) as GameObject;
        newMissile.GetComponent<Missile>().SetColor(missileColor);

        if(currPowerUp == PowerUp.POWERUP.TRIPPLE)
        {
            // Up
            newMissile = GameObject.Instantiate(missilePrefab,
            transform.position + new Vector3(spriteRenderer.bounds.size.x / 2, 0f, 0f),
            Quaternion.identity) as GameObject;
            newMissile.GetComponent<Missile>().SetColor(missileColor);
            newMissile.GetComponent<Missile>().SetVelocityY(5f);

            // Down
            newMissile = GameObject.Instantiate(missilePrefab,
            transform.position + new Vector3(spriteRenderer.bounds.size.x / 2, 0f, 0f),
            Quaternion.identity) as GameObject;
            newMissile.GetComponent<Missile>().SetColor(missileColor);
            newMissile.GetComponent<Missile>().SetVelocityY(-5f);
        }

        timeSinceLastMissileFire = 0.0f;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Destroy();
            other.GetComponent<Enemy>().Kill();
        }

        if (other.gameObject.tag == "PowerUp")
        {
            switch(other.gameObject.GetComponent<PowerUp>().GetPowerUpType())
            {
                case PowerUp.POWERUP.FAST:
                    currPowerUp = PowerUp.POWERUP.FAST;
                    timeSincePowerUpActivated = 0.0f;
                    break;

                case PowerUp.POWERUP.TRIPPLE:
                    currPowerUp = PowerUp.POWERUP.TRIPPLE;
                    timeSincePowerUpActivated = 0.0f;
                    break;

                case PowerUp.POWERUP.BOMB:
                    GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
                    foreach(GameObject e in enemies)
                        e.GetComponent<Enemy>().Kill();

                    currPowerUp = PowerUp.POWERUP.NONE;
                    break;

                case PowerUp.POWERUP.DAMAGE_ALL:
                    currPowerUp = PowerUp.POWERUP.DAMAGE_ALL;
                    timeSincePowerUpActivated = 0.0f;
                    break;

                default:
                    currPowerUp = PowerUp.POWERUP.NONE;
                    break;

            }

            other.GetComponent<PowerUp>().Kill();
        }
    }

    public void Destroy()
    {
        GameObject.FindGameObjectWithTag("GameController").GetComponent<GameControllerScript>().GameOver();
        Destroy(gameObject);
    }
}
