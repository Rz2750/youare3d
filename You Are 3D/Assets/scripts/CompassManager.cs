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
        Vector2 rotate;
    
        private void Update()
        {
            Vector3 dir = playerTransform.position - destTransform.position;
            rotate.x = dir.x;
            rotate.y = -dir.z;
            compass.localEulerAngles = dir;
            
        }
}
