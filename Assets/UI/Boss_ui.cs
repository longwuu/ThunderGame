using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss_ui : MonoBehaviour
{
    public BOSS boss;

    Image hp;
    // Start is called before the first frame update
    void Start()
    {
        hp = this.gameObject.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        hp.fillAmount = boss.health/3000f;
    }
}
