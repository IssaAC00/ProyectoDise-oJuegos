using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmParent : MonoBehaviour
{
    public Vector2 PointerPosition { get; set; }
    private bool isFlipped;
    private PlayerController playerCont;

    private void Awake()
    {
        playerCont = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        // Check if player can move
        if(!playerCont.canMove)
            return;

        Vector3 mousePos = Input.mousePosition;
        mousePos.z = -10f;
        Vector3 objectPos = Camera.main.WorldToScreenPoint(transform.position);
        mousePos.x -= objectPos.x;
        mousePos.y -= objectPos.y;

        float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
        angle += 90;
        /*
        // Flip horizontally when pointing behind
        if (angle < 0 && !isFlipped)
        {
            Vector3 tempPos = transform.position;
            tempPos.x *= -1f;
            transform.position = tempPos;
            isFlipped = true;
        }
        else if (angle > 0 && isFlipped)
        {
            Vector3 tempPos = transform.position;
            tempPos.x *= -1f;
            transform.position = tempPos;
            isFlipped = false;
        }*/
        // Change rotation
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }
}
