using UnityEngine;
using System.Collections;

public enum COLOR
{
    RED,
    GREEN,
    BLUE
};

public class Player : MonoBehaviour {

    public float moveSpeed = 3f;
    public GameObject missilePrefab;

    SpriteRenderer spriteRenderer;

    // Use this for initialization
    void Start () {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveShip();
        KeepWithinScreenRectangle();
        HandleFireButtons();
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
        if (Input.GetButtonDown("Fire1"))
            FireMissile(COLOR.GREEN);
        if (Input.GetButtonDown("Fire2"))
            FireMissile(COLOR.RED);
        if (Input.GetButtonDown("Fire3"))
            FireMissile(COLOR.BLUE);
    }

    void FireMissile(COLOR missileColor)
    {
        GameObject newMissile = GameObject.Instantiate(missilePrefab,
            transform.position + new Vector3(spriteRenderer.bounds.size.x / 2, 0f, 0f),
            Quaternion.identity) as GameObject;
        newMissile.GetComponent<Missile>().SetColor(missileColor);

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Destroy();
            other.GetComponent<Enemy>().Kill();
        }
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }
}
