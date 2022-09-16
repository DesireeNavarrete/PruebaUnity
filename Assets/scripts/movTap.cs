using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movTap : MonoBehaviour
{

    void Start()
    {
        
    }


    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                var ray = Camera.main.ScreenPointToRay(touch.position);
                if (Physics.Raycast(ray))
                {
                    print("began");
                    
                }
            }
        }
    }


    /*
     
         if (Input.touchCount > 0)//buscar forma de filtrar por tag para poder preguntarle cuando esta tocando el dedo al cli
        {
            Touch touch = Input.GetTouch(0); 

            if (touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved)
            {
                print("asdasd");
                // get the touch position from the screen touch to world point
                touchedPos = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 10));
                // lerp and set the position of the current object to that of the touch, but smoothly over time.
                transform.position = Vector3.Lerp(transform.position, touchedPos, Time.deltaTime);
            }
        }
         
         
         */


    void movTapTap()
    {

    }


    private void OnCollisionEnter(Collision collision)
    {
       
    }
}
