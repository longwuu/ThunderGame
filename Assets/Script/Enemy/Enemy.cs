using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{  
    public int health;      //����Ѫ��
    public float e_speed;    //�����ٶ�
    public float x_speed=0;
   
    
    public int fenshu=1;
    public GameObject clip;  //��ը��Ч
    public GameObject boom;     //��ը��Ч

    public Transform booms_position;  //��ը��Ч�ĸ���
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
            Instantiate(prop, transform.position, transform.rotation, booms_position); //��ը��Ч
    }

    protected virtual void Death()
    {
        if (health <= 0)
        {
            Instantiate(boom, transform.position, transform.rotation, booms_position);  //������ը

            Instantiate(clip, transform.position, transform.rotation, booms_position); //��ը��Ч

            drop_prop(); //����������Ʒ

            Main.SendMessage("GetScore", fenshu);
            Destroy(this.gameObject);                        //Ѫ��Ϊ0����
        }
    }
    protected virtual void Damage(int number)
    {
        health -= number; ;
    }
  

}
