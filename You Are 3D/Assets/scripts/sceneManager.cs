using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class sceneManager : MonoBehaviour
{
        public void OnButtonPress(){
            SceneManager.LoadScene("sampleMaze"); //change to title of next scene to link
        }
        
        public void OnRestartPress(){
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);//change to title of next scene to link
        }
}


