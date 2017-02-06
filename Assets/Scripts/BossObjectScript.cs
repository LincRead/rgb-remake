using UnityEngine;
using System.Collections;

public class BossObjectScript : MonoBehaviour
{
    public GameObject explosionPrefab;
    public COLOR colorType;

    int hp = 12;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Missile")
        {
            Destroy(other.transform.gameObject);

            if (other.GetComponent<Missile>().missileColor == colorType)
            {
                Damage();
            }
        }
    }

    void Damage()
    {
        hp--;

        GameObject explosionEffect = GameObject.Instantiate(explosionPrefab, transform.position, Quaternion.identity) as GameObject;
        explosionEffect.GetComponent<Explosion>().PlayExplosion(colorType);

        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }
}
