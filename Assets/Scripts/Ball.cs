using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Ball : MonoBehaviour
{
    [SerializeField] private Vector3 startPosition = Vector3.zero;
    [SerializeField] private float speed = 60f;
    private Rigidbody rb = null;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        rb.velocity = rb.velocity.normalized * speed;
    }

    public void Launch()
    {
        float x = 45 * GetAngleCoefficient();
        float z = 45 * GetAngleCoefficient();

        Launch(new Vector3(x, 0, z));
    }
    
    public void Launch(Player playerToLaunchAt)
    {
        float x = playerToLaunchAt.transform.position.normalized.x * 45;
        float z = 45 * GetAngleCoefficient();
        
        Launch(new Vector3(x, 0, z));
    }

    public void Launch(Vector3 direction)
    {
        rb.velocity = direction.normalized * speed;
    }

    private int GetAngleCoefficient()
    {
        int random = Random.Range(0, 2);
        if (random == 0)
        {
            return -1;
        }
        else
        {
            return 1;
        }
    }

    public void Reset()
    {
        gameObject.transform.position = startPosition;
        rb.velocity = Vector3.zero;
    }
}
