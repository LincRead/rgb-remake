using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour {

    public GameObject explosionPixelPrefab;
    public float fadeOutSpeed = 0.5f;

    // Use this for initialization
    void Start () {

    }

    public void CreateExplosion(COLOR color, float radius, int numPixels)
    {
        Vector3 pos = transform.position;

        for (int i = 0; i < numPixels; i++)
        {
            int ang = i * (360 / numPixels);
            Vector3 newPos = new Vector3(
                pos.x + radius * Mathf.Sin(ang * Mathf.Deg2Rad),
                pos.y + radius * Mathf.Cos(ang * Mathf.Deg2Rad),
                pos.z);

            Vector3 dir = (newPos - transform.position).normalized;

            GameObject pixel = GameObject.Instantiate(explosionPixelPrefab, newPos, Quaternion.identity) as GameObject;
            pixel.GetComponent<ExplosionPixel>().Setup(dir, color);
        }
    }
}
