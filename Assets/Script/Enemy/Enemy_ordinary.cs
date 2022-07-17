using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_ordinary : Enemy
{
   
    protected override void Start()
    {
        base.Start();
        if (x_speed == 0f)
            x_speed = Random.Range(-5, 5);
    }
    private void Update()
    {
        Move();
        base.Death();
    }
   
    void Move()
    {
        transform.Translate(x_speed * Time.deltaTime, e_speed * Time.deltaTime, 0);
        //transform.position -= new Vector3(0, e_speed * Time.deltaTime, 0);

        if (transform.position.y < -12 || transform.position.x < -12 || transform.position.x > 12)
        {

            Destroy(this.gameObject);            //¹ý½çÏú»Ù
        }
    }
    protected override void Damage(int number)
    {
        base.Damage(number);
    }
}
