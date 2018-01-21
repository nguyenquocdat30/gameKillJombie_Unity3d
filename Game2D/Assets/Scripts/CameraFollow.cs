using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {
    public Transform target;
    
    public float smoothing;
    private Vector3 offset;
    //khi nhân vật rơi . camera không rơi theo
    private float lowY;
	// Use this for initialization
	void Start () {
        offset = transform.position - target.position;
        lowY = transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void FixedUpdate()
    {
        Vector3 targetCamPos = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);
        if(transform.position.y < lowY)
        {
            transform.position = new Vector3(transform.position.x, lowY, transform.position.z);
        }
        if (transform.position.y > lowY)
        {
            transform.position = new Vector3(transform.position.x, lowY, transform.position.z);
        }
    }
}
