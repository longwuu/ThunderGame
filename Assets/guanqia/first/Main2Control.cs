using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Main2Control : MainControl
{
    public GameObject ui;
    public GameObject[] creators;
    public GameObject prop_creator;
    public GameObject[] teach;
    int teach_index = 0;

    public GameObject boss;

    public Text life;
    public GameObject R_start;
    public GameObject Win;
    public GameObject Lose;

    bool start = false;

    int boss_meet;
    bool Boss_meet = false;
    public Image Boss_hp;
    float boss_health;
    public GameObject Boss_cilp;
    controller con;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();

        boss_health = boss.GetComponent<Enemy_hard>().health;
       
        boss_meet = Random.Range(0, 100);
        if (boss_meet <= 3)
            Boss_meet = true;
        con = this.GetComponent<controller>();
    }

    // Update is called once per frame
   protected override void Update()
    {
        base.Update();
        life.text = con.life.ToString();
        Teach_ui();
        RestartGame();
        if_lose();
        if (start)
            Control();
    }
    void RestartGame()
    {
        if (Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Joystick1Button6))
        {

            SceneManager.LoadScene(3);
            Time.timeScale = 1;
        }
    }
    void if_lose()
    {
        if (con.life <= 0 && !con.player)
        {
            Lose.SetActive(true);
        }
    }
    void Teach_ui()
    {
        if (Input.GetKeyDown(KeyCode.C) && !start)
        {
            if (!teach[teach_index].activeSelf)
                teach[teach_index].SetActive(true);
            else
            {
                teach[teach_index].SetActive(false);
                if (teach_index < teach.Length - 1)
                {
                    teach_index++;
                    teach[teach_index].SetActive(true);
                }
                else teach_index = 0;
            }
        }
        if (Input.GetKeyDown(KeyCode.R) || Input.GetKeyDown(KeyCode.Joystick1Button7))
        {
            R_start.SetActive(false);
            start = true;
            if (teach[teach_index].activeSelf)
                teach[teach_index].SetActive(false);
            
        }
    }
    void Control()
    {
        if (score >= 0) if (creators[0]) creators[0].SetActive(true);
        if (score >= 10) if (creators[1]) creators[1].SetActive(true);
        if (score >= 90) if (creators[2]) creators[2].SetActive(true);
        if (score >= 200)
        {
            if (creators[3]) creators[3].SetActive(true);
            if (creators[4]) creators[4].SetActive(true);
        }
        if (score > 260) if (creators[5]) creators[5].SetActive(true);

        if (score > 600 || (Boss_meet && start))
        {
            for (int i = 0; i < creators.Length; i++)
                Destroy(creators[i]);
            Boss_hp.gameObject.SetActive(true);
            
            if (boss)
            {
                Boss_hp.fillAmount = boss.GetComponent<Enemy_hard>().health / boss_health;
            }
                
            if(Boss_cilp)
            Boss_cilp.SetActive(true);
            StartCoroutine("Boss");
        }
        if (!boss)
        {

            Win.SetActive(true);

        }
      
    }
    IEnumerator Boss()
    {
        yield return new WaitForSeconds(5);
        if (boss)
            boss.SetActive(true);
    }
}
