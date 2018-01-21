using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour {
    public float maxHealth;
    private float currentHealth;

    // biến để tạo hiệu ứng khi Enemy die
    public GameObject enemyHealthEF;

    // khai báo biến tạo thanh máu UI cho Enemy
    public Slider enemyHealthSlider;

    public EnemyMovementController enemyController;

    // Use this for initialization
    void Start () {
        currentHealth = maxHealth;
        enemyHealthSlider.maxValue = maxHealth;
        enemyHealthSlider.value = maxHealth;
	}
	
    void Awake()
    {
        enemyController = GetComponentInParent<EnemyMovementController>();
    }
	// Update is called once per frame
	void Update () {
	
	}

    //chức năng nhận sát thương
    public void AddDamage(float damage)
    {
        enemyHealthSlider.gameObject.SetActive(true);
        currentHealth -= damage;
        enemyHealthSlider.value = currentHealth;
        if(currentHealth <=0)
        {
            // chết
            makeDead();
        }
    }
    void makeDead()
    {
        Destroy(gameObject);
        enemyController.DestroyController();
        Instantiate(enemyHealthEF, transform.position, transform.rotation);
    }
}
