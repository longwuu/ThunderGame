using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{  
    public float b_speed;         
    new AudioSource audio;
    public int shanghai;
    public GameObject clip;     //击中音效
    public Transform booms;    //击中音效的父类位置
    // Start is called before the first frame update
    void Start()
    {
        audio=this.GetComponent<AudioSource>();
        audio.Play();
    }

    // Update is called once per frame
    void Update()
    {
        Move();

    }
    private void OnTriggerEnter2D(Collider2D collision)     //子弹触碰敌人触发器
    {
        
        if(collision.gameObject.CompareTag("enemy")||collision.gameObject.CompareTag("boss"))
        {
            collision.SendMessage("Damage", shanghai);

            Instantiate(clip, transform.position, transform.rotation, booms);       //击中音效反馈

            Destroy(this.gameObject);
        }
    }



    void Move()                                 //子弹移动方式
    {
        //transform.position += new Vector3(0, b_speed * Time.deltaTime, 0);
     
        transform.Translate( transform.up*b_speed*Time.deltaTime);
        if (transform.position.y > 6.21f)
        {
            Destroy(this.gameObject);
        }
    }
}
