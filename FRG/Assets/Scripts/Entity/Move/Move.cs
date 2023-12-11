using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Move : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.DOLocalMove(new Vector3(1,0,0),2.0f).SetLoops(-1, LoopType.Yoyo);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
