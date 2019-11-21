using System.Linq;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CircleCollider2D))]
public class PlayerController : MonoBehaviour
{
    public float speed = 10.0f;

    public Joystick variableJoystick;

    private Rigidbody2D rigidBody;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // FixedUpdate is called once per physic calculation
    void FixedUpdate()
    {

        var x = transform.position.x + Input.GetAxis("Horizontal") * Time.deltaTime * speed;

        var y = transform.position.y + Input.GetAxis("Vertical") * Time.deltaTime * speed;

        if (variableJoystick && Input.GetAxis("Horizontal") + Input.GetAxis("Vertical") == 0)
        {
            x = transform.position.x + variableJoystick.Horizontal * Time.deltaTime * speed;

            y = transform.position.y + variableJoystick.Vertical * Time.deltaTime * speed;
        }

        // Set new position
        rigidBody.MovePosition(new Vector2(x, y));
    }
}
