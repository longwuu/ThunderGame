using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BOSS : MonoBehaviour
{
    public int health;
    public float y_speed;
    public float x_speed;
    public GameObject bullet;
    public Transform trans;
    public Transform player;
    public int mode;
    public int  fire_level;
    public GameObject clip;


    bool turn;
    int  turn_rate;
    int  y_direction;
    int  x_direction;
    int turn_angle;
   



    // Start is called before the first frame update
    void Start()
    {
        turn = false;
        fire_level = 1;
        y_direction = 1;
        x_direction = 1;
        turn_angle = 1;
       
        InvokeRepeating("ChangeTurn", 2, 2);
        InvokeRepeating("ChangeY", 2,2);
        InvokeRepeating("ChangeX", 2, 4);
        
        InvokeRepeating("Mode",0,4f);

    }

    // Update is called once per frame
    void Update()
    {

        
       
        if(turn)
            Turn();      
        else
            Move();
        Death();

    }
    void Move()
    {  if (transform.position.y>3.14)
        {
            this.transform.position -= new Vector3(0,y_speed*Time.deltaTime,0);
        }
       if(transform.position.y <= 3.14&& transform.position.x<7&& transform.position.x>-7)
            {
            transform.Translate(x_speed*x_direction*Time.deltaTime,  y_direction * Time.deltaTime, 0,Space.World);
        }
         if (transform.position.x>=7f)
        {
            transform.Translate(x_speed *-1* Time.deltaTime, y_direction * Time.deltaTime,0, Space.World);
        }
        if (transform.position.x <= -7f)
        {
            transform.Translate(x_speed *1 * Time.deltaTime, y_direction * Time.deltaTime, 0,Space.World);
        }
        if (transform.position.y < 2.5)
            y_direction = 1;
    }

   void  ChangeY()
    {
        y_direction = -y_direction;
        
   
    }            //周期新改变上下移动方向
    void ChangeX()
    {
        x_direction = -x_direction;
        x_speed = Random.Range(2,5);
    }         //周期性改变左右移动方向 并设置随即速度
    void ChangeTurn()
    {
        turn_rate = Random.Range(30,35);
        turn_angle = -turn_angle;
    }
    void Damage(int number)
    {
        health -= number;
    }
    void Death()
    {
        if(health<=0)
        {
            Instantiate(clip,trans);
            Destroy(this.gameObject);
        }
    }
  
    void Mode()
    {
        mode =Random.Range(1,4);
        if(mode==1)
        {
            fire_level = 1;
            
        }
        if(mode==2)
        {
            fire_level = 2;           
        }

        if(mode==3)
        {
            fire_level = 2;
            turn = true;
        }
        else
        {
            turn = false;
            transform.eulerAngles = new Vector3(0,0,180);
        }
    }
    void Turn()
    {   
        this.transform.Rotate(0,0,turn_rate*turn_angle*Time.deltaTime);
    }
}
