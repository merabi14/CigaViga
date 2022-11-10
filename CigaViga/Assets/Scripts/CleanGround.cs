using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleanGround : MonoBehaviour
{
    Transform camTransform;
    [Header("Size after object removed")]
    [SerializeField] float removeSize = 200f; 

    private void Start()
    {
        camTransform = Camera.main.transform;
    }

    private void Update()
    {

        if (transform.position.x < camTransform.position.x - removeSize)
        {
            Destroy(gameObject);
        }

    }
}
