using UnityEngine;
using System.Collections;

public class Shot : MonoBehaviour {

    public float speed;

    Vector3 originPos;
    Rigidbody rb;
    
    void Start() {
        speed = 30f;
        rb = GetComponent<Rigidbody>();
        rb.velocity = GetComponent<Transform>().forward*speed;
        originPos = transform.localPosition;
    }

    void OnDisable() {
        transform.localPosition = originPos;
    }
}
