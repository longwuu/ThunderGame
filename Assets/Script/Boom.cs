using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boom : MonoBehaviour
{
    public float timer;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("D", timer);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void D()
    {
        Destroy(this.gameObject);
    }
}
