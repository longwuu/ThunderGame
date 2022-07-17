using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Main1Control : MainControl
{
    public GameObject ui;
    public GameObject[] creators;
    public GameObject[] acotors;
    public GameObject prop_creator;

    public GameObject boss;
    public Text Timer;

    public Text life;
    public GameObject R_start;
    public GameObject Win;
    public GameObject Lose;
    float timer = 100;
    bool start = false;

    int boss_meet;
    bool Boss_meet=false;
    public GameObject Boss_cilp;
    float boss_health;
    public Image Boss_hp;
    controller con;
    protected override void Start()
    {
        base.Start();

        boss_health = boss.GetComponent<Enemy_hard>().health;

        boss_meet = Random.Range(0, 100);
        if (boss_meet <= 3)
            Boss_meet = true;
       con = this.GetComponent<controller>();
    }
    protected override void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Joystick1Button6))
        {
            
            SceneManager.LoadScene(2);
            Time.timeScale = 1;
        }
        Timer.text = timer.ToString();
        life.text = con.life.ToString();
        Control();
    }
    
    void Control()
    {
        if (Input.GetKeyDown(KeyCode.R) || Input.GetKeyDown(KeyCode.Joystick1Button7)) 
        { 
            start = true;
            R_start.SetActive(false);
        }
        base.Update();
        if (start&&timer>0.1f)
            timer -= Time.deltaTime;

        if (timer < 98) if (creators[0]) creators[0].SetActive(true);

        if (timer < 90) if (creators[1]) creators[1].SetActive(true);

        if (timer < 85)
        {
            if (creators[3])
                creators[3].SetActive(true);
            if (creators[4])
                creators[4].SetActive(true);
        }
        if (timer < 74) if(creators[2])creators[2].SetActive(true);

        if (timer < 58)
        {

            Destroy(creators[0]);

            Destroy(creators[3]);
            Destroy(creators[4]);

        }

        if (timer < 50)
        {
            if (creators[5])
                creators[5].SetActive(true);
            if (creators[6])
                creators[6].SetActive(true);
        }

        if (timer <= 5)
        {
            Destroy(creators[5]);
            Destroy(creators[6]);
            Destroy(creators[1]);
            Destroy(creators[2]);
            if (Boss_cilp)
                Boss_cilp.SetActive(true);
           
        }

        if (timer <= 2||(Boss_meet&&start))
        {
            Boss_hp.gameObject.SetActive(true);
            if (boss)
            {
                Debug.Log(boss.GetComponent<Enemy_hard>().health / boss_health);
                Boss_hp.fillAmount = boss.GetComponent<Enemy_hard>().health / boss_health;
                boss.SetActive(true);
            }
        }
         
                

     

        if (!boss)
        {

            Win.SetActive(true);
          
        }
        if(con.life <=  0 && !con.player)
        {
            Lose.SetActive(true);
        }
    }
}
