using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayStoryVideo : MonoBehaviour
{
    Renderer r;
    MovieTexture movie;

    public AudioClip videoAudio;
    private AudioSource audioSource;

    private float timeSincePlay = 0.0f;
    private float duration;
    private bool startedPlayingVideo = false;
    private bool startedTransitionOUT = false;

    public string nextScene = "";
    public bool playAtInit = false;
    public bool canPressToSkip = false;
    public GameObject videoTransitionOut = null;

    void Awake()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = videoAudio;

        r = GetComponent<Renderer>();
        movie = (MovieTexture)r.material.mainTexture;
        movie.Stop();

        r.enabled = false;

        if (playAtInit)
            PlayVideo();
    }

    public void PlayVideo()
    {
        movie = (MovieTexture)r.material.mainTexture;
        duration = movie.duration;

        movie.Play();
        audioSource.Play();

        transform.position = new Vector3(9.6f, 5.4f, -1);
        r.enabled = true;

        timeSincePlay = 0.0f;
        startedPlayingVideo = true;
    }

    void Update()
    {
        if (PressingAnyFireButton())
        {
            if (movie.isPlaying && !startedTransitionOUT)
            {
                movie.Stop();
                PlayTransitionOUT();
            }
        }

        if(startedPlayingVideo && !startedTransitionOUT)
        {
            timeSincePlay += Time.deltaTime;
            if(timeSincePlay > duration)
            {
                movie.Stop();
                PlayTransitionOUT();
            }
        }

        if(startedTransitionOUT)
        {
            timeSincePlay += Time.deltaTime;
            if (timeSincePlay > duration)
            {
                Finish();
            }
        }

        if (!movie.isPlaying)
        {
            transform.position = new Vector3(9.6f, 5.4f, 1);
        }
    }

    void PlayTransitionOUT()
    {
        if(!videoTransitionOut)
        {
            Finish();
            return;
        }

        r.enabled = false;
        movie.Stop();
        videoTransitionOut.GetComponent<PlayMoreVideo>().Play(false);
        duration = videoTransitionOut.GetComponent<PlayMoreVideo>().GetDuration();
        timeSincePlay = 0.0f;
        startedTransitionOUT = true;
    }

    void Finish()
    {
        if (nextScene != "")
            SceneManager.LoadScene(nextScene);
        else
        {
            Destroy(gameObject);
            Destroy(videoTransitionOut);
        }
    }

    bool PressingAnyFireButton()
    {
        if (!canPressToSkip)
            return false;

        if (Input.GetButtonDown("Fire1") || Input.GetButtonDown("Fire2") || Input.GetButtonDown("Fire3") || Input.GetButtonDown("Fire4"))
            return true;

        return false;
    }
}
