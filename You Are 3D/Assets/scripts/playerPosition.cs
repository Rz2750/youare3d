using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerPosition : MonoBehaviour
{
        private float xpos;
        private float ypos;
        private float zpos;
        public Text playerpositions;
        public GameObject player;
        
    // void Start()
    // {
    //     xpos = player.transform.position.x;
    //     ypos = player.transform.position.y;
    //     zpos = player.transform.position.z;
    //     playerpositions.text = "x: " + xpos.ToString() + "y: " + ypos.ToString() + "z: " + zpos.ToString();
    // }

    // Update is called once per frame
    void Update()
    {
        xpos = player.transform.position.x;
        ypos = player.transform.position.y;
        zpos = player.transform.position.z;
        playerpositions.text = "x: " + xpos.ToString("#.00") + "y: " + ypos.ToString("#.00") + "z: " + zpos.ToString("#.00");
    }
}
