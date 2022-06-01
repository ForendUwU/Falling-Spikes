using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreScript : MonoBehaviour
{
    int score;

    public Text scoreText;
    public Text highScore;

    private void Start()
    {
        highScore.text = "Your High Score: " + PlayerPrefs.GetInt("HighScore", 0).ToString();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Spike")
        {
            score++;
            UpdateScore();
        }
    }
    public void UpdateScore()
    {
        scoreText.text = "Score: " + score.ToString();
        if (score > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", score);
            highScore.text = "Your High Score: " + score.ToString();
        }
    }

    public void Reset() {
        PlayerPrefs.DeleteAll();
        
        highScore.text = "0";
    }
}