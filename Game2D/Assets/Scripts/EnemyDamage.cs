using UnityEngine;
using System.Collections;

public class EnemyDamage : MonoBehaviour {
    public float damage;
    private float dameRate = 0.5f;
    private float nextDamage;
    // biến để tạo 1 lực khi nhân vật chạm vào Enemy
    public float pushBackForce;
	// Use this for initialization
	void Start () {
        nextDamage = 0f;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player" && nextDamage < Time.time)
        {
            PlayerHealth thePlayerHealth = other.gameObject.GetComponent<PlayerHealth>();
            thePlayerHealth.AddDamage(damage);
            nextDamage = dameRate + Time.time;
            PushBackForce(other.transform);
        }
    }
    void PushBackForce(Transform pushedObject)
    {
        Vector2 pushDirection = new Vector2(0, (pushedObject.position.y - transform.position.y)).normalized;
        pushDirection *= pushBackForce;
        Rigidbody2D pushRB = pushedObject.gameObject.GetComponent<Rigidbody2D>();
        pushRB.velocity = Vector2.zero;
        pushRB.AddForce(pushDirection,ForceMode2D.Impulse);
    }
}
