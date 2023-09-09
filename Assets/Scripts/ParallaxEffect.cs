using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    // Start is called before the first frame update
    public Camera cam;
    public Transform followTarget;
    Vector2 startingPosition;

    Vector2 camMoveSinceStart => (Vector2)cam.transform.position - startingPosition;
    float startindZ;
    float distanceFromTarget => transform.position.z - followTarget.transform.position.z;
    float clippingPlane => (cam.transform.position.z + (distanceFromTarget > 0 ? cam.farClipPlane : cam.nearClipPlane));
    float parallaxEffect => Mathf.Abs(distanceFromTarget) / clippingPlane;
    void Start()
    {

        startingPosition = transform.position;
        startindZ = transform.position.z;
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 newPosition = startingPosition + camMoveSinceStart * parallaxEffect;

        transform.position = new Vector3(newPosition.x, newPosition.y, startindZ);
        
    }
}
