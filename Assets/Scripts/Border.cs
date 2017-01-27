using UnityEngine;
using System.Collections;

public class Border : MonoBehaviour {

    void OnTriggerExit(Collider other) {
        if (other.gameObject.CompareTag("Shot"))
        {
            other.transform.position = other.transform.parent.transform.position;
            other.transform.rotation = other.transform.parent.transform.rotation;
            other.gameObject.SetActive(false);
        }

        if (other.gameObject.CompareTag("Enemy")) {
            other.gameObject.SetActive(false);
        }
    }
}
