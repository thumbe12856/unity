using UnityEngine;
using System.Collections;

public class camera : MonoBehaviour {

    public Camera MainCamera;
    public GameObject MainPerson;
    private Vector3 PersonOffset;
    private int ScaleSpeed;
    private float MinFieldOfView = 20F;
    private float MaxFieldOfView = 150F;
    private float MinYOrbit = -85F;
    private float MaxYOrbit = 85F;
    private bool fighting;

    // Use this for initialization
    void Start ()
    {
        PersonOffset = new Vector3(0, 1.1F, 0F);
        ScaleSpeed = 2;
        fighting = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            fighting = !fighting;
        }
    }

    void LateUpdate()
    {
        ScaleByMouseCenter();
        RotateCamera();
        if (fighting) RotatePerson();
    }

    //rotate with mouse
    private float nowX;
    private float nowY;
    private Quaternion fromRotation;
    private Quaternion toRotation;
    public Vector3 destinition;
    void RotateCamera()
    {
        float x = Input.GetAxis("Mouse X") * 15;
        float y = Input.GetAxis("Mouse Y") * 15;
        nowX = nowX + x;
        nowY = nowY - y;
        if (nowY < MinYOrbit) nowY = MinYOrbit;
        else if (nowY > MaxYOrbit) nowY = MaxYOrbit;
        
        //camera rotation
        fromRotation = transform.rotation;
        toRotation = Quaternion.Euler(nowY, nowX, 0);
        transform.rotation = Quaternion.Lerp(fromRotation, toRotation, 1);

        //camera position
        destinition = toRotation * -Vector3.forward * PersonOffset.magnitude;
        destinition += MainPerson.transform.position + PersonOffset;
        transform.position = destinition;
    }

    void RotatePerson()
    {
        //person rotation
        fromRotation = MainPerson.transform.rotation;
        toRotation = Quaternion.Euler(0, nowX, 0);
        MainPerson.transform.rotation = Quaternion.Lerp(fromRotation, toRotation, 1);
    }

    void ScaleByMouseCenter()
    {
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            float CurrentFieldOfView = MainCamera.fieldOfView;
            CurrentFieldOfView += ScaleSpeed;
            
            if (CurrentFieldOfView > MaxFieldOfView)
                MainCamera.fieldOfView = MaxFieldOfView;
            else
                MainCamera.fieldOfView = CurrentFieldOfView;
        }
        
        else if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            float CurrentFieldOfView = MainCamera.fieldOfView;
            CurrentFieldOfView -= ScaleSpeed;
            if (CurrentFieldOfView < MinFieldOfView)
                MainCamera.fieldOfView = MinFieldOfView;
            else
                MainCamera.fieldOfView = CurrentFieldOfView;
        }
    }
}
