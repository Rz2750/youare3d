using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CompassManager : MonoBehaviour
{
    public Vector3 North;
    public Transform player;
    public Quaternion direction;
    public RectTransform northLayer;
    public RectTransform missionLayer;
     public Transform missionPlace;
    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void changeNorth()
    {
            direction.z = player.eulerAngles.y;
            northLayer.localEulerAngles = North;
    }
    
    public void changeMission()
    {
            Vector3 dir = transform.position - missionPlace.position;
            direction = Quaternion.LookRotation(dir);
            direction.z = -direction.y;
            direction.x = 0;
            direction.y = 0;
            
            missionLayer.localRotation = direction * Quaternion.Euler(North);
    }
}
