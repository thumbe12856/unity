using UnityEngine;
using System.Collections;

public class Third_person_camera : MonoBehaviour
{

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
    void Start()
    {
        MainPerson = GameObject.FindGameObjectWithTag("Player");
        OriginalPersonOffset = new Vector3(-1f, 50f, 0f);

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
    }

    //rotate with mouse
    private Quaternion fromRotation;
    private Quaternion toRotation;
    private Vector3 destinition;
    void RotateCamera()
    {
        //camera position
        destinition = toRotation * -Vector3.forward * PersonOffset.magnitude;
        destinition += new Vector3(MainPerson.transform.position.x + PersonOffset.x,
                                    MainPerson.transform.position.y + OriginalPersonOffset.y,
                                    MainPerson.transform.position.z + PersonOffset.z);
        transform.position = destinition;
        transform.LookAt(MainPerson.transform);
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
