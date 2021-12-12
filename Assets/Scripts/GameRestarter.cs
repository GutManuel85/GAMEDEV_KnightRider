using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameRestarter : MonoBehaviour
{

    public ScoreManager sm;
    public Text highscoreText;

    public void Update()
    {
        int score = sm.getScore();
        int highscore = PlayerPrefs.GetInt("highscore");
        if (score > highscore) PlayerPrefs.SetInt("highscore", score);
        highscoreText.text = PlayerPrefs.GetInt("highscore").ToString();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }

    public void goToMenu()
    {
        SceneManager.LoadScene("StartMenu");
    }


}