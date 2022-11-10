using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Parallax : MonoBehaviour
{
    [SerializeField] Transform vmcam;
    [Space]
    [Header("Must be in range (-1 to 1)")]
    [SerializeField] Vector2 parallaxEffect;
    [SerializeField] bool infiniteHorizontal;
    [SerializeField] bool infiniteVertical;

    
    Vector3 lastCameraPosition;
    float textureUnitSizeX;
    float textureUnitSizeY;


    private void Start()
    {
        lastCameraPosition = vmcam.position;
        
        Sprite _sprite = GetComponent<SpriteRenderer>().sprite;
        textureUnitSizeX = _sprite.bounds.size.x;
        textureUnitSizeY = _sprite.bounds.size.y;
    }

    private void LateUpdate()
    {
        if (Mathf.Abs(vmcam.position.x - transform.position.x) >= textureUnitSizeX && infiniteHorizontal)
        {
            transform.position = new Vector3(vmcam.position.x, transform.position.y);
        } 
        
        if (transform.position.y + (textureUnitSizeY / 4) >= vmcam.position.y)
        {
            Debug.Log("Move Back");
            transform.position = new Vector3(transform.position.x, transform.position.y - (1f * Time.deltaTime));
        }
        
        //Debug.Log($"X - {textureUnitSizeX} | Y - {textureUnitSizeY}");
        
        Vector3 _deltaMovment = vmcam.position - lastCameraPosition;
        transform.position += new Vector3( _deltaMovment.x * parallaxEffect.x, _deltaMovment.y * parallaxEffect.y);
        lastCameraPosition = vmcam.position;
    }
}
