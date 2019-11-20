using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScore : MonoBehaviour
{

    /// <summary>
    /// The UI text
    /// Reference to the Text component, set in the Start() function
    /// </summary>
    private Text uiText;

    /// <summary>
    /// Current score of the player
    /// </summary>
    private int score;

    /// <summary>
    /// Points required to next level (set in the Inspector)
    /// </summary>
    [SerializeField]
    private int pointsToNextLevel;

    /// <summary>
    /// Reference to the game over screen GameObject (set in the Inspector)
    /// </summary>
    [SerializeField]
    private GameObject gameOverScreen;

    // Start is called before the first frame update
    void Start()
    {

        // Get a Reference to the Text component
        uiText = GetComponent<Text>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void IncreaseScore(int points)
    {
        // Increase the points
        score += points;

        // Check if player has collected all the points to the next level
        if (score >= pointsToNextLevel)
        {
            // If so, show the game over screen
            gameOverScreen.SetActive(true);

            // Disable the plater controller, so the player cannot move while the game over is on
            FindObjectOfType<PlayerController>().enabled = false;

        }

        // Update the score count
        uiText.text = $"Score: {score.ToString()}";
    }
}
