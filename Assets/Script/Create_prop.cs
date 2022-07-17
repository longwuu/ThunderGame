using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Create_prop : MonoBehaviour
{
    public Transform trans;
    public GameObject prop;
    public Transform creat_position;
    
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("CreateProp", 5, 4);

    }

    // Update is called once per frame
    void Update()
    {
        
        
           
        
    }
    void CreateProp()
    {
        Instantiate(prop, creat_position.position, creat_position.rotation, trans);
    }
}
