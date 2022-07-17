using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BOSS_gun : MonoBehaviour
{
    public GameObject bullet;
    public float fireTime;
    public int gun_level;
    public BOSS boss;
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
    if (gun_level == boss.fire_level)
    {
        Instantiate(bullet, transform.position, transform.rotation);
        }
    }
}
