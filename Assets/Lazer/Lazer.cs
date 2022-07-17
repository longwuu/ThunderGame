using UnityEngine;

public class Lazer : MonoBehaviour
{
    public LineRenderer lazer;
    public GameObject recive;
    

    float timer = 0;
    Vector2 origion;
    Vector2 direction;
    bool raying = false;


    Vector2 end;


    public float max_length = 15;
    public float speed = 1;
    public float angle = 1;
    
    // Start is called before the first frame update
    Vector3 length;
    bool start_move = false;
    public int forward_speed = 1;

  


    // Start is called before the first frame update
    void Start()
    {
        
        lazer = this.GetComponent<LineRenderer>();
        lazer.enabled = true;
        direction = new Vector2(recive.transform.position.x - transform.position.x, recive.transform.position.y - transform.position.y);
        direction = direction.normalized;
        InvokeRepeating("Lazer_again", 0,22f);
    }

    void Lazer_again()
    {
        timer = 0;
        Invoke("StartMove", 2.5f);
        //AudioSource clip = this.GetComponent<AudioSource>();

    }
    // Update is called once per frame
    void Update()
    {
        //∑¢…‰¿ÿ…‰
        RayDraw();
        if (timer < 20f)
            timer += Time.deltaTime;
        if (timer > 2.6)
            raying = true;
        if (timer >= 18.2f)
            raying = false;
        if (raying)
            RayTest();
       


        //“∆∂Ø
        length = recive.transform.position - transform.position;
        if (start_move)
        {
            Move();
            Rotate();
        }
   
        if (timer >= 18.2f)
            if (length.magnitude >= 1f)
            {
                recive.transform.position += transform.up * -forward_speed * Time.deltaTime;
                start_move = false;
            }
        //if (timer_move > 18.8)
        //    Destroy(this.gameObject);

    }
    void RayDraw()
    {
        direction = new Vector2(recive.transform.position.x - transform.position.x, recive.transform.position.y - transform.position.y);
        origion = new Vector2(transform.position.x, transform.position.y);
        end = new Vector2(recive.transform.position.x, recive.transform.position.y);
        
        //Debug.Log(hit.collider.gameObject);
        
        lazer.SetPosition(0, origion);
        lazer.SetPosition(1, end);
       
    }
    void RayTest()
    {
        RaycastHit2D hit = Physics2D.Raycast(origion, direction, length.magnitude);
        //Debug.DrawLine(origion, hit.point, Color.red);
        if (hit&&hit.collider.CompareTag("Player"))
        {
            hit.collider.SendMessage("Damage", 5);
        }
    }
    void Move()
    {

        if (length.magnitude <= max_length)
            recive.transform.position += transform.up * forward_speed * Time.deltaTime;

        transform.Translate(speed * Time.deltaTime, 0, 0, Space.Self);
        if (transform.position.x > 12 || transform.position.y > 12  )
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
