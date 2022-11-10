using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private int _score;
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private int _goalScore;
    [SerializeField] private GameObject _endPanel;

    private PlayerController _playerController;

    private void Awake()
    {
        _playerController = FindObjectOfType<PlayerController>();
    }
    
    public void UpdateScore()
    {
        _score++;
        _scoreText.text = _score.ToString("Score: 0");
    }

    public void CheckScore()
    {
        _endPanel.SetActive(true);
        if (_score >= _goalScore)
        {
            Debug.Log("You Win");
            _playerController.ChangeAnimation(true);
        }
        else
        {
            Debug.Log("You Lose");
            _playerController.ChangeAnimation(false);
        }
    }
}
