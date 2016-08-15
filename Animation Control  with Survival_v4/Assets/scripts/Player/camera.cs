using UnityEngine;
using System.Collections;

public class camera : MonoBehaviour {

    public Camera MainCamera;
    public GameObject MainPerson;
    public PlayerHealth playerHealth;
    private Vector3 PersonOffset;
    private Vector3 OriginalPersonOffset;
    private int ScaleSpeed;
    private float MinFieldOfView = 0.8f;
    private float MaxFieldOfView = 3f;
    private float MinYOrbit = -85F;
    private float MaxYOrbit = 85F;
    public bool fighting;

    // Use this for initialization
    void Start ()
    {
        OriginalPersonOffset = new Vector3(0, 1.1F, 0F);
        PersonOffset = OriginalPersonOffset;
        ScaleSpeed = 2;
        fighting = true;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab) && playerHealth.currentHealth > 0)
        {
            fighting = !fighting;
        }
        else if (playerHealth.currentHealth <= 0)
        {
            fighting = false;
        }
    }

    void LateUpdate()
    {
        RotateCamera();
        ScaleByMouseCenter();
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
        nowX = (nowX + x);
        nowY = (nowY - y);
        if (nowY < MinYOrbit) nowY = MinYOrbit;
        else if (nowY > MaxYOrbit) nowY = MaxYOrbit;

        //camera rotation
        fromRotation = transform.rotation;
        toRotation = Quaternion.Euler(nowY, nowX, 0);
        transform.rotation = Quaternion.Lerp(fromRotation, toRotation, 1);

        //camera position
        destinition = toRotation * -Vector3.forward * PersonOffset.magnitude;
        destinition += new Vector3(MainPerson.transform.position.x + PersonOffset.x,
                                    MainPerson.transform.position.y + OriginalPersonOffset.y,
                                    MainPerson.transform.position.z + PersonOffset.z);
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
        float mInput = -Input.GetAxis("Mouse ScrollWheel");
        if (mInput != 0)
        {
            float newOffset = (PersonOffset.magnitude + mInput);
            newOffset = newOffset < MinFieldOfView ? MinFieldOfView : (newOffset > MaxFieldOfView ? MaxFieldOfView : newOffset);
            PersonOffset = PersonOffset * newOffset / PersonOffset.magnitude;
        }
        /*if (Input.GetAxis("Mouse ScrollWheel") < 0)
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
        }*/
    }
}
