using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Scorekeeper : MonoBehaviour
{
    [SerializeField] int score;
    const int DEFAULT_POINTS = 1;
    //const int SCORE_THRESHOLD = 5;
    const int NUM_POINTS_PER_LEVEL = 5;
    int score_threshold;
    [SerializeField] Text scoreTxt;
    [SerializeField] Text sceneTxt;
    [SerializeField] Text nameTxt;
    [SerializeField] int level;
    [SerializeField] string playerName;

    // Start is called before the first frame update
    void Start()
    {
        level = SceneManager.GetActiveScene().buildIndex-1;
        playerName = PersistentData.Instance.GetName();
        score = PersistentData.Instance.GetScore();

        score_threshold = level * NUM_POINTS_PER_LEVEL;
        PersistentData.Instance.SetIndex(level + 1);

        DisplayName();
        DisplayLevel();
        DisplayScore();



    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddPoints(int points)
    {
        score += points;
        Debug.Log("score " + score);
        DisplayScore();
        PersistentData.Instance.SetScore(score);

        if (score > score_threshold)
            AdvanceLevel();

    }


    public void AddPoints()
    {
        AddPoints(DEFAULT_POINTS);
    }

    public void DisplayScore()
    {
        scoreTxt.text = "Score: " + score;
    }

    public void DisplayLevel()
    {
        sceneTxt.text = "Level: " + level;
    }

    public void AdvanceLevel()
    {
        SceneManager.LoadScene(level + 2);
    }

    public void DisplayName()
    {
        nameTxt.text = "Hello, " + playerName;
    }
}
        
