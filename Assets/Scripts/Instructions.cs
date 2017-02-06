using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Instructions : MonoBehaviour {

    float timeSince = 0f;
    float speed = 1.2f;
    float pause = 5.8f;
    float dir = -1;
    float alpha = 1;
    Color c;

	void Start () {
        c = Color.white;
    }
	
	void Update () {

        timeSince += Time.deltaTime;

        if (dir == -1 && timeSince >= 0.5f)
        {
            alpha -= speed * Time.deltaTime;

            if (alpha <= 0)
            {
                alpha = 0;

                if (timeSince > pause)
                    dir = 1;
            }
        }

        else
        {
            alpha += speed * Time.deltaTime;

            if (alpha >= 1)
            {
                alpha = 1;
                if (timeSince >= 7)
                {
                    SceneManager.LoadScene("game");
                    return;
                }
            }
        }

        GetComponent<SpriteRenderer>().color = new Color(c.r, c.g, c.a, alpha);
	}
}
