using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

    public float maxHealth;
    private float currentHealth;
    //để sử dụng hiệu ứng
    public GameObject bloodEffect;

    // khai báo các biến UI
    public Slider playerHealthSlider;
    public GameObject panelOverGame;
    //=========================
	// Use this for initialization
	void Start () {
        currentHealth = maxHealth;
        playerHealthSlider.maxValue = maxHealth;
        playerHealthSlider.value = maxHealth;

    }
	
	// Update is called once per frame
	void Update () {
	    
	}

    void FixedUpdate()
    {
        if(gameObject.transform.position.y <= -10)
        {
            currentHealth = 0;
            playerHealthSlider.value = currentHealth;
            makeDead();
        }
    }

    public void AddDamage(float damage)
    {
        if (damage <= 0)
            return;
        currentHealth -= damage;
        playerHealthSlider.value = currentHealth;
        if(currentHealth <= 0)
        {
            makeDead();
            playerHealthSlider.gameObject.SetActive(false);
        }
    }
    private void makeDead()
    {
        Instantiate(bloodEffect, transform.position, transform.rotation);
        panelOverGame.SetActive(true);
        gameObject.SetActive(false);
    }
}
