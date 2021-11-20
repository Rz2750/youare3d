using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShaderScriptTest : MonoBehaviour
{
    public Material crossMaterial;
    public Transform mainCamera;
    //public float offset = 5f;
    
    // Start is called before the first frame update
    void Start()
    {
        crossMaterial = GetComponent<Renderer>().material;
        mainCamera = GameObject.FindWithTag("MainCamera").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector4 camPos = new Vector4(0, 0, 1, -0.3f*mainCamera.position.z);
        crossMaterial.SetVector("_section", camPos);
        
        // rend.material.SetVector("_Plane1Normal", normal1);
    }
}
