using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine.UI;

[DefaultExecutionOrder(1000)]
public class UIMenuHandler : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI highScore;
    public TMP_InputField nameInput;

    // Start is called before the first frame update
    void Start()
    {
        highScore.text = "High score : " + DataManager.Instance.HighScoreName + " : " + DataManager.Instance.HighScore;
        nameInput.text = DataManager.Instance.Name;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        if (nameText.text != "")
        {
            DataManager.Instance.Name = nameText.text;
            DataManager.Instance.SaveScore();
            SceneManager.LoadScene(1);
        }
    }
    
    public void Exit()
    {
        DataManager.Instance.SaveScore();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
