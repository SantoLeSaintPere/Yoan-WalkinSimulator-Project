using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class RayDetector : MonoBehaviour
{
    bool continueMove;
    Camera cam;
    public LayerMask objectToInteract;
    public float range;

    public ObjectToInteract obj;

    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponentInChildren<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        Ray theRay = cam.ViewportPointToRay(new Vector3(0.5f,0.5f,0));
        Debug.DrawRay(theRay.origin, theRay.direction * range, Color.yellow);

        if(Physics.Raycast(theRay, out RaycastHit hitInfo, range, objectToInteract))
        {
            Debug.Log("HIT");

            obj = hitInfo.collider.GetComponent<ObjectToInteract>();

           obj.hitted = true;
        }

        else
        {
            if(obj != null && !continueMove)
            {
                obj.hitted=false;
                obj = null;
            }
            Debug.Log("NO HIT");

        }

    }
}
