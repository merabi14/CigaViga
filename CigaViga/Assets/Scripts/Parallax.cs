using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField] Transform vmcam;
    [Space]
    [Header("Must be in range (-1 to 1)")]
    [SerializeField] Vector2 parallaxEffect;
    [SerializeField] bool infiniteHorizontal;

    [Space]
    [SerializeField] bool LoopParallax;
    
    Camera cam;
    Vector3 lastCameraPosition;
    float textureUnitSizeX;
    float cameraWidth;
    Vector2 constParallaxEffect;
    
    private void Start()
    {
        cam = Camera.main;
        cameraWidth = cam.orthographicSize * cam.aspect * 2f;
        lastCameraPosition = vmcam.position;
        
        Sprite _sprite = GetComponent<SpriteRenderer>().sprite;
        textureUnitSizeX = _sprite.bounds.size.x;
        constParallaxEffect = parallaxEffect;
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

        if(transform.position.x < (vmcam.position.x + 2.8f) && LoopParallax)
        {
            parallaxEffect.x = 1.001f;
        }
        else if (transform.position.x > (vmcam.position.x + cameraWidth / 2) && LoopParallax)
        {
            parallaxEffect.x = constParallaxEffect.x;
        }
        lastCameraPosition = vmcam.position;
    }
}
