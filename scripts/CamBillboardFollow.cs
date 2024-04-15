
// cameraBillboardFollow.cs v03
//
// by Neil Carter (NCarter)
// modified by Juan Castaneda (juanelo) and nis (nischi)
// 
// parameters for back/forward

using UnityEngine;
using System.Collections;

public class CamBillboardFollow : MonoBehaviour
{

    public bool autoInit = true;
    public bool reverseFace = false;
    public Camera usedCamera;

    private bool billboardActive = true;
    
    GameObject myContainer;

    void Awake()
    {
        if (autoInit == true)
        {
            usedCamera = Camera.main;
            billboardActive = true;
        }

        myContainer = new GameObject();
        myContainer.name = "GOCont_" + transform.gameObject.name;
        myContainer.transform.position = transform.position;
        transform.parent = myContainer.transform;
    }


    void Update()
    {
        if (billboardActive == true)
        {
            myContainer.transform.LookAt(myContainer.transform.position +
                usedCamera.transform.rotation * (reverseFace ? Vector3.back : Vector3.forward), 
                usedCamera.transform.rotation * Vector3.up);
        }
    }
}