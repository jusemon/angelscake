using System.Linq;
using UnityEngine;

public class CustomJoystick : MonoBehaviour
{
    public RuntimePlatform[] allowedPlatforms = new[] {
            RuntimePlatform.Android,
            RuntimePlatform.IPhonePlayer,
            RuntimePlatform.WindowsEditor,
            RuntimePlatform.WebGLPlayer
        };

    // Start is called before the first frame update
    void Start()
    {
        if (!allowedPlatforms.Contains(Application.platform))
        {
            Destroy(gameObject);
        }
    }
}
