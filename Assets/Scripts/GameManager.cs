using UnityEngine;
using UnityEngine.UI;
using System;

public class GameManager : MonoBehaviour
{
    public Player player;
    public Text scoreText;
    public GameObject playButton;
    public GameObject gameOver;
    private int score;
    public GameObject ground;
    private Parallax groundController;
    public GameObject background;
    private Parallax backgroundController;
    public GameObject pipes;
    private Spawner spawner;
    private float gameSpeed;

    private void Awake() {
        Time.timeScale = 0f;
        Application.targetFrameRate = 60;
        groundController = ground.GetComponent<Parallax>();
        backgroundController = background.GetComponent<Parallax>();
        spawner = pipes.GetComponent<Spawner>();
        Pause();
    }

    public void Play() {
        score = 0;
        scoreText.text = score.ToString();
        playButton.SetActive(false);
        gameOver.SetActive(false);
        Time.timeScale = 1f;
        groundController.ResetSpeed();
        backgroundController.ResetSpeed();
        spawner.ResetSpeed();
        player.enabled = true;

        Pipes[] pipes = FindObjectsOfType<Pipes>();
        for (int i = 0; i < pipes.Length; i++) {
            Destroy(pipes[i].gameObject);
        }
    }

    public void Pause() {
        Time.timeScale = 0f;
        player.enabled = false;
    }

    public void GameOver() {
        gameOver.SetActive(true);
        playButton.SetActive(true);
        Pause();
    }

    public void IncreaseScore() {
        //score = score + 10;
        score++;
        scoreText.text = score.ToString();

        gameSpeed = (float)(0.01 * score);
        gameSpeed = Math.Min(gameSpeed, (float)(5 + 0.1 * gameSpeed - 1));
        groundController.animationSpeed = groundController.animationSpeed + 0.05f * gameSpeed;
        backgroundController.animationSpeed = backgroundController.animationSpeed + 0.05f * gameSpeed;
        spawner.spawnRate = spawner.spawnRate - 0.008f * gameSpeed;
        spawner.IncreaseSpeed();
        Debug.Log(gameSpeed);
        Debug.Log("ground" + groundController.animationSpeed);
        Debug.Log("background" + backgroundController.animationSpeed);
        Debug.Log("spawn rate" + spawner.spawnRate);
    }
}