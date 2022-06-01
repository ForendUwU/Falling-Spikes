using UnityEngine;

public class PauseScript1 : MonoBehaviour
{
    public GameObject pausePanel;
    public GameObject gameOver;

    public static bool isPaused = false;

    private void Start()
    {
        Time.timeScale = 1f;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !gameOver.activeInHierarchy)
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
            
        }

    }

    private void Resume()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void Pause() 
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0;
        isPaused = true;
    }
}
