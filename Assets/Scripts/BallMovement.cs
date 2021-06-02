using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BallMovement : MonoBehaviour
{
    [SerializeField] private float speed = 20f;

    void Start()
    {
        Vector3 direction = new Vector3(Random.Range(0, 360), 0, Random.Range(0, 360)).normalized;
        Debug.Log(direction);
        Debug.Log(direction.magnitude);
        GetComponent<Rigidbody>().velocity = direction * speed;
    }
}
