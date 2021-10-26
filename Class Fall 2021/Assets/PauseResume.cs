using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseResume : MonoBehaviour
{
    GameObject[] pauseMode;
    GameObject[] resumeMode;
    // Start is called before the first frame update
    void Start()
    {
        pauseMode = GameObject.FindGameObjectsWithTag("ShowWhenPaused");
        resumeMode = GameObject.FindGameObjectsWithTag("ShowWhenResumed");

        foreach (GameObject g in pauseMode)
            g.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Pause()
    {
        Time.timeScale = 0.0f;
        foreach (GameObject g in pauseMode)
            g.SetActive(true);

        foreach (GameObject g in resumeMode)
            g.SetActive(false);
    }

    public void Resume()
    {
        Time.timeScale = 1.0f;
        foreach (GameObject g in pauseMode)
            g.SetActive(false);

        foreach (GameObject g in resumeMode)
            g.SetActive(true);

    }

    public void mainMenu()
    {
        PersistentData.Instance.SetIndex(SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene("menu");
    }

    public void HighScores()
    {
        SceneManager.LoadScene("highScores");
    }
}
