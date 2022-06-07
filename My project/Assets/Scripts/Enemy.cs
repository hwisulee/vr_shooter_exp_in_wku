using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public TargetScript targetScript;
    
    private Transform target;
    private Vector3 targetPosition;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        targetPosition = new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z);

        if (targetScript.isHit != true)
        {
            transform.LookAt(targetPosition);
        }
    }
}
