using UnityEngine;
using System.Collections;

public class EnemyMovementController : MonoBehaviour {
    // tốc độ enemy
    public float enemySpeed;
    private Rigidbody2D enemyRB;
    private Animator enemAnim;
    // Khai báo các biến để Enemy thay đỗi scale
    public GameObject enemyGraphics;
    private bool facingRight = true;
    private float facingTime = 3f;
    private float nextFlip = 0f;
    private bool canFlip = true;

    void Awake()
    {
        enemyRB = GetComponent<Rigidbody2D>();
        enemAnim = GetComponentInChildren<Animator>();
    }
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextFlip)
        {
            nextFlip = Time.time + facingTime;
            Flip();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            if(facingRight && other.transform.position.x < transform.position.x)
            {
                Flip();
            }
            else if(!facingRight && other.transform.position.x > transform.position.x)
            {
                Flip();
            }
            canFlip = false;
        }
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            if(!facingRight)
            {
                enemyRB.AddForce(new Vector2(-1, 0) * enemySpeed);
            }
            else
            {
                enemyRB.AddForce(new Vector2(1, 0) * enemySpeed);
            }
            enemAnim.SetBool("Run", true);
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag =="Player")
        {
            canFlip = true;
            enemyRB.velocity = new Vector2(0, 0);
            enemAnim.SetBool("Run", false);
        }
    }

    void Flip()
    {
        if(!canFlip)
        {
            return;
        }       
        facingRight = !facingRight;
        Vector3 theScale = enemyGraphics.transform.localScale;
        theScale.x *= -1;
        enemyGraphics.transform.localScale = theScale;
        
    }
    public void DestroyController()
    {
        Destroy(gameObject);
    }
}
