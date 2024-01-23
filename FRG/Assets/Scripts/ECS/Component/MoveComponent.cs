using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveComponent : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnMove(Vector2 direction)
    {
        Debug.Log(direction);
        // transform.localPosition += direction;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
