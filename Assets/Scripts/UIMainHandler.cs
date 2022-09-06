using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIMainHandler : MonoBehaviour
{
    public static UIMainHandler Instance { get; private set; }

    public Text highScore;

    private void Awake()
    {
        Instance = this;
    }

    private void OnDestroy()
    {
        Instance = null;
    }

    // Start is called before the first frame update
    void Start()
    {
        UpdateHighScore();
    }

    public void NewHighScore(int score)
    {
        if (DataManager.Instance != null)
        {
            if (score > DataManager.Instance.HighScore)
            {
                DataManager.Instance.HighScore = score;
                DataManager.Instance.HighScoreName = DataManager.Instance.Name;
                DataManager.Instance.SaveScore();
                UpdateHighScore();
            }
        }
    }

    public void UpdateHighScore()
    {
        if (DataManager.Instance != null)
        {
            highScore.text = "High score : " + DataManager.Instance.HighScoreName + " : " + DataManager.Instance.HighScore;
        }
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
