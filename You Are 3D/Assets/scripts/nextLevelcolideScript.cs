//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.SceneManagement;



//public class nextLevelcolideScript : MonoBehaviour
//{
//    private Scene scene;
//    void Start()
//    {
//        scene = SceneManager.GetActiveScene();
//    }

//    private void OnTriggerEnter(Collider other)
//    {
//        Debug.Log("rotate");


//        transform.Rotate(new Vector3(0f, 0f, 100f)*Time.deltaTime);
//        StartCoroutine(Example());

//        if (scene.name == "Level 0") {
//            SceneManager.LoadScene("Level 1");
//        } else if (scene.name == "Level 1") {
//            SceneManager.LoadScene("Level 2");
//        } else {
//            SceneManager.LoadScene("Micah's test scene"); //change to title of next scene to link
//        }
//    }
//    IEnumerator Example()
//    {
//        Debug.Log("waiting");
//        yield return new WaitForSecondsRealtime(100f);

//    }
//}

// transform.Rotate(new Vector3(0f, 100f, 0f) * Time.deltaTime);
//scaleChange = new Vector3(40f, 40f, 40f) * Time.deltaTime;
//cube.transform.localScale += scaleChange;
//scaleChange2 = new Vector3(50f, 50f, 20f) * Time.deltaTime;
//clinder.transform.localScale += scaleChange2;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class nextLevelcolideScript : MonoBehaviour
{
    private Scene scene;
    private bool collided = false;
    public GameObject cube;
    public GameObject clinder;

    private Vector3 scaleChange;
    private Vector3 scaleChange2;
    public ParticleSystem _psystem;

    void Start()
    {
        scene = SceneManager.GetActiveScene();
        _psystem.Stop();
    }
    void Update()
    {
        if (collided)
        {
            _psystem.Play();

            transform.Rotate(new Vector3(0f, 100f, 0f) * Time.deltaTime);
            scaleChange = new Vector3(30f, 30f, 30f) * Time.deltaTime;
            cube.transform.localScale += scaleChange;
            scaleChange2 = new Vector3(40f, 40f, 5f) * Time.deltaTime;
            clinder.transform.localScale += scaleChange2;


        }

    }

    IEnumerator OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("rotate");
            collided = true;
            yield return new WaitForSecondsRealtime(3.5f);

      
            if (scene.name == "Level 0")
            {
                SceneManager.LoadScene("Level 1");
            }
            else if (scene.name == "Level 1")
            {
                SceneManager.LoadScene("Level 2");
            }
            else if (scene.name == "Level 2")
            {
                SceneManager.LoadScene("Level 3");
            }
            else if (scene.name == "Level 3")
            {
                SceneManager.LoadScene("Level 4");
            }
            else if (scene.name == "Level 4")
            {
                SceneManager.LoadScene("Level 5");
            }
            else if (scene.name == "Level 5")
            {
                SceneManager.LoadScene("Level 6");
            }
            else if (scene.name == "Level 6")
            {
                SceneManager.LoadScene("Level 7");
            }
            else
            {
                SceneManager.LoadScene("Micah's test scene"); //change to title of next scene to link
            }
        }

      
    }

}



