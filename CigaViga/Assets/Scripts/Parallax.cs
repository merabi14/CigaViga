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

    Vector2 constPrallaxEffect;


    private void Start()
    {
        lastCameraPosition = vmcam.position;
        
        Sprite _sprite = GetComponent<SpriteRenderer>().sprite;
        textureUnitSizeX = _sprite.bounds.size.x;
        textureUnitSizeY = _sprite.bounds.size.y;

        constPrallaxEffect = parallaxEffect;
    }

    private void LateUpdate()
    {

        //infinite Horizontal
        if (Mathf.Abs(vmcam.position.x - transform.position.x) >= textureUnitSizeX && infiniteHorizontal)
        {
            transform.position = new Vector3(vmcam.position.x, transform.position.y);
        } 
        
        Vector3 _deltaMovment = vmcam.position - lastCameraPosition;
        
        //Parallax
        transform.position += new Vector3(_deltaMovment.x * parallaxEffect.x, _deltaMovment.y * parallaxEffect.y);

        lastCameraPosition = vmcam.position;

        //infinite Vertical
        if ((transform.position.y + (textureUnitSizeY / 4) >= vmcam.position.y))
        {
            Debug.Log("Move Back");
            parallaxEffect.y = 1.01f;
        }
        else
        {
            parallaxEffect.y = constPrallaxEffect.y;
            Debug.Log("Parallax Move");
        }




        //if (transform.position.y + (textureUnitSizeY / 4) >= vmcam.position.y)
        //{
        //    Debug.Log("Move Back");
        //    countDown = 1000;
        //    transform.position = new Vector3(transform.position.x + (_deltaMovment.x * parallaxEffect.x), transform.position.y + _deltaMovment.y);
        //    lastCameraPosition = vmcam.position;
        //    countDown -= 0.01f;
        //    Debug.Log(countDown);
        //}
        //else if(countDown <= 0)
        //{
        //    Debug.Log("Parallax Move");
        //    Debug.Log(countDown);
        //    transform.position = new Vector3(transform.position.x + (_deltaMovment.x * parallaxEffect.x), transform.position.y + (_deltaMovment.y * parallaxEffect.y));
        //    lastCameraPosition = vmcam.position;
        //}

            //Debug.Log($"{vmcam.position} - {lastCameraPosition} = {_deltaMovment}");


            //Debug.Log($"X - {textureUnitSizeX} | Y - {textureUnitSizeY}");

            //transform.position = new Vector3(transform.position.x + (_deltaMovment.x * parallaxEffect.x), transform.position.y + (_deltaMovment.y * parallaxEffect.y));
    }
}
