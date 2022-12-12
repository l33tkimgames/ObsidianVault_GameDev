using UnityEngine;

public class KeyCustomizer : MonoBehaviour
{
    // Set the default values for the input keys
    private static readonly KeyCode defaultForwardKey = KeyCode.W;
    private static readonly KeyCode defaultBackwardKey = KeyCode.S;
    private static readonly KeyCode defaultLeftKey = KeyCode.A;
    private static readonly KeyCode defaultRightKey = KeyCode.D;

    // Use this for initialization
    void Start()
    {
        // Get the current values for the input keys from the Input Manager
        KeyCode forwardKey = Input.GetKey(defaultForwardKey);
        KeyCode backwardKey = Input.GetKey(defaultBackwardKey);
        KeyCode leftKey = Input.GetKey(defaultLeftKey);
        KeyCode rightKey = Input.GetKey(defaultRightKey);

        // Check if the user has customized the keys and update the values accordingly
        if (PlayerPrefs.HasKey("forwardKey"))
        {
            forwardKey = (KeyCode)PlayerPrefs.GetInt("forwardKey");
        }
        if (PlayerPrefs.HasKey("backwardKey"))
        {
            backwardKey = (KeyCode)PlayerPrefs.GetInt("backwardKey");
        }
        if (PlayerPrefs.HasKey("leftKey"))
        {
            leftKey = (KeyCode)PlayerPrefs.GetInt("leftKey");
        }
        if (PlayerPrefs.HasKey("rightKey"))
        {
            rightKey = (KeyCode)PlayerPrefs.GetInt("rightKey");
        }

        // Set the updated values for the input keys in the Input Manager
        InputManager.instance.SetKey("forward", forwardKey);
        InputManager.instance.SetKey("backward", backwardKey);
        InputManager.instance.SetKey("left", leftKey);
        InputManager.instance.SetKey("right", rightKey);
    }
}
