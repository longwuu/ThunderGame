using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Player_UI : MonoBehaviour
{
     GameObject player;
    PlayerControl playernum;

    Image hp;
   

    float restime;
  
    //bool finished;  
    public Text armor_number;
    public Text hp_number;
    public Text level_number;

    public Image I_Hp;
    public Image Armor;
    public Image GhostTimer;
    // Start is called before the first frame update
    void Start()
    {
 
        
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if (player)
        {
            playernum = player.GetComponent<PlayerControl>();
            armor_number.text = playernum.armor_number.ToString();
            hp_number.text = playernum.health.ToString();
            level_number.text = playernum.level.ToString();
            I_Hp.fillAmount = playernum.health / 3.0f;
            Armor.fillAmount = playernum.armor_timer / playernum.cooltime;
            GhostTimer.fillAmount = playernum.Ghost_timer / 2.0f;
        }
    }
 
}
