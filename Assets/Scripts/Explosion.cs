using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour {

    public float duratiom = 0.583f;
    float timeSinceSpawn = 0.0f;
    public AudioClip[] soundClips;
    Animator animator;

    // Use this for initialization
    void Start () {
        
    }

    public void PlayExplosion(COLOR colorType)
    {
        animator = GetComponent<Animator>();
        switch (colorType)
        {
            case COLOR.RED: animator.Play("redexp"); break;
            case COLOR.YELLOW: animator.Play("yellowexp"); break;
            case COLOR.BLUE: animator.Play("blueexp"); break;
            case COLOR.ALL: animator.Play("allexp"); break;
        }

        PlaySound();
    }

    void Update()
    {
        timeSinceSpawn += Time.deltaTime;
        if(timeSinceSpawn > duratiom)
        {
            Destroy(gameObject);
        }
    }

    void PlaySound()
    {
        int num = (int)((Random.value * 0.99f) * soundClips.Length);
        GameObject audioSourceGameObject = new GameObject();
        AudioSource asource = audioSourceGameObject.AddComponent<AudioSource>();
        asource.PlayOneShot(soundClips[num]);
        audioSourceGameObject.AddComponent<DestroyAfterSoundPlay>();
        audioSourceGameObject.GetComponent<DestroyAfterSoundPlay>().SetDuration(soundClips[num].length);
    }
}
