using UnityEngine;
using System.Collections;

public class modelController : MonoBehaviour {
    public Rigidbody2D rb;
    MeshCollider cp;

    void Start ()
    {
        Vector2 movement = new Vector2(0f, 700f);
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(movement);
        Destroy(gameObject, 5f);
    }
}
