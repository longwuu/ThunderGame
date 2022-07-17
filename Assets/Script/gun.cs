using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gun : MonoBehaviour
{
    public GameObject bullet;
    public float fireTime;
    public int gun_level;
    public PlayerControl player;
    // Start is called before the first frame update
    void Start()
    {
        
        InvokeRepeating("Fire", 0, fireTime);
       
    }

    // Update is called once per frame
    void Update()
    {
        //if (player.level < gun_level)
        //    this.gameObject.SetActive(false);
    }
    void Fire()
  
    {
        Debug.Log(Input.GetKey(KeyCode.Joystick1Button10));
        if ((Input.GetKey(KeyCode.J)||Input.GetKey(KeyCode.Joystick1Button5))&& player.level >= gun_level&&transform.parent.gameObject.activeSelf&&!player.isGhost)
        {
            
            Instantiate(bullet,transform.position,transform.rotation);
        }
    }

}
