using UnityEngine;
using System.Collections;

public class DestroyByTime : MonoBehaviour {

    public float lifetime;

    void Start() {
        lifetime = 2f;
        Destroy(gameObject, lifetime);
    }
}
