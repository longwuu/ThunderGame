using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Main3Control : MainControl
{
    public GameObject ui;
    public GameObject[] creators;
    public GameObject[] actors;
    public GameObject[] boss_creators;
    public GameObject prop_creator;

    public Image bossHp1;
    public Image bossHp2;

        
    public GameObject boss;
   

    public Text life;
    public GameObject R_start;
    public GameObject Win;
    public GameObject Lose;
    
    bool start = false;

    int boss_meet;
    bool Boss_meet = false;
    public GameObject Boss_cilp;
    controller con;
    bool win = false;
    
    // Start is called before the first frame update
    protected override void Start()
    {
        
        base.Start();
        boss_meet = Random.Range(0, 100);
        if (boss_meet <= 3)
            Boss_meet = true;
        con = this.GetComponent<controller>();
        con.life += 2;
    }

    // Update is called once per frame
    protected override void Update()
    {
     
        base.Update();
        if_lose();
        RestartGame();
        Start_game();

        life.text = con.life.ToString();
        if (start)
            Control();
    }
   void Start_game()
    {
        if (Input.GetKeyDown(KeyCode.R)|| Input.GetKeyDown(KeyCode.Joystick1Button7))
        {
            start = true;
            R_start.SetActive(false);
        }
    }
    void if_lose()
    {
        if (con.life <= 0 && !con.player)
        {
            Lose.SetActive(true);
        }
    }
    void RestartGame()
    {
        if (Input.GetKeyDown(KeyCode.P)|| Input.GetKeyDown(KeyCode.Joystick1Button6))
        {

            SceneManager.LoadScene(1);
            Time.timeScale = 1;
        }
    }
    void Control()
    {

        create(0);
        create(1);

        if (score > 38)
            create(2);

        if (score > 80)
            create(3);
        
        if (score > 150)
        {
            for (int i = 0; i < 4; i++)
                Destroy(creators[i]);

            if (actors[0]) actors[0].SetActive(true);
            if (actors[1]) actors[1].SetActive(true);

        }
        if (!actors[0] && !actors[1])
            if(actors[2])
            actors[2].SetActive(true);

        if(!actors[2])
        {
            create(4);
            create(5);
        }    
        if(score > 450)
        {
            if (boss_creators[0]) boss_creators[0].SetActive(true);
            if (boss_creators[1]) boss_creators[1].SetActive(true);
        }
        if(score > 520)
        {
            Destroy(creators[4]);
            Destroy(creators[5]);
            if (actors[3]) actors[3].SetActive(true);
            if (actors[4]) actors[4].SetActive(true);
        }

        if ((!actors[3]&&!actors[4])|| (Boss_meet && start))
        {
            //销毁所有creators 
            for (int i = 0; i < creators.Length; i++)
                Destroy(creators[i]);
            //boss 血条ui
            bossHp1.gameObject.SetActive(true);
            bossHp2.gameObject.SetActive(true);
           
         
            //播放boss音频
            if (Boss_cilp)
                Boss_cilp.SetActive(true);
            StartCoroutine("Boss");
        }
        if (!boss)
        {
            Destroy(boss_creators[0]);
            Destroy(boss_creators[1]);
            win = true;
            Win.SetActive(true);

        }
        if (con.life <= 0 && !con.player&&!win)
        {
            Lose.SetActive(true);
        }
    }
    void create(int i)
    {
        if (creators[i]) creators[i].SetActive(true);

    }
    IEnumerator Boss()
    {
        yield return new WaitForSeconds(5);
        if (boss)
            boss.SetActive(true);
    }
}
