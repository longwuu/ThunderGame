using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class controller : MonoBehaviour
{
  
    public float slow_timer=1;
    public GameObject player_model;

    public bool ableGhost = false;

    public int life = 3;
    public GameObject player;
    Rigidbody2D rig;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        //rig = player.GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
       
        if (player)
        {
            Armor();
            SwitchMode();
        }
        


        if(!player&&life >= 1)
        {
            Debug.Log("玩家已经死了");
            
            Instantiate(player_model,this.transform);
            player = GameObject.FindGameObjectWithTag("Player");
            rig = player.GetComponent<Rigidbody2D>();
            player.SendMessage("SaveLevel", 3);
            if (ableGhost)
                player.SendMessage("Ability", ableGhost);
            life--;
            Debug.Log("玩家活了");
        }
        else if(life<1)
        {
            //Time.timeScale = 0;
        }



    }

  

  

    void SlowTime()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            Time.timeScale = 0.5f;
            StartCoroutine("Slow");
        }
    }
    IEnumerator Slow()
    {
        for (float timer = slow_timer; timer > 0; timer -= Time.deltaTime)
            yield return 0;
        Time.timeScale = 1;
    }


    void Armor()
    {
        if (Input.GetKeyDown(KeyCode.Space)||Input.GetKeyDown(KeyCode.Joystick1Button1))
        {
            player.SendMessage("Armor");
        }
    }
    void SwitchMode()
    {
        if (Input.GetKeyDown(KeyCode.K)|| Input.GetKeyDown(KeyCode.Joystick1Button2))
            player.SendMessage("SwitchMode");
    }
}
