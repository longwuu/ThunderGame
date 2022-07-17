using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Retart : MonoBehaviour
{
    public void RestartGame0()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);


    }
    public void RestartGame3()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
        
        
    }
    public void RestartGame2()
    {

        SceneManager.LoadScene(2);
        Time.timeScale = 1;

    }
    public void RestartGame1()
    {

        SceneManager.LoadScene(3);
        Time.timeScale = 1;

    }
    public void Pause()
    {
        Time.timeScale = 0;
    }
    public void Contine()
    {
        Time.timeScale = 1 ;
    }
    public void quit()
    {
        Application.Quit();
    }
}
