using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonFunctions : MonoBehaviour
{
    [SerializeField] InputField input;
    [SerializeField] Button gameButton;
    [SerializeField] int index;

    // Start is called before the first frame update
    void Start()
    {
        index = PersistentData.Instance.GetIndex();
        string pName = PersistentData.Instance.GetName();
        if (pName != "")
            input.placeholder.GetComponent<Text>().text = pName;
        if (index > 0)
            gameButton.GetComponentInChildren<Text>().text = "Resume game";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public  void GoToInstructions()
    {
        SceneManager.LoadScene("instructions");
    }

    public void PlayGame()
    {
        if (index > 0)
        {
            SceneManager.LoadScene(index);
            Time.timeScale = 1;
        }
        else
        {
            string playerName = input.text;
            PersistentData.Instance.SetName(playerName);
            SceneManager.LoadScene("level1");
        }
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("menu");
    }
}
