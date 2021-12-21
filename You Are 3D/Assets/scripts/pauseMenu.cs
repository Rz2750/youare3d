//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;
//using UnityEngine.SceneManagement;
//using UnityEngine.Audio;

//public class pauseMenu : MonoBehaviour
//{

//    public bool GameisPaused = true;
//    public GameObject pauseMenuUI;
//    //uncomment when volume and audio is added
//    /*void Awake()
//    {
//        SetLevel(volumeLevel);
//        GameObject sliderTemp = GameObject.FindWithTag("PauseMenuSlider");
//        if (sliderTemp != null)
//        {
//            sliderVolumeCtrl = sliderTemp.GetComponent<Slider>();
//            sliderVolumeCtrl.value = volumeLevel;
//        }
//    }*/

//    void Start()
//    {
//        /*pauseMenuUI.SetActive(false);*/
//    }

//    void Update()
//    {

//        /*if (GameisPaused)
//        {
//            Resume();
//        }
//        else
//        {
//            Pause();
//        }*/

//    }

//    /*public void Pause()
//    {
//        pauseMenuUI.SetActive(true);
//        Time.timeScale = 0f;
//        GameisPaused = true;
//    }*/

//public void Resume()
//{
//    pauseMenuUI.SetActive(false);
//    Time.timeScale = 1f;
//    GameisPaused = false;
//}

//public void Restart()
//{
//    Time.timeScale = 1f;
//    //restart the game:
//    //SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex);
//    SceneManager.LoadScene("SampleMaze");
//}

//public void Menu()
//{
//    Time.timeScale = 1f;
//    //restart the game:
//    //SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex);
//    SceneManager.LoadScene("TITLESCREEN");
//}
//    /*
//    public void SetLevel(float sliderValue)
//    {
//        mixer.SetFloat("MusicVolume", Mathf.Log10(sliderValue) * 20);
//        volumeLevel = sliderValue;
//    }*/
//}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class pauseMenu : MonoBehaviour
{

    public static bool GameisPaused = false;
    public GameObject pauseMenuUI;
    public Button pauseButton;
    //public Button resetButton;
    //public Button resumeButton;
    //public Button menuButton;
    private bool buttonPaused = false;




    void Start()
    {
        pauseMenuUI.SetActive(false);
    }

    void Update()

    {
        //Button btn1 = resetButton.GetComponent<Button>();
        //btn1.onClick.AddListener(Restart);

        Button btn = pauseButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);

        if (Input.GetKeyDown(KeyCode.Escape) || buttonPaused){
            if (GameisPaused && !buttonPaused) {
                Resume();
            }
            else {
                Pause();
            }
        }


    }

    void TaskOnClick()
    {
        buttonPaused = true;
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameisPaused = true;
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameisPaused = false;
        buttonPaused = false;
    }

    public void Quit()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
        Application.Quit();
    }

    public void Menu()
    {
        Time.timeScale = 1f;
        GameisPaused = false;
        buttonPaused = false;

        //restart the game:
        //SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene("TITLESCREEN");
    }
}
