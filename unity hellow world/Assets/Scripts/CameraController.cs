using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    public GameObject player;
    private Vector3 offset;

    // Use this for initialization
    void Start () {
        offset = transform.position - player.transform.position;
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
        float x = Input.GetAxis("Mouse X") * 30;
        float y = Input.GetAxis("Mouse Y") * 30;
        nowX = nowX + x;
        nowY = nowY - y;

        fromRotation = transform.rotation;
        toRotation = Quaternion.Euler(nowY, nowX, 0);
        transform.rotation = Quaternion.Lerp(fromRotation, toRotation, 1);
    }
}
