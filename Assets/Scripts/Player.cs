using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] public string playerName = "Player";
    [SerializeField] public int score = 0;
    [SerializeField] private TMP_Text scoreText = null;

    public void Reset()
    {
        score = 0;
        scoreText.text = score.ToString();
    }

    public void ScoreGoal()
    {
        score++;
        scoreText.text = score.ToString();
    }
}
