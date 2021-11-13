using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class sceneManager : MonoBehaviour
{
        public void OnButtonPress(){
            Debug.Log("You have pressed the button");
            SceneManager.LoadScene("sampleMaze"); //change to title of next scene to link
        }
}


