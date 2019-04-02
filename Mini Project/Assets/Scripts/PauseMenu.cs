using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour
{
    bool ispaused = false;
    public GameObject pausemenu;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Pause()
    {
        pausemenu.gameObject.SetActive(true);
        ispaused = true;
        Time.timeScale = 0.0f;

    }
    public void Resume()     
    {
        pausemenu.gameObject.SetActive(false);
        ispaused = false;
        Time.timeScale = 1.0f;

    }
    public void Restart()
    {
        SceneManager.LoadScene("Adventures of Burger");
        Time.timeScale = 1.0f;
    }
    public void quit()
    {
        Application.Quit();
    }
    public void menu()
    {
        SceneManager.LoadScene("MainMeni");
    }
}

