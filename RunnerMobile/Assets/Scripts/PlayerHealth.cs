using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private PlayerController _playerController;
    private LevelManager _levelManager;
    private ScoreManager _scoreManager;

    private void Awake()
    {
        _playerController = FindObjectOfType<PlayerController>();
        _levelManager = FindObjectOfType<LevelManager>();
        _scoreManager = FindObjectOfType<ScoreManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Player Hit");
        if (other.CompareTag("Coin"))
        {
            _scoreManager.UpdateScore();
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("End"))
        {
            Debug.Log("Endline");
            _playerController.StopMoving();
            _levelManager.GameOver();
            _scoreManager.CheckScore();
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
            _levelManager.RestartLevel();
    }
}
