using System;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Player player1 = null;
    [SerializeField] private Player player2 = null;
    [SerializeField] private Ball ball = null;

    [SerializeField] private TMP_Text previousWinnerText = null;
    [SerializeField] private Canvas menuCanvas = null;
    
    public static event Action OnGameStart;
    public static event Action OnGameEnd;

    private int gameOverScore = 3;
    private bool gameOver = true;

    private void Start()
    {
        Goal.OnGoalScored += HandleOnGoalScored;
    }

    private void Update()
    {
        if (gameOver && Input.GetMouseButtonDown(0))
        {
            StartGame();
        }
    }

    private void OnDestroy()
    {
        Goal.OnGoalScored -= HandleOnGoalScored;
    }

    public void StartGame()
    {
        OnGameStart?.Invoke();

        gameOver = false;
        menuCanvas.enabled = false;

        player1.Reset();
        player2.Reset();
        ball.Launch();
    }

    private void HandleOnGoalScored(Player playerWhoScored)
    {
        ball.Reset();

        if (playerWhoScored.score == gameOverScore)
        {
            EndGame(playerWhoScored);
            return;
        }

        ball.Launch(playerWhoScored);
    }

    private void EndGame(Player winner)
    {
        OnGameEnd.Invoke();

        gameOver = true;
        menuCanvas.enabled = true;

        previousWinnerText.text = $"{winner.playerName} won!";
        previousWinnerText.enabled = true;
    }
}
