using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class nextLevelcolideScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (scene.name == "Level 0") {
            SceneManager.LoadScene("Level 1");
        } else {
            SceneManager.LoadScene("Micah's test scene"); //change to title of next scene to link
        }
    }
}
