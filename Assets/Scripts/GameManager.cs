using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager gm;
    public bool playing;
    public bool paused;
    public GameObject Pause;
    public GameObject gameOver;

    // Start is called before the first frame update
    void Start()
    {
        gm = this;
        playing = true; 
    }
    private void ChangeScene()
    {
        SceneManager.LoadScene(0);
    }

    // Update is called once per frame
    void Update()
    {
        if (playing)
        {
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                paused = !paused;
            }
        }
        else
        {
            Invoke("ChangeScene", 5f);
        }
        if (paused)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }

        Pause.SetActive(paused);
        gameOver.SetActive(!playing);

    }
}
