using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    public GameObject player;
    private Vector3 offset;
    public GameObject target;


    // Use this for initialization
    void Start () {
        offset = transform.position - player.transform.position;
        nowX = 0;
        nowY = 0;
    }
	
	// Update is called once per frame
	void LateUpdate () {
        transform.position = player.transform.position + offset;
	}
    
    //rotate with mouse
    private float nowX;
    private float nowY;
    private Quaternion fromRotation;
    private Quaternion toRotation;
    void Update()
    {
        float x = Input.GetAxis("Mouse X") * 15;
        float y = Input.GetAxis("Mouse Y") * 15;
        nowX = nowX + x;
        nowY = nowY - y;
        
        target.SendMessage("CameraNowX", nowX);

        fromRotation = transform.rotation;
        toRotation = Quaternion.Euler(nowY, nowX, 0);
        transform.rotation = Quaternion.Lerp(fromRotation, toRotation, 1);
    }
}
