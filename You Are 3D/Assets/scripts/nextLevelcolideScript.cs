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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class nextLevelcolideScript : MonoBehaviour
{
    //GameObject player;
    private Scene scene;
    private bool collided = false;
    void Start()
    {
        scene = SceneManager.GetActiveScene();
    }
    void Update()
    {
        if (collided)
        {
            transform.Rotate(new Vector3(0f, 100f, 0f) * Time.deltaTime);

        }

    }

    IEnumerator OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("rotate");
            collided = true;
            yield return new WaitForSecondsRealtime(3f);

      
            if (scene.name == "Level 0")
            {
                SceneManager.LoadScene("Level 1");
            }
            else if (scene.name == "Level 1")
            {
                SceneManager.LoadScene("Level 2");
            }
            else
            {
                SceneManager.LoadScene("Micah's test scene"); //change to title of next scene to link
            }
        }

      
    }

}
