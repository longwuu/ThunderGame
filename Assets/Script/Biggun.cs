using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Biggun : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject chongjibo;
    public float fireTime;
    public int gun_level;
    public PlayerControl player;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Fire", 0, fireTime);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void Fire()
    {
        if  (player.level >= gun_level&&Input.GetKey(KeyCode.J)&&!player.isGhost&&transform.parent.transform.gameObject.activeSelf)
        {
            Instantiate(chongjibo, transform.position, transform.rotation);
        }
    }
}
