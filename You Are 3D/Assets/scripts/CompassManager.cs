using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class CompassManager : MonoBehaviour
{
        public Transform playerTransform;
        public Transform destTransform;
        public RectTransform compass;
        public GameObject glow;
        Vector3 dir;
    
        private void Update()
        {
            float angle = calculate();
            Vector3 rotation = new Vector3(0, 0, angle);
            compass.eulerAngles = rotation;
            glow.SetActive(false);
            isClose(dir);
            
        }
        
        private void isClose(Vector3 dir){
                if(dir.x < 1 && dir.y < 1 && dir.z < 1){
                        glow.SetActive(true);
                }
        }
        
        private float calculate()
        {
                double Ay = playerTransform.position.z;
                double Ax = playerTransform.position.x;
                double By = destTransform.position.z;
                double Bx = destTransform.position.x;
                double A = Math.Sqrt((Ay*Ay)+(Ax*Ax));
                double B = Math.Sqrt((By*By)+(Bx*Bx));
                dir = destTransform.position - playerTransform.position;
                double Cx = dir.x;
                double Cy = dir.z;
                double C = Math.Sqrt((Cy*Cy)+(Cx*Cx));
                double g = (((A*A)+(C*C)-(B*B))/(2*A*C));
                double G = Math.Acos(g)*(180/Math.PI);
                return (float)G;
        }
        
}
