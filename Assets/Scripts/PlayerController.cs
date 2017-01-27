using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary {
    public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour
{

    public float speed = 10f;
    public Rigidbody rb;
    public Boundary boundary;
    public float tilt;

    public GameObject shot;
    public Transform shotSpawn;
    public ShotPool shotPool;

    public float fireRate;
    public float nextFire;

    public BladePool bladePool;
    public float slashRate;
    public float nextSlash;

    void Start() {
        rb = GetComponent<Rigidbody>();
        boundary.xMin = -12f;
        boundary.xMax = 12f;
        boundary.zMin = -1f;
        boundary.zMax = 12f;

        tilt = 0f;

        shotPool = GameObject.Find("ShotPool").GetComponent<ShotPool>();
        bladePool = GameObject.Find("BladePool").GetComponent<BladePool>();

        fireRate = .1f;
        nextFire = 0.0f;

        slashRate = 1f;
        nextSlash = 0.0f;
    }

    void Update() {
        if (Input.GetButton("Fire1") && Time.time>nextFire) {
            nextFire = Time.time + fireRate;
            //Instantiate(object, position, rotation);
            shotPool.FireShot();
            GetComponent<AudioSource>().Play();
        }

        if (Input.GetButton("Fire2") && Time.time>nextSlash){
            Debug.Log(Time.time + " : " + nextSlash);
            nextSlash = Time.time + slashRate;
            bladePool.SwingBlade();

        }
    }

    void FixedUpdate()//goes through all the below code before updating
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.velocity = movement * speed;

        rb.position = new Vector3(
            Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax),
            0.0f,
            Mathf.Clamp(rb.position.z, boundary.zMin, boundary.zMax)
            );

        rb.rotation = Quaternion.Euler(0.0f, 0.0f, rb.velocity.x * -tilt);
    }
}