using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chongjibo : MonoBehaviour
{
    public float b_speed;
    new AudioSource audio;
    public int shanghai;
    // Start is called before the first frame update
    void Start()
    {
        audio = this.GetComponent<AudioSource>();
        audio.Play();
    }

    // Update is called once per frame
    void Update()
    {
        Move();

    }
    private void OnTriggerEnter2D(Collider2D collision)     //子弹触碰敌人触发器
    {
        
        if (collision.gameObject.CompareTag("enemy"))
        {
            collision.SendMessage("Damage", shanghai);
            
        }
        //if (collision.gameObject.CompareTag("enemy_bullet"))
        //{
        //    Destroy(collision.gameObject);
        //}
    }



    void Move()                                 //子弹移动方式
    {
        //transform.position += new Vector3(0, b_speed * Time.deltaTime, 0);
        transform.Translate(-transform.up * b_speed * Time.deltaTime);
        if (transform.position.y > 6.21f)
        {
            Destroy(this.gameObject);
        }
    }
}
