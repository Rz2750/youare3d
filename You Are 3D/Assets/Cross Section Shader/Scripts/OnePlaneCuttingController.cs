using UnityEngine;
using System.Collections;
//[ExecuteInEditMode]
public class OnePlaneCuttingController : MonoBehaviour {

    public GameObject plane;
    Material mat;
    public Vector3 normal;
    public Vector3 position;
    public Renderer rend;
    // Use this for initialization
    void Start () {
        rend = GetComponent<Renderer>();
        //normal = plane.transform.TransformVector(new Vector3(0,0,-1));
        normal = plane.transform.up;
        position = this.gameObject.transform.position - plane.transform.position;
        UpdateShaderProperties();
    }
    
    void FixedUpdate ()
    {
        UpdateShaderProperties();
    }

    private void UpdateShaderProperties()
    {
        Debug.Log("help " + rend.material.GetVector("_PlaneNormal"));
        //normal = plane.transform.TransformVector(new Vector3(0, 0, -1));
        normal = plane.transform.up;
        //Debug.Log("test " + plane.transform.up);
        position = this.gameObject.transform.position - plane.transform.position;
        //Debug.Log("test2 " + normal);
        rend.material.SetVector("_PlaneNormal", normal);
        //Debug.Log("test3 " + normal);
        //Debug.Log("help " + rend.material.GetVector("_PlaneNormal"));
        rend.material.SetVector("_PlanePosition", position);
    }
}
