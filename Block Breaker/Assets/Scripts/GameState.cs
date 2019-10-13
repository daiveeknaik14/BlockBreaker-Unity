using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameState : MonoBehaviour
{
    [Range(0.1f, 10f)] [SerializeField] float gameSpeed = 1f;
    [SerializeField] int pointsPerBlock;
    [SerializeField] int score;
    [SerializeField] TextMeshProUGUI scoreDisplay;
    private void Awake()
    {
        int gameStatusCount = FindObjectsOfType<GameState>().Length;
        if(gameStatusCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        scoreDisplay.text = score.ToString();
    }
    void Update()
    {
        Time.timeScale = gameSpeed;
    }
    public void AddPointsToScore()
    {
        score += pointsPerBlock;
        scoreDisplay.text = score.ToString();
    }
    public void resetGame()
    {
        Destroy(gameObject);
    }
}
