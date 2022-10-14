using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    Transform cameraTransform;
    float textureUnitSizeX;

    private void Start()
    {
        cameraTransform = Camera.main.transform;
        Sprite sprite =  GetComponent<SpriteRenderer>().sprite;
        Texture2D texture = sprite.texture;
        textureUnitSizeX = texture.width / sprite.pixelsPerUnit;
    }
    private void Update()
    {
        //Endless Parallax Calculation
        if(Mathf.Abs(cameraTransform.position.x - transform.position.x) >= textureUnitSizeX)
        {
            float offsetpositionX = (cameraTransform.position.x - transform.position.x) % textureUnitSizeX;
            transform.position = new Vector3(cameraTransform.position.x + offsetpositionX, transform.position.y);
        }
    }
}
