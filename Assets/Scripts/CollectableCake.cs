using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(AudioSource))]
public class CollectableCake : MonoBehaviour
{
    public AudioClip collectableSound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the player collides with the angel's cake
        if (collision.tag == "Player")
        {
            //TODO: to implement increase number of collected cakes

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
