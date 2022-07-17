using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_gun : MonoBehaviour
{
    public GameObject bullet;
    public float fireTime;
    public int gun_level;
    public bool turnToPlayer=false;
   
    // Start is called before the first frame update
    void Start()
    {

        InvokeRepeating("Fire", 0, fireTime);

    }

    // Update is called once per frame
    void Update()
    {
      
    }
    void Fire()
    {

       
            Instantiate(bullet, transform.position, transform.rotation);
        
    }
    void LookAt2D()
    {
        GameObject target = GameObject.FindGameObjectWithTag("Player");
        Vector2 v = (target.transform.position - transform.position).normalized;
        transform.up = v;

    }
}
