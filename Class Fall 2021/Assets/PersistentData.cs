using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistentData : MonoBehaviour
{
    [SerializeField] int playerScore;
    [SerializeField] string playerName;
    [SerializeField] int currentLevelIndex;

    public static PersistentData Instance; 

    // Start is called before the first frame update
    void Start()
    {
        playerName = "";
        playerScore = 0;
        currentLevelIndex = 0;
    }

    private void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(this);
            Instance = this;
        }
        else
            Destroy(gameObject);
    }

    public void SetName(string n)
    {
        playerName = n;
    }

    public void SetScore(int s)
    {
        playerScore = s;
    }

    public string GetName()
    {
        return playerName;
    }

    public int GetScore()
    {
        return playerScore;
    }

    public void SetIndex(int i)
    {
        currentLevelIndex = i;
    }

    public int GetIndex()
    {
        return currentLevelIndex;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
