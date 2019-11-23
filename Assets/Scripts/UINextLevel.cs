using UnityEngine;
using UnityEngine.SceneManagement;

public class UINextLevel : MonoBehaviour
{
    public Levels levelName;

    public void PlayNextLevel()
    {
        var name = this.levelName.ToString();
        Time.timeScale = 1;
        SceneManager.LoadScene(name);
    }
}

public enum Levels
{
    Level1,
    Level2
}
