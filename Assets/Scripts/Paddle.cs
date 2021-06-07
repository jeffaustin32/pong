using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Paddle : MonoBehaviour
{
    [SerializeField] private float speed = 100f;
    private bool movementEnabled = true;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        GameManager.OnGameStart += HandleOnGameStart;
        GameManager.OnGameEnd += HandleOnGameEnd;
    }

    private void OnDestroy()
    {
        GameManager.OnGameStart -= HandleOnGameStart;
        GameManager.OnGameEnd -= HandleOnGameEnd;
    }

    private void HandleOnGameEnd()
    {
        movementEnabled = false;
    }

    private void HandleOnGameStart()
    {
        movementEnabled = true;
    }

    private void FixedUpdate()
    {
        if (movementEnabled)
        {
            rb.velocity = new Vector3(0, 0, Input.GetAxis("Vertical") * speed);
        }
    }
}
