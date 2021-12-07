using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneManagerLevel0 : MonoBehaviour
{
    public void OnButtonPress()
    {
        SceneManager.LoadScene("level 0"); //change to title of next scene to link
    }

    public void OnRestartPress()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);//change to title of next scene to link
    }
}
