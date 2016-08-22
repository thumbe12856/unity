using UnityEngine;
using System.Collections;

public class First_person_camera : MonoBehaviour {

    public GameObject MainPerson;
    private Vector3 PersonOffset;
    private Vector3 OriginalPersonOffset;
    private int ScaleSpeed;
    private float MinFieldOfView = 0.8f;
    private float MaxFieldOfView = 100f;
    private float MinYOrbit = -85F;
    private float MaxYOrbit = 85F;
    public bool fighting;

    // Use this for initialization
    void Start ()
    {
        //unity chan
        OriginalPersonOffset = new Vector3(-1f, 6f, 0f);

        PersonOffset = OriginalPersonOffset;
        ScaleSpeed = 2;
        fighting = true;
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
    }
}
