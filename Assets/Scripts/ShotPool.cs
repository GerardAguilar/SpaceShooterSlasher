using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class ShotPool : MonoBehaviour {

    public int shotCount;
    public GameObject shot;
    public List<GameObject> shotArray;
    public GameObject shotPool;
    public Transform shotSpawn;

    int stepper;

    // Use this for initialization
    void Start () {
        shotCount = 20;
        shot = (GameObject)Resources.Load("Bolt");
        shotPool = GameObject.Find("ShotPool");
        shotSpawn = GameObject.Find("ShotSpawn").transform;
        stepper = 0;

        GameObject temp;
        for (int i = 0; i < shotCount; i++) {

            temp = (GameObject)Instantiate(
                    shot, shotPool.transform.position, shotPool.transform.rotation
                );
            temp.transform.SetParent(this.transform);
            temp.SetActive(false);
            shotArray.Add(temp);
        }
	}

    public void FireShot() {
        Debug.Log("FireShot()");
        for (int i = 0; i < shotCount; i++) {
            if (shotArray[i].activeSelf){}
            else {
                shotArray[i].SetActive(true);
                i = shotCount + 1;
            }
        }
    }
}
