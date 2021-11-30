using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CompassManager : MonoBehaviour
{
        public Transform playerTransform;
        public Transform destTransform;
        public RectTransform compass;
        public GameObject glow;
        Vector3 dir;
    
        private void Update()
        {
            Vector3 dir = destTransform.position - playerTransform.position;
            compass.localEulerAngles = dir;
            glow.SetActive(false);
            isClose(dir);
            
        }
        
        private void isClose(Vector3 dir){
                if(dir.x < 0.5 && dir.y < 0.5 && dir.z < 0.5){
                        glow.SetActive(true);
                }
        }
        
}
