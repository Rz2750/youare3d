using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CompassManager : MonoBehaviour
{
        public Transform playerTransform;
        public Transform destTransform;
        public RectTransform compass;
        Vector3 dir;
    
        private void Update()
        {
            Vector3 dir = playerTransform.position - destTransform.position;
            dir.z = -dir.y;
            transform.localEulerAngles = dir;
            
        }
    // Update is called once per frame
    // 
    // public void changeNorth()
    // {
    //         direction.z = player.eulerAngles.y;
    //         northLayer.localEulerAngles = North;
    // }
    // 
    // public void changeMission()
    // {
    //         Vector3 dir = transform.position - missionPlace.position;
    //         direction = Quaternion.LookRotation(dir);
    //         direction.z = -direction.y;
    //         direction.x = 0;
    //         direction.y = 0;
    // 
    //         missionLayer.localRotation = direction * Quaternion.Euler(North);
    // }
}
