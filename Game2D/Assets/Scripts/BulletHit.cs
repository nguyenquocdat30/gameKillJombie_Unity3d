using UnityEngine;
using System.Collections;

public class BulletHit : MonoBehaviour {

    // sát thương mỗi viên đạn gây ra
    public float weaponDamage;
    private ProjectTileController myPTC;
    // hiệu ứng nổ
    public GameObject bulletExplosion;

    void Awake()
    {
        myPTC = GetComponentInParent<ProjectTileController>();
    }
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    // xử lí va chạm khi 2 vật bắt đầu va chạm
    void OnTriggerEnter2D(Collider2D other)
    {
        //kiểm tra nếu trúng thì dừng viên đạn lại
        if(other.gameObject.tag == "Shootable")
        {
            // gọi tới hàm dừng viên đạn
            myPTC.removeForce();
            Instantiate(bulletExplosion, transform.position, transform.rotation);
            Destroy(gameObject);

        }
        if (other.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            // đối tượng nhận sát thương
            try
            {
                EnemyHealth hurtEnemy = other.gameObject.GetComponent<EnemyHealth>();
                hurtEnemy.AddDamage(weaponDamage);
            }catch(System.NullReferenceException e)
            {
                Debug.Log(e);
            }

        }
    }
    // xử lí va chạm khi 2 vật lồng nhau khi xuyên qua
    void OnTriggerStay2D(Collider2D other)
    {
        //kiểm tra nếu trúng thì dừng viên đạn lại
        if (other.gameObject.tag == "Shootable")
        {
            // gọi tới hàm dừng viên đạn
            myPTC.removeForce();
            Instantiate(bulletExplosion, transform.position, transform.rotation);
            Destroy(gameObject);
        }
        if (other.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            // đối tượng nhận sát thương
            try
            {
                EnemyHealth hurtEnemy = other.gameObject.GetComponent<EnemyHealth>();
                hurtEnemy.AddDamage(weaponDamage);
            }
            catch (System.NullReferenceException e)
            {
                Debug.Log(e);
            }

        }
    }
}
