using UnityEngine;
using System.Collections;

public class AsteroidMover : MonoBehaviour {

    public float speed;

    Rigidbody rb;

    Vector3 originPos;

    int forwardDirection;

    void Start()
    {
        speed = 3f;
        forwardDirection = -1;
        rb = GetComponent<Rigidbody>();
        rb.velocity = GetComponent<Transform>().forward * speed * forwardDirection;
        originPos = transform.localPosition;
    }
}
