using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class DragIt : MonoBehaviour
{
    //DragIt Script can be attached by the user to any prefab particle.  
    private Vector2 mousePosition;
    private Vector2 initialMousePosition;


    private Rigidbody rb;



    void Awake()
    {
        rb = GetComponent<Rigidbody>();   //this atom is labeled "rb"
    }

    public void OnMouseDown()
    {
        initialMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    public void OnMouseDrag()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Time.timeScale == 0)  //rb.MovePosition has no effect if Time is frozen
        {
            transform.position = mousePosition;
        }
        else
        {
            rb.MovePosition(mousePosition);
        }
    }



    // Update is called once per frame
    void OnMouseUp()
    {
        rb.velocity = Vector3.zero;    //need this because the dragging event produces momentum that create motion after mouse is released??!!
        rb.angularVelocity = Vector3.zero;
    }

}
