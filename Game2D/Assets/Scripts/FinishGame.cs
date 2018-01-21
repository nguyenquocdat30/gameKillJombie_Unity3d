using UnityEngine;
using System.Collections;

public class FinishGame : MonoBehaviour {

    // Use this for initialization
    public GameObject panelWinGame;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            other.gameObject.SetActive(false);
            panelWinGame.SetActive(true);
        }
    }
}
