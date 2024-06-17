using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    private int _paddleLeftScore;
    private int _paddleRihgtScore;

    [SerializeField]
    private int _scoreToWin; 

    [SerializeField]
    private TMP_Text _scoreTextUI;

    [SerializeField]
    private GameObject _gameOverScreen;

    [SerializeField]
    private TMP_Text _gameOverText;

    public void AddPoint(bool isLeftBorder)
    {
        _paddleLeftScore += isLeftBorder ? 0 : 1;
        _paddleRihgtScore += isLeftBorder ? 1 : 0;
        CheckVictory();
        UpdateScoreUI();
    }

    private void CheckVictory()
    {
        if (_paddleLeftScore >= _scoreToWin)
        {
            _gameOverScreen.SetActive(true);
            _gameOverText.text = "Player 2 wins";
            Time.timeScale = 0;
        }

        if (_paddleRihgtScore>= _scoreToWin)
        {
            _gameOverScreen.SetActive(true);
            _gameOverText.text = "Player 1 wins";
            Time.timeScale = 0;
        }
    }


    private void UpdateScoreUI()
    {
        _scoreTextUI.text = _paddleLeftScore.ToString() + " / " + _paddleRihgtScore.ToString();
    }

    private void OnDestroy()
    {
        Time.timeScale = 1;
    }

    public void ReloadGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
