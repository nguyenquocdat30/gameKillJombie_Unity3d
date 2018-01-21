using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
    public float maxSpeed;
    public float jumpHeight;

    // biến xác định quay mặt nhân vật khi di chuyển
    private bool facingRight;

    //biến xác định nhân vật có ở trên mặt đất hay không để xét điều kiều có thể  " nhảy "
    private bool grounded;

    // khai báo biến để bắn đạn
    // vị trí viên đạn sẽ dc bắn
    public Transform gunTip;
    // đối tượng 
    public GameObject bullet;
    private float fireRate = 0.75f;
    private float fireNext = 0;

    private Rigidbody2D myBody;
    private Animator myAnimator;
	// Use this for initialization
	void Start () {
        myBody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        // mặc định facingRight = true
        facingRight = true;

    }
	
	// Update is called once per frame

    void Update()
    {

    }
	void FixedUpdate () {
        float move = Input.GetAxis("Horizontal");
        // set giá trị với tên biến speed trong animator Unity với giá trị của move
        myAnimator.SetFloat("speed", Mathf.Abs(move));
        // set vị trí của nhân vật khi move thay đỗi 
        myBody.velocity = new Vector2(move * maxSpeed, myBody.velocity.y);
        if(move > 0 && !facingRight)
        {
            flip();
        } else if(move<0 && facingRight)
        {
            flip();
        }
        if (Input.GetKey(KeyCode.W)|| Input.GetKey(KeyCode.UpArrow))
        {
            if (grounded)
            {
                grounded = false;
                myBody.velocity = new Vector2(myBody.velocity.x, jumpHeight);
            }
        }

        // Chức năng bắn từ bàn phím
        if (Input.GetKey(KeyCode.Space))
        {
            fireBullet();
        }
	}
    // xử lí quay mặt nhân vật cho phù hợp
    void flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
    // xử lí va chạm giữa nhân vật và mặt đất
    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Ground")
        {
            grounded = true;
        }
    }
    // chức năng bắn
    void fireBullet()
    {
        if(Time.time > fireNext)
        {
            // 0.5s được bắn 1 phát
            fireNext = Time.time + fireRate;
            if (facingRight)
            {
                Instantiate(bullet,gunTip.position,Quaternion.Euler(new Vector3(0,0,0)));
            }
            else if(!facingRight)
            {
                Instantiate(bullet, gunTip.position, Quaternion.Euler(new Vector3(0, 0, 180)));
            }
        }
    }
}
