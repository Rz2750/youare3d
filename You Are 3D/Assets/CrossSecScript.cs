using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossSecScript : MonoBehaviour {
    
    public GameObject player;
    public GameObject cutPlane;
    
    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void FixedUpdate() {
        cutPlane.transform.position = player.transform.position;
        
        Debug.Log(cutPlane.transform.up);
        
        // GameObject[] arr = GameObject.FindGameObjectsWithTag("Wall");
        // GameObject[] toCut = new GameObject[arr.Length+1];
        // toCut[0] = player;
        // arr.CopyTo(toCut, 1);
        // 
        // foreach (GameObject obj in toCut) {
        //     obj.GetComponent<Renderer>().material.SetFloat("_PlaneNormal", new Vector3(3,3,3));
        // }
    }
}
