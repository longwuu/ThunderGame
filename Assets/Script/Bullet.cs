using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{  
    public float b_speed;         
    new AudioSource audio;
    public int shanghai;
    public GameObject clip;     //������Ч
    public Transform booms;    //������Ч�ĸ���λ��
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
    private void OnTriggerEnter2D(Collider2D collision)     //�ӵ��������˴�����
    {
        
        if(collision.gameObject.CompareTag("enemy")||collision.gameObject.CompareTag("boss"))
        {
            collision.SendMessage("Damage", shanghai);

            Instantiate(clip, transform.position, transform.rotation, booms);       //������Ч����

            Destroy(this.gameObject);
        }
    }



    void Move()                                 //�ӵ��ƶ���ʽ
    {
        //transform.position += new Vector3(0, b_speed * Time.deltaTime, 0);
     
        transform.Translate( transform.up*b_speed*Time.deltaTime);
        if (transform.position.y > 6.21f)
        {
            Destroy(this.gameObject);
        }
    }
}
