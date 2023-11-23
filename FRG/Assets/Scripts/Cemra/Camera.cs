using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // targetPos = Vector3.Lerp(transform.position,target.position,0.03f);
        
    }

    void LateUpdate()
    {
        transform.position = new Vector3(target.position.x,target.position.y,-2);
    }

}
