using UnityEngine;
using System.Collections;

public class ProjectTileController : MonoBehaviour {
    // tốc độ viên đạn
    public float bulletSpeed;
    private Rigidbody2D myBody;
    // hàm này sẽ được gọi trước hàm start
    // 
    void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        if (transform.localRotation.z > 0)
        {
            //thêm một xung lực ForeceMode2D vào trong một lực Force với chiều x = -1 >> sang trái
            myBody.AddForce(new Vector2(-1,0) * bulletSpeed, ForceMode2D.Impulse);
        }
        else
        {
            myBody.AddForce(new Vector2(1, 0) * bulletSpeed, ForceMode2D.Impulse);
        }
        
        
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    // tạo chức năng làm viên đạn dừng lại khi trúng
    public void removeForce()
    {
        myBody.velocity = new Vector2(0, 0);
    }
}
