using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIHandler : MonoBehaviour
{
    [SerializeField] private GameObject gameOverCanvas;
    [SerializeField] private TMP_Text currentScoreNumber;
    [SerializeField] private TMP_Text bestScoreNumber;

    private int _score;
    
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void Awake()
    {
        Time.timeScale = 1f;
        currentScoreNumber.text = _score.ToString();
        bestScoreNumber.text = PlayerPrefs.GetInt("BestScore", 0).ToString();
        UpdateHighScore();
    }

    private void UpdateHighScore()
    {
        if (_score > PlayerPrefs.GetInt("BestScore", 0))
        {
            PlayerPrefs.SetInt("BestScore", _score);
            bestScoreNumber.text = _score.ToString();
        }
    }

    public void UpdateScore()
    {
        _score++;
        currentScoreNumber.text = _score.ToString();
        UpdateHighScore();
    }

    public void GameOver()
    {
        Time.timeScale = 0f;
        gameOverCanvas.SetActive(true);
    }
}
