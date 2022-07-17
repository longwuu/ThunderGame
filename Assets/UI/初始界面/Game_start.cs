using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game_start : MonoBehaviour
{
    public GameObject select;
    public void LoadGame()
    {
        select.SetActive(true);
        
    }
    public void quit()
    {
        Application.Quit();
    }
}
