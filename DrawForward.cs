using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawForward : MonoBehaviour
{
    public float mLenLine = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, transform.forward * 5f + transform.position);

    }
}
