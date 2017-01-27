//We'll have to clean this up
//1. Make the blade spin 360 degrees
//2. Make the blade follow the parent even when rotating.
//3. Maybe keep the weapon simple instead of rotating.

using UnityEngine;
using System.Collections;

public class Swinger : MonoBehaviour {

    public float acceleration;
    public Quaternion originalRotation;
    float maxAcc;

    void OnEnable() {
        Debug.Log("Swinger's Awake: Acc = " + acceleration);
        acceleration = 1;
        maxAcc = 28;
        originalRotation = transform.rotation;
    }
	// Use this for initialization
	void Update () {
        //transform.Rotate(Vector3.up * Time.deltaTime*200*acceleration);
        //if (acceleration < maxAcc) {
        //    acceleration += 1;
        //}
        //transform.Rotate(0f, Time.deltaTime*acceleration*40, 0f);
        transform.RotateAround(transform.parent.transform.position, transform.parent.transform.up, 100*Time.deltaTime);
        if (acceleration < maxAcc)
        {
            acceleration += 1;
        }
        else {
            gameObject.SetActive(false);
        }
    }

    void OnDisable() {
        transform.rotation = originalRotation;
        Debug.Log("Swinger's OnDisable: Acc = " + acceleration);
    }

}
