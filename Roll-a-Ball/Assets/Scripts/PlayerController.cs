using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float speed;
    public Text countText;
    public Text winText;

    private Rigidbody rb;
    private float count;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winText.text = "";
        fromRotation = transform.rotation;
        nowX = 0;
    }

    public float cameraX;
    void CameraNowX(float x)
    {
        cameraX = x;
    }


    //rotate with mouse
    private float nowX;
    private Quaternion fromRotation;
    private Quaternion toRotation;
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical =  Input.GetAxis("Vertical");
        nowX = cameraX;

        fromRotation = transform.rotation;
        toRotation = Quaternion.Euler(0, nowX, 0);
        transform.rotation = Quaternion.Lerp(fromRotation, toRotation, 1);

        Vector3 moveDirection = new Vector3(0.1F * moveHorizontal, 0, 0.1F * moveVertical);
        rb.transform.Translate(moveDirection);
        //rb.AddForce(movement * speed);
    }


    void OnTriggerEnter(Collider other)
    {
        //Destroy(other.gameObject);
        if(other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }
    }

    void SetCountText()
    {
        countText.text = "完成度:\n" + (count / 150 * 100).ToString() + "%";
        if(count >= 150)
        {
            winText.text = "Hello World!";
        }
    }

}
