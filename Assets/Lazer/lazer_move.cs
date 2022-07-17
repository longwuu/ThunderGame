using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lazer_move : MonoBehaviour
{
    public float max_length = 15;
    public float speed=1;
    public float angle = 1;
    public GameObject recive;
    // Start is called before the first frame update
    Vector3 length;
    bool start_move = false;
    public int forward_speed = 1;

    float timer_move = 0;
    void Start()
    {
        Invoke("StartMove",2.5f);
        
        
    }

    // Update is called once per frame
    void Update()
    {
        length = recive.transform.position - transform.position;
        if (start_move)
        {
            Move();
            Rotate();
        }

        if (timer_move <= 20)
            timer_move += Time.deltaTime;
        if (timer_move >= 18.5f)
            if (length.magnitude >= 1f)
            {
                recive.transform.position += transform.up * -forward_speed * Time.deltaTime;
                start_move = false;
            }
        if (timer_move > 18.8)
            Destroy(this.gameObject);
            
    }
    void Move()
    {  
        
        if(length.magnitude<=max_length)
        recive.transform.position += transform.up * forward_speed * Time.deltaTime;
        
        transform.Translate(speed * Time.deltaTime, 0, 0, Space.Self);
        if (transform.position.x > 12 || transform.position.y > 6)
            Destroy(this.gameObject);

        
    }
    void Rotate()
    {
        transform.Rotate(0, 0, angle * Time.deltaTime, Space.Self);
    }
    void StartMove()
    {
        start_move = true;
    }    
}
