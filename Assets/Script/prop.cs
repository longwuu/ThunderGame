using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class prop : MonoBehaviour
{
    public float p_speed;
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
        transform.position -= new Vector3(0, p_speed * Time.deltaTime, 0);

        if (transform.position.y < -12 || transform.position.x < -12 || transform.position.x > 12)
        {

            Destroy(this.gameObject);            //¹ý½çÏú»Ù
        }
    }
}
