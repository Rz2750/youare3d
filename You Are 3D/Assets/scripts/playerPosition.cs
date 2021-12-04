using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerPosition : MonoBehaviour
{
        private float xpos;
        private float ypos;
        private float zpos;
        private float xdiff;
        private float ydiff;
        private float zdiff;
        public Text playerpositions;
        public GameObject player;
        public GameObject exit;
        
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
        
        xdiff = exit.transform.position.x - player.transform.position.x;
        ydiff = exit.transform.position.y - player.transform.position.y;
        zdiff = exit.transform.position.z - player.transform.position.z;
        
        playerpositions.text = "x: " + xpos.ToString("#.00") + " y: " + ypos.ToString("#.00") + " z: " + zpos.ToString("#.00") + "\nx: " + xdiff.ToString("#.00") + " y: " + ydiff.ToString("#.00") + " z: " + zdiff.ToString("#.00");
    }
}
