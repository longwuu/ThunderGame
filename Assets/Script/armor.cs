using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class armor : MonoBehaviour
{
    
    new AudioSource audio;
    public int shanghai;
    void Start()
    {
        audio = this.GetComponent<AudioSource>();
        audio.Play();
    }

    // Update is called once per frame
    void Update()
    {
        

    }
    private void OnTriggerEnter2D(Collider2D collision)     //×Óµ¯´¥ÅöµÐÈË´¥·¢Æ÷
    {

        if (collision.gameObject.CompareTag("enemy"))
        {
            collision.SendMessage("Damage", shanghai);

        }
        if (collision.gameObject.CompareTag("enemy_bullet"))
        {
            Destroy(collision.gameObject);
        }
    }



}
