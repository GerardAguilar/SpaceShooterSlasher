using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour {

    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnStart;
    public float spawnWait;
    public float waveWait;

    public Text scoreText;
    public int score;

    public Text restartText;
    public Text gameOverText;

    private bool gameOver;
    private bool restart;

    GameObject hazard;

    Vector3 spawnPosition;
    Quaternion spawnRotation;

    void Start() {
        hazard = (GameObject)Resources.Load("Asteroid");
        spawnValues = new Vector3(12f, 0f, 19f);
        hazardCount = 10;
        spawnStart = 1f;
        spawnWait = 0.5f;
        waveWait = .75f;
        restart = false;
        restartText = GameObject.Find("RestartText").GetComponent<Text>();
        restartText.text = "";
        gameOver = false;
        gameOverText = GameObject.Find("GameOverText").GetComponent<Text>();
        gameOverText.text = "";

        score = 0;
        scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
        UpdateScore();

        StartCoroutine (SpawnWaves());
    }

    void Update() {
        if (restart) {
            if (Input.GetKeyDown(KeyCode.R)) {
                Application.LoadLevel(Application.loadedLevel);
            }
        }
    }

    public void GameOver() {
        gameOverText.text = "Game Over!";
        gameOver = true;
    }

    public void AddScore(int newScoreValue) {
        score += newScoreValue;
        UpdateScore();
    }

    void UpdateScore() {
        scoreText.text = "Score: " + score;
    }

    IEnumerator SpawnWaves() {
        yield return new WaitForSeconds(spawnStart);
        while (true) {
            for (int i = 0; i < hazardCount; i++)
            {
                spawnPosition = new Vector3(
                Random.Range(-spawnValues.x, spawnValues.x),
                spawnValues.y,
                Random.Range(spawnValues.z, spawnValues.z + 5f));

                spawnRotation = Quaternion.identity;

                Instantiate(hazard, spawnPosition, spawnRotation);

                yield return new WaitForSeconds(spawnWait);
            }

            yield return new WaitForSeconds(waveWait);

            if (gameOver) {
                restartText.text = "Press 'R' for Restart";
                restart = true;
                break;
            }
        }
    }
}
