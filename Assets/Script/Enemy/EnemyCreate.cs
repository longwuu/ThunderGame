using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCreate : MonoBehaviour
{
    public GameObject[] enemy;
    public Transform trans;
    public float create_timer;
    public float left=-10;
    public float right=10;


    float create_position;

    int index;
    // Start is called before the first frame update
    void Start()
    {
        
        InvokeRepeating("Create", 0,create_timer);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Create()
    {
        create_position = Random.Range(left,right);
        transform.position = new Vector3(create_position,transform.position.y,0);

        index = Random.Range(0, enemy.Length);
        GameObject creator = enemy[index];
        Instantiate(creator,transform.position,transform.rotation,trans);
        //create_timer = Random.Range(0f, 0.5f);
    }
}
