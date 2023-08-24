using DG.Tweening;
using Difficulty;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class UIHandler : MonoBehaviour
{
    [SerializeField] private GameObject gameOverCanvas;
    [SerializeField] private GameObject startPanel;
    [SerializeField] private GameObject tapTapObject;
    [SerializeField] private GameObject settingsPanel;
    [SerializeField] private GameObject settingsButton;
    [SerializeField] private TMP_Text currentScoreNumber;
    [SerializeField] private TMP_Text bestScoreNumber;
    [SerializeField] private DifficultyBase[] difficultyList;
    [SerializeField] private TMP_Dropdown difficultyDropdown;
    public UnityEvent onDifficultyChanged;

    [HideInInspector] public DifficultyBase currentDifficulty; 

    private int _score;
    private bool _isGameActive;
    
    public void Restart()
    {
        DOTween.KillAll();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void Awake()
    {
        tapTapObject.transform.DOScale(1.3f, 0.5f).SetLoops(1000, LoopType.Yoyo).SetEase(Ease.InOutSine).SetUpdate(true);
        difficultyDropdown.value = PlayerPrefs.GetInt("Difficulty", 0);
        currentDifficulty = difficultyList[difficultyDropdown.value];
        onDifficultyChanged.Invoke();
        Time.timeScale = 0f;
        currentScoreNumber.text = _score.ToString();
        bestScoreNumber.text = PlayerPrefs.GetInt("BestScore", 0).ToString();
        UpdateHighScore();
    }

    public void StartGame()
    {
        startPanel.SetActive(false);
        settingsPanel.SetActive(false);
        Time.timeScale = 1f;
        _isGameActive = true;
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

    public void SettingsButton()
    {
        settingsPanel.SetActive(!settingsPanel.activeInHierarchy);
        if (_isGameActive)
            Time.timeScale = Time.timeScale == 0 ? 1 : 0;
    }

    public void ChangeDifficulty()
    {
        currentDifficulty = difficultyList[difficultyDropdown.value];
        PlayerPrefs.SetInt("Difficulty", difficultyDropdown.value);
        onDifficultyChanged.Invoke();
    }

    public void DeactivateSettingsButton()
    {
        settingsButton.SetActive(false);
    }
}
