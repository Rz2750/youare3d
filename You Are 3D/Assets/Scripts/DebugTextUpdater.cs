using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugTextUpdater : MonoBehaviour
{
    public Text debugText;
    Material cross;
    GameObject player;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectsWithTag("Player")[0];
        cross = GameObject.FindGameObjectsWithTag("Wall")[0].GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        float xpos = player.transform.position.x;
        float ypos = player.transform.position.y;
        float zpos = player.transform.position.z;
        
        string updated = "<DEBUG> x: " + xpos.ToString("#.00") + " y: " + ypos.ToString("#.00") + " z: " + zpos.ToString("#.00") + "\n" +
                         "cross-sec slice: " + cross.GetVector("_section").w.ToString("#.00");
        
        debugText.text = updated;
    }
}
