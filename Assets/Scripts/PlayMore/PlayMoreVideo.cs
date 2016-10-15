using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayMoreVideo : MonoBehaviour
{
    [HideInInspector]
    public Renderer r;

    [HideInInspector]
    public MovieTexture videoPlaying;

    public AudioClip videoAudio;
    private AudioSource audioSource;

    [HideInInspector]
    public float duration;

    public bool playOnStart = false;

    // Use this for initialization
    void Start()
    {
        r = GetComponent<Renderer>();
        videoPlaying = (MovieTexture)r.material.mainTexture;

        videoPlaying.loop = true;
        duration = videoPlaying.duration;

        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = videoAudio;

        if (playOnStart)
            Play(true);
        else
            videoPlaying.Stop();
    }

    public void Play(bool loop)
    {
        videoPlaying.loop = loop;

        if (videoPlaying.isPlaying)
            return;

        videoPlaying.Play();
        audioSource.Play();
    }

    void Update()
    {
        if (PressingAnyFireButton())
            videoPlaying.loop = false;

        if (!videoPlaying.isPlaying)
        {
            transform.position = new Vector3(0, 0, 0);
        }
    }

    bool PressingAnyFireButton()
    {
        if (Input.GetButtonDown("Fire1")
            || Input.GetButtonDown("Fire2")
            || Input.GetButtonDown("Fire3")
            || Input.GetButtonDown("Fire4"))
            return true;

        return false;
    }
}