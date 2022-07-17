using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    public float rollSpeed;
    Transform trans;
    // Start is called before the first frame update
    void Start()
    {
        rollSpeed = 8;
        trans = this.transform;
    }

    // Update is called once per frame
    void Update()
    {   
        this.transform.position -= new Vector3(0, rollSpeed * Time.deltaTime, 0);
        if(trans.position.y<=-22.88)
        {

            transform.position = new Vector3(0,24.23f,5f);
        }
    }
}
