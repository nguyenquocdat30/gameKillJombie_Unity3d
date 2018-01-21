using UnityEngine;
using System.Collections;

public class Distroy : MonoBehaviour {
    // thời gian tồn tại của viên đạn
    public float aliveTime;
	// Use this for initialization
	void Start () {
        Destroy(gameObject, aliveTime);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
