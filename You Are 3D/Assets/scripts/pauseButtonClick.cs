using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class pauseButtonClick : MonoBehaviour
{
    public void OnButtonPressed()
    {
        SceneManager.LoadScene("PauseMenu"); //change scene of next scene to link
    }
}