using UnityEngine;

public enum Direction
{
    X,
    Y
}

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CircleCollider2D))]
[RequireComponent(typeof(AudioSource))]
public class DevilController : MonoBehaviour
{
    public float speed = 10.0f;

    public float movementOnX = 0;

    public float movementOnY = 0;

    public Direction direction = Direction.X;

    public AudioClip collectableSound;

    public GameObject gameOverScreen;

    private Rigidbody2D rigidBody;
    private Vector2 previusPosition;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // FixedUpdate is called once per physic calculation
    void FixedUpdate()
    {
        // Get new position of our enemy
        var x = transform.position.x + movementOnX * Time.deltaTime * speed;

        var y = transform.position.y + movementOnY * Time.deltaTime * speed;

        // Set new position
        var pos = new Vector2(x, y);
        rigidBody.MovePosition(pos);
        if (previusPosition != null && Round(previusPosition.x) == Round(pos.x) && Round(previusPosition.y) == Round(pos.y))
        {
            if (direction.Equals(Direction.X))
            {
                movementOnX *= -1;
            }
            else {
                movementOnY *= -1;
            }
        }
        this.previusPosition = pos;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            // Play the enemy sound
            GetComponent<AudioSource>().PlayOneShot(collectableSound);

            // Hide the player
            collision.gameObject.GetComponent<Renderer>().enabled = false;

            // Destroy the player after a delay
            Destroy(collision.gameObject, collectableSound.length);

            // If so, show the game over screen
            if (gameOverScreen)
            {
                gameOverScreen.SetActive(true);
            }
        }
    }
    
    private float Round(float number)
    {
        return Mathf.Round(number * 100f) / 100f;
    }
}
