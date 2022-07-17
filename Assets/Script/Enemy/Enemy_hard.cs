using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_hard : Enemy
{
    public bool quick = true;
    int y_direction;
    int x_direction;
   
    // Start is called before the first frame update
    protected override void Start()
    {

        base.Start();
        InvokeRepeating("ChangeY", 2, 1);
        InvokeRepeating("ChangeX", 2, 3);
        y_direction = 1;
        x_direction = 1;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        base.Death();
    }

    void Move()
    {
        if (transform.position.y > 3.14)
        {
            this.transform.position -= new Vector3(0, e_speed * Time.deltaTime, 0);
        }
        if (transform.position.y <= 3.14 && transform.position.x < 7 && transform.position.x > -7)
        {
            transform.Translate(x_speed * x_direction * Time.deltaTime, y_direction * Time.deltaTime, 0, Space.World);
        }
        if (transform.position.x >= 7f)
        {
            transform.Translate(x_speed * -1 * Time.deltaTime, y_direction * Time.deltaTime, 0, Space.World);
        }
        if (transform.position.x <= -7f)
        {
            transform.Translate(x_speed * 1 * Time.deltaTime, y_direction * Time.deltaTime, 0, Space.World);
        }
        if (transform.position.y < 2.41)
        {
            y_direction = 1;
        }
    }
    void ChangeY()
    {
        y_direction = -y_direction;


    }            //周期新改变上下移动方向
    void ChangeX()
    {
        x_direction = -x_direction;
        if(quick)
        x_speed = Random.Range(4, 6);
        
    }


    protected override void Damage(int number)
    {
        base.Damage(number);
    }
}
