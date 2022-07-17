using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainControl : MonoBehaviour
{
   
 

    public Text Score;
    //GameObject[] boss;

    //bool create=false;
    protected int score=0;
    // Start is called before the first frame update
    protected virtual void Start()
    {
        Application.targetFrameRate = 120;
        //boss = GameObject.FindGameObjectsWithTag("boss");
        //Debug.Log(boss[0]);
        //boss[0].SetActive(false);


    }

    // Update is called once per frame
    protected virtual void Update()
    {
        Score.text = score.ToString();




        //if (!boss[0])
        //{
        //    Debug.Log(boss[0]);
        //    //creator[7].SetActive(true);
        //    Time.timeScale = 0;
        //}
    }


    void GetScore(int num)
    {
        score += num;
       
    }
    
}
