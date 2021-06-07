using System;
using UnityEngine;

public class Goal : MonoBehaviour
{
    [SerializeField] private Player player = null;
    
    public static event Action<Player> OnGoalScored;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            player.ScoreGoal();
            OnGoalScored?.Invoke(player);
        }
    }
}
