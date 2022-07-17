    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{    [Tooltip("Ѫ��,�ɸ�����ҵ�ǰѪ�� ���5")]
    public int health=5;
    [Tooltip("�ȼ�,���÷ɻ��ȼ�")]
    public int level;

    public float x_speed;
    public float y_speed;
    //[Tooltip("�������")]
    
    [Tooltip("Ҫ���ɵ���Ƶ����")]
    public GameObject clip;
    public Transform booms;
    public float slow_timer;
    public int armor_number;
    public float cooltime;
    public GameObject armor;
    public float armor_timer=5;
    public GameObject prop_clip;
    //��Ӱ
    [Tooltip("��Ӱ")]
    public GameObject ghost;
    
    public bool isGhost=true;
    public  float Ghost_timer=2;
    bool ableGhost = false;
    SpriteRenderer render;

    public bool    armor_state;

    Rigidbody2D rig;
    float   x_slow_speed=9;
    float   y_slow_speed=9;
    bool    dash=false;
     float   dashtimer=0.2f;
    
    bool born=false;

    GameObject [] modes;
    int cur_mode=0;
    //Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        
        //�Զ���ģʽ��ʼ������
        InitMode();

        //��ʼ��
     
        //���׳�ʼ��
        armor_state = true;      //�����Ƿ�������ȴ���ж�����ֵ
        Armor();

        //�����ʼ��
        rig = this.GetComponent<Rigidbody2D>();

        //������ʼ��
        //anim = this.GetComponent<Animator>();
        StartCoroutine("InitGhost");

        //��Ⱦ����ʼ��
        render = gameObject.GetComponent<SpriteRenderer>();
    }
    IEnumerator InitGhost()
    {

        yield return new WaitForSeconds(1.7f);
        born = true;
    }
    // Update is called once per frame
    void Update()
    {
        Move();
        if (born)
        {

            if (ableGhost)
            {
                Ghost();
                Accelerate();
            }
            //SlowTime();
            //Armor();
            Death();
        }
        //Debug.Log(armor_timer);
    }
 
    private void OnTriggerEnter2D(Collider2D collision) 
        
    {
        if (collision.CompareTag("wall"))
        {
            Instantiate(clip, transform.position, transform.rotation, booms);
           
            health = 0;
        }
        if (collision.CompareTag("enemy")&&!isGhost) //ײ���������һ���
        {   
            Instantiate(clip, transform.position, transform.rotation,booms);
            Destroy(collision.gameObject);
            health = 0;
        }
        if ( collision.CompareTag("boss")) //ײ���������һ���
        {
            Instantiate(clip, transform.position, transform.rotation, booms);

            health = 0;
        }
        if ( collision.CompareTag("enemy_bullet")&&!isGhost)
        {
            Instantiate(clip, transform.position, transform.rotation, booms);
            Destroy(collision.gameObject);
            health -= 1;
            
            if(level<1)
            {
                level = 1;
            }
            
               
        }
        if (collision.CompareTag("prop"))
        {
            
            level += 1;
            Destroy(collision.gameObject);
            health += 1;
            Instantiate(prop_clip,transform);
            if (level > 6)
                level = 6;
            if (health > 5)
                health = 5;
            
        }
    }
    void Move()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        if (x!=0||y!=0)
        {
            
            rig.transform.position += new Vector3(x * x_speed * Time.deltaTime, y * y_speed * Time.deltaTime, 0);
        }   
        //anim.SetFloat("x_speed", x);
    }
    void Ability(bool G)
    {
        ableGhost = G;
    }
    void Accelerate()
    {
        if ((Input.GetKey(KeyCode.L)||Input.GetKey(KeyCode.Joystick1Button0))&&Ghost_timer>0)
        {
            render.color = new Vector4(1, 1, 1, 0.2f);
            Ghost_timer -= Time.deltaTime;
            x_speed = 15f;
            y_speed = 15f;
            dash = true;
            isGhost = true;
        }
        else
        {
            render.color = new Vector4(1, 1, 1,1);
            x_speed = x_slow_speed;
            y_speed = y_slow_speed;
            dash = false;
            isGhost = false;
            if (Ghost_timer <= 2)
                Ghost_timer += Time.deltaTime;
        }
    }
    //��Ӱ����
    void Ghost()
    {
        if (dashtimer > -0.5)
            dashtimer -= Time.deltaTime;
        if (dash && dashtimer <= 0&&Ghost_timer>0)
        {
            
            dashtimer = 0.05f;
            Instantiate(ghost, this.transform.position, this.transform.rotation);
        }
    }
    //void SlowTime()
    //{
    //    if(Input.GetKeyDown(KeyCode.K))
    //    {
    //        Time.timeScale = 0.5f;
    //        StartCoroutine("Slow");
    //    }
    //}
    //IEnumerator Slow()
    //{
    //    for(float timer=slow_timer;timer>0; timer-=Time.deltaTime)
    //    yield return 0;
    //    Time.timeScale = 1;
    //}
    void Armor()
    {
        if(armor_number>=1&&armor_state)
        {
            armor_number -= 1;
            armor_state = false;
            StartCoroutine("Timer");
            Instantiate(armor,transform);
           
        }
    }
    IEnumerator Timer()
    {
        for (armor_timer = 0; armor_timer <= cooltime; armor_timer += Time.deltaTime)
        {
            
            yield return 0 /*new WaitForSeconds (cooltime)*/;
        }
            armor_state = true;
    }
    void Death()
    {
        if (health > 3)
            health = 3;
        if(health<=0)
        {
            Instantiate(clip, transform.position, transform.rotation, booms);
            Destroy(this.gameObject);
        }
    }
    


    //��start�й���ģʽ�ĳ�ʼ��
    void InitMode()
    {
        //��ʼ�����ģʽ����
        int n = 2;              //�������鳤��
        modes = new GameObject[n];
        for (int i = 0; i < n; i++)           //ѭ���洢ģʽ  ������������ΪmodeN  N����һ������
        {
            string s = "mode" + (i + 1).ToString();
            modes[i] = transform.Find(s).gameObject;  //��ȡ����mode����洢��modes��
        }

        //modes[1] = transform.Find("mode2").gameObject;
        modes[cur_mode].SetActive(true);
    }
     void SwitchMode()
    {
        
        modes[cur_mode].SetActive(false);

        cur_mode++;
        if (cur_mode >= modes.Length)
            cur_mode = 0;

        modes[cur_mode].SetActive(true);
        
       
    }
    void AbleMove()
    {
        Animator anim = this.GetComponent<Animator>();
        anim.applyRootMotion = true ;
        anim.enabled=false;
    }
    void Damage(int num)
    {
        if(!isGhost&&born)
        health -= num;
    }
   void SaveLevel(int i)
    {
        level = i;
    }
 
}
