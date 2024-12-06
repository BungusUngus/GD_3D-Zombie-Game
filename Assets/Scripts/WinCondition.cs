using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinCondition : MonoBehaviour
{
    public GameObject winScreen;

    void OnTriggerEnter(Collider col)
    {
        Time.timeScale = 0;

        winScreen.SetActive(true);
    }

    public void StartAnew()
    {
        SceneManager.LoadScene("MainMenu");

        Time.timeScale = 1;
    }
}
