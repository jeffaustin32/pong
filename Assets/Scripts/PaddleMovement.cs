using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PaddleMovement : MonoBehaviour
{
    [SerializeField] private float speed = 100f;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector3(0, 0, Input.GetAxis("Vertical") * speed);
    }
}
