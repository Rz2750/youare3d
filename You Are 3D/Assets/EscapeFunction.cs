using UnityEngine;
using System.Collections;

// Quits the player when the user hits escape

public class EscapeFunction : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKey("escape"))
        {
            QuitGame();
        }
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
