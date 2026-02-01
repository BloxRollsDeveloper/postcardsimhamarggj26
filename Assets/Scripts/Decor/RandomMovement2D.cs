using System.Collections;
using UnityEngine;

public class RandomMovement2D : MonoBehaviour
{
    public float speed = 3f;
    public float directionChangeInterval = 2f;
    private Vector2 moveDirection;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(ChangeDirectionRoutine());
    }

    void FixedUpdate()
    {
        if (rb != null)
        {
            rb.linearVelocity = moveDirection * speed;
        }
    }

    IEnumerator ChangeDirectionRoutine()
    {
        while (true)
        {
            int randomDir = Random.Range(0, 4);

            switch (randomDir)
            {
                case 0: // Up
                    moveDirection = Vector2.up;
                    break;
                case 1: // Down
                    moveDirection = Vector2.down;
                    break;
                case 2: // Left
                    moveDirection = Vector2.left;
                    break;
                case 3: // Right
                    moveDirection = Vector2.right;
                    break;
            }
            
            yield return new WaitForSeconds(directionChangeInterval);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        StartCoroutine(ChangeDirectionRoutine());
    }
}