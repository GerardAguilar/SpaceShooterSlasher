using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour {

    public GameObject explosion;
    public GameObject playerExplosion;
    public int scoreValue;
    public GameController gameController;

    void Start() {
        scoreValue = 1;
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
        if (gameController == null) {
            Debug.Log("Cannot find 'GameController' script.");
        }
    }

    void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Border")) {
            return;
        }
        if (other.CompareTag("Shot")) {
            other.gameObject.SetActive(false);
        }

        
        if (other.CompareTag("Player")) {
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            gameController.GameOver();
            other.gameObject.SetActive(false);
        }

        Instantiate(explosion, transform.position, transform.rotation);
        gameController.AddScore(100);
        gameObject.SetActive(false);


    }
}
