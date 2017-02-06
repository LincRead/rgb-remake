using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayMoreManager : MonoBehaviour {

    public GameObject videoLoop = null;
    public GameObject videoTransition = null;

    AudioSource audioSource;
    bool playedSound = false;
    bool openingNextScene = false;
    bool playingWholeVideo = false;

    public string nextScene = "";

    float timeToPlayWholeVide = 60.0f;
    float timeSincePlayStartLoop = 0.0f;

    // Use this for initialization
    void Start()
    {
       audioSource = GetComponent<AudioSource>();

        if (videoLoop == null)
            OpenNextScene();
    }

    void Update()
    {
        if (openingNextScene || videoLoop == null)
            return;

        if(PressingAnyFireButton() && !playedSound)
        {
            audioSource.Play();
            playedSound = true;
        }

        if (!videoLoop.GetComponent<PlayMoreVideo>().videoPlaying.isPlaying)
        {
            videoLoop.GetComponent<Transform>().position = new Vector3(9.6f, 5.4f, 1);
            videoTransition.GetComponent<PlayMoreVideo>().Play(false);

            openingNextScene = true;
            Invoke("OpenNextScene", videoTransition.GetComponent<PlayMoreVideo>().videoPlaying.duration);
        }

        GameObject[] wholeVideoObjects = GameObject.FindGameObjectsWithTag("WholeVideo");
        if (!playingWholeVideo && wholeVideoObjects.Length > 0)
        {
            timeSincePlayStartLoop += Time.deltaTime;
            if (timeSincePlayStartLoop >= timeToPlayWholeVide)
            {
                videoLoop.GetComponent<Transform>().position = new Vector3(9.6f, 5.4f, 1);
                videoTransition.GetComponent<PlayMoreVideo>().Play(false);

                openingNextScene = true;
                Invoke("OpenWholeVideo", videoTransition.GetComponent<PlayMoreVideo>().videoPlaying.duration);
            }
        }
    }

    void OpenNextScene()
    {
        openingNextScene = true;
        GameObject[] videoObjects = GameObject.FindGameObjectsWithTag("VideoStory");

        if(videoTransition)
            videoTransition.GetComponent<Transform>().position = new Vector3(9.6f, 5.4f, 1);

        if (videoObjects.Length > 0)
            videoObjects[0].GetComponent<PlayStoryVideo>().PlayVideo();

        else if (nextScene != "")
            SceneManager.LoadScene(nextScene);
    }

    void OpenWholeVideo()
    {
        GameObject[] wholeVideoObjects = GameObject.FindGameObjectsWithTag("WholeVideo");

        if (videoTransition)
            videoTransition.GetComponent<Transform>().position = new Vector3(9.6f, 5.4f, 1);

        wholeVideoObjects[0].GetComponent<PlayWholeMovie>().PlayVideo();

        playingWholeVideo = true;
        openingNextScene = true;
    }

    bool PressingAnyFireButton()
    {
        if(Input.GetButtonDown("Fire1")
            || Input.GetButtonDown("Fire2")
            || Input.GetButtonDown("Fire3")
            || Input.GetButtonDown("Fire4"))
            return true;

        return false;
    }
}

