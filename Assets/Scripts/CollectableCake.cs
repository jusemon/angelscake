using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(AudioSource))]
public class CollectableCake : MonoBehaviour
{
    /// <summary>
    /// The collectable sound
    /// </summary>
    public AudioClip collectableSound;

    /// <summary>
    /// The cake value
    /// Stores the value of the cake in terms of Player's score
    /// </summary>
    public int cakeValue = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the player collides with the angel's cake
        if (collision.tag == "Player")
        {
            // If so, increase te number of cakes the player has collected
            FindObjectOfType<UIScore>().IncreaseScore(cakeValue);

            // Play the collectable sound
            GetComponent<AudioSource>().PlayOneShot(collectableSound);

            // Hide the cake
            GetComponent<Renderer>().enabled = false;

            // Destroy the cake after a delay
            Destroy(gameObject, collectableSound.length);

            // Destroy the script in case the player hits again the cake before that is destroyed
            Destroy(this);
        }
    }
}
