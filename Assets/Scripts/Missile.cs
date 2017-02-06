using UnityEngine;
using System.Collections;

public class Missile : MonoBehaviour {

    public Sprite[] sprites;
    private float moveSpeed = 12f;
    private float velocityY = 0.0f;

    SpriteRenderer spriteRenderer;
    public COLOR missileColor;

    [Header("Missile sounds")]
    public AudioClip red;
    public AudioClip green;
    public AudioClip blue;
    public AudioClip all;

    void Start () { }

    public void SetColor(COLOR color)
    {
        missileColor = color;
        spriteRenderer = GetComponent<SpriteRenderer>();

        switch (missileColor)
        {
            case COLOR.RED: spriteRenderer.sprite = sprites[0]; break;
            case COLOR.YELLOW: spriteRenderer.sprite = sprites[1]; break;
            case COLOR.BLUE: spriteRenderer.sprite = sprites[2]; break;
            case COLOR.ALL: spriteRenderer.sprite = sprites[3]; break;
        }
    }

    public void SetVelocityY(float velY)
    {
        velocityY = velY;
    }

    public void PlayMissileSound()
    {
        GameObject audioSourceGameObject = new GameObject();
        AudioSource asource = audioSourceGameObject.AddComponent<AudioSource>();

        AudioClip soundClip = red;

        if (velocityY == 0)
        {
            switch (missileColor)
            {
                case COLOR.RED: soundClip = red; break;
                case COLOR.YELLOW: soundClip = green; break;
                case COLOR.BLUE: soundClip = blue; break;
                case COLOR.ALL: soundClip = red; break;
            }
        }

        asource.PlayOneShot(soundClip);

        // Make sure to remove after sound has finished playing
        audioSourceGameObject.AddComponent<DestroyAfterSoundPlay>();
        audioSourceGameObject.GetComponent<DestroyAfterSoundPlay>().SetDuration(soundClip.length);
    }

    void Update()
    {
        MoveMissile();

        if (transform.position.x - spriteRenderer.bounds.size.x / 2 > 19.2f)
            Destroy(gameObject);
    }

    protected virtual void MoveMissile()
    {
        transform.position += new Vector3(moveSpeed * Time.deltaTime, velocityY * Time.deltaTime, 0.0f);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
            other.GetComponent<Enemy>().Damage(missileColor, 1);
        }
    }
}
