using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float e_b_speed;        //���õ����ӵ��ٶ�
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        YMove();
    }
    void YMove()
    {
        transform.Translate(-transform.up * e_b_speed * Time.deltaTime);

        if (transform.position.y < -12 || transform.position.x < -12 || transform.position.x > 12|| transform.position.y > 10)
        {

            Destroy(this.gameObject);            //��������
        }
    }
}
