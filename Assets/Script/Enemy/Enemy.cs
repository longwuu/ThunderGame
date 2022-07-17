using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{  
    public int health;      //敌人血量
    public float e_speed;    //敌人速度
    public float x_speed=0;
   
    
    public int fenshu=1;
    public GameObject clip;  //爆炸音效
    public GameObject boom;     //爆炸特效

    public Transform booms_position;  //爆炸特效的父类
    public GameObject prop;


    protected GameObject Main;

  
    
    // Start is called before the first frame update
    protected virtual void Start()
    {
        Main = GameObject.FindGameObjectWithTag("Main");
    
    }

    // Update is called once per frame
    protected virtual void drop_prop()
    {
        int i = Random.Range(0, 15);
        if (i < 1)
            Instantiate(prop, transform.position, transform.rotation, booms_position); //爆炸音效
    }

    protected virtual void Death()
    {
        if (health <= 0)
        {
            Instantiate(boom, transform.position, transform.rotation, booms_position);  //发生爆炸

            Instantiate(clip, transform.position, transform.rotation, booms_position); //爆炸音效

            drop_prop(); //死亡掉落物品

            Main.SendMessage("GetScore", fenshu);
            Destroy(this.gameObject);                        //血量为0销毁
        }
    }
    protected virtual void Damage(int number)
    {
        health -= number; ;
    }
  

}
