using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class Control : MonoBehaviour
{
    public void PlayPressed()
    {
        SceneManager.LoadScene("v0.2");
    }

    public void ExitPressed()
    {
        Application.Quit();
    }
    public void MenuPressed()
    {
        SceneManager.LoadScene("Menu");
    }

    public void ShopPressed()
    {
        SceneManager.LoadScene("Shop");
    }
    public void RestartButton1()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().name != "Menu")
        {
            if (SceneManager.GetActiveScene().name != "Shop")
            {
                if (Input.GetKey("space") || Input.GetKey("r"))
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                }
            }
            
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                SceneManager.LoadScene("Menu");
            }
        }
    }
}