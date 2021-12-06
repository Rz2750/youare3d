using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossSectionScript : MonoBehaviour
{
    public Material crossMaterial;
    // public Transform mainCamera;
    public Transform playerpos;
    // public GameObject mazeLevel;
    //public float offset = 5f;
    
    // Start is called before the first frame update
    void Start()
    {
        crossMaterial = GetComponent<Renderer>().material;
        playerpos = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        // okay, this is all REALLY WEIRD, and i swear i'm going to go insane
        // from staring at all these numbers and trying to figure out how this
        // stupid system works.
        
        // if i want the maze to be sliced at z = 0, i must set w = 0.
        // to slice at z = 25 (top of the box in this example), w = -2.5.
        // to slice at z = 8.3333 (1/3 of the way up, since there's a useful guideline there), w = about -0.833333.
        // so it seems w needs to equal -0.1x where i want it to be in the z axis.
        // which is, like, what??????
        // but okay. fine. sure.
        
        // -0.6 so the walls extend to just behind the player position
        //
        // technically should be -0.75 to be half the player radius, but it
        // looks a little bit better if we make it slightly less, so the player
        // doesn't get blinded by stuff showing up behind them
        float adjustedpos = playerpos.position.z - 0.6f;
        
        // now slice
        Vector4 slice = new Vector4(0, 0, 1, -0.1f*adjustedpos);
        crossMaterial.SetVector("_section", slice);
        
        // how long the maze is (in the z direction)
        // float zwidth = mazeLevel.GetComponent<Renderer>().bounds.size.z;
        
        // where the maze is (in the z direction)
        // float zpos = mazeLevel.GetComponent<Transform>().position.z;
        
        // Debug.Log("z width is " + zwidth + ", z pos is " + zpos);
        
        // rend.material.SetVector("_Plane1Normal", normal1);
    }
}
