using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class HighScore : MonoBehaviour
{
    public Text[] scoreTexts; 

    private List<int> highScores;

    void Start()
    {
        InitializeScoreTexts();
        LoadHighScores();
        UpdateUI();
    }

    void InitializeScoreTexts()
    {
        if (scoreTexts == null || scoreTexts.Length == 0)
        {
            Debug.LogError("Score Texts array is not properly set in the Inspector.");
        }
    }

    void LoadHighScores()
    {
        highScores = new List<int>();

        for (int i = 0; i < 5; i++)
        {
            int score = PlayerPrefs.GetInt("HighScore" + i, 0);
            highScores.Add(score);
        }
    }

    void SaveHighScores()
    {
        for (int i = 0; i < 5; i++)
        {
            PlayerPrefs.SetInt("HighScore" + i, highScores[i]);
        }

        PlayerPrefs.Save();
    }

    void UpdateUI()
    {
        if (scoreTexts == null || scoreTexts.Length == 0)
        {
            Debug.LogError("Score Texts array is not properly set in the Inspector.");
            return;
        }

        for (int i = 0; i < scoreTexts.Length; i++)
        {
            if (scoreTexts[i] == null)
            {
                Debug.LogError($"Score Text {i + 1} is null.");
                continue;
            }

            if (i < highScores.Count && highScores[i] > 0) 
            {
                scoreTexts[i].text = "Score " + (i + 1) + ": " + highScores[i];
            }
            else
            {
                scoreTexts[i].text = ""; 
            }
        }
    }

    public void AddScore(int score)
    {
        highScores.Add(score);
        highScores.Sort((a, b) => b.CompareTo(a)); 
        highScores = highScores.GetRange(0, Mathf.Min(highScores.Count, 5)); 
        SaveHighScores();
        UpdateUI();
    }
}
