using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CircleCollider2D))]
public class PlayerController : MonoBehaviour
{
    public float speed = 10.0f;

    private Rigidbody2D rigidBody;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // FixedUpdate is called once per physic calculation
    void FixedUpdate()
    {
        // Get new position of our character
        var x = transform.position.x + Input.GetAxis("Horizontal") * Time.deltaTime * speed;

        var y = transform.position.y + Input.GetAxis("Vertical") * Time.deltaTime * speed;

        // Set new position
        rigidBody.MovePosition(new Vector2(x, y));
    }
}
