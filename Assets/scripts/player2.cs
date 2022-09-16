using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;


public class player2 : MonoBehaviour
{
    float vMov = 5f, vRot = 5;
    Rigidbody rigi;
    //Vector3 angle, movDer, movIzq, movFor, movBack;
    float hor,ver;
    //bool rotado;
    //float rotasion=0;
    //public Transform w,a,s,d,wd,wa,sa,sd;
    float vel = 8;

    public Joystick analogico;

    public Vector3 startPos;
    public Vector2 direction;

    //public Text m_Text;
    public string message;

    private Vector3 position;
    private float width;
    private float height;

    NavMeshAgent agent;

    public int layerMask;

    public Button botonsito;


    private void Awake()
    {
        width = (float)Screen.width / 2.0f;
        height = (float)Screen.height / 2.0f;

        // Position used for the cube.
        position = new Vector3(0.0f, 0.0f, 0.0f);

        agent = GetComponent<NavMeshAgent>();

    }

    void Start()
    {
        rigi = GetComponent<Rigidbody>();
        hor = Input.GetAxis("Horizontal");
        ver = Input.GetAxis("Vertical");
        //angle = new Vector3(0, 90, 0);
        //botonsito.onClick.AddListener(submit2);

    }

   
   
    public void submit2()
    {
        //Input.GetButton(KeyCode.);
        print("putas");
    }


    private void FixedUpdate()
    {


        /*if (Input.GetMouseButton(0))
        {
            RaycastHit hit;
            // Bit shift the index of the layer (8) to get a bit mask
            layerMask = 1<<6;


            //al clicar, el player va a ese punto
            //habria
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity, layerMask))
            {
                agent.destination = hit.point;
            }

            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.red);
        }*/

        //MOVIMIENTO MANDO
        Vector3 mov = new Vector3(Input.GetAxisRaw("Horizontal") * vel, rigi.velocity.y, Input.GetAxisRaw("Vertical") * vel);
        rigi.velocity = mov;

        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {
            Quaternion rot = Quaternion.LookRotation(new Vector3(mov.x, 0, mov.z));
            rot = rot.normalized;
            transform.rotation = Quaternion.Slerp(transform.rotation,rot ,6 * Time.deltaTime);
        }

        //MOVIMIENTO ANDROID JOYSTICK
        Vector3 mov2 = new Vector3(analogico.Horizontal* vel, rigi.velocity.y, analogico.Vertical * vel);
        rigi.velocity = mov2;

        if (analogico.Horizontal != 0 || analogico.Vertical != 0)
        {
            Quaternion rot2 = Quaternion.LookRotation(new Vector3(mov2.x, 0, mov2.z));
            rot2 = rot2.normalized;
            transform.rotation = Quaternion.Slerp(transform.rotation, rot2, 6 * Time.deltaTime);
        }
        

        //ANDROID
        /*if (Input.touchCount > 0)
        {
            if (P1.HitTest(Input.GetTouch(0).position))//Solo entra si es touch es  con un dedo y le das al boton
            {

                if (Input.GetTouch(0).phase == TouchPhase.Began)//solo detecta toque
                {

                }
                if (Input.GetTouch(0).phase == TouchPhase.Stationary)//mientras el dedo este pulsando
                {

                   
                }

                if (Input.GetTouch(0).phase == TouchPhase.Moved)//cuando arrastras el dedo
                {

                }
                if (Input.GetTouch(0).phase == TouchPhase.Ended)//al levantar el dedo y terminar el toque
                {
                }
            }
          */

        /*var fingerCount = 0;
        var fingerPos= 0;
        foreach (Touch touch in Input.touches)
        {
            if (touch.phase != TouchPhase.Ended && touch.phase != TouchPhase.Canceled)
            {
                fingerCount++;
            }
        }
        if (fingerCount > 0)
        {
            print("User has " + fingerCount + " finger(s) touching the screen");
        }

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            // Handle finger movements based on TouchPhase
            switch (touch.phase)
            {
                //When a touch has first been detected, change the message and record the starting position
                case TouchPhase.Began:
                    // Record initial touch position.
                    startPos = touch.position;
                    message = "Begun ";
                    gameObject.transform.Translate(startPos* Time.deltaTime,Space.World);

                    break;

                //Determine if the touch is a moving touch
                case TouchPhase.Moved:
                    // Determine direction by comparing the current touch position with the initial one
                    //direction = touch.position - startPos;
                    message = "Moving ";
                    break;

                case TouchPhase.Ended:
                    // Report that the touch has ended when it ends
                    message = "Ending ";
                    break;
            }
        }
        

        // Handle screen touches.
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            // Move the cube if the screen has the finger moving.
            if (touch.phase == TouchPhase.Moved)
            {
                Vector2 pos = touch.position;
                pos.x = (pos.x - width) / width;
                pos.y = (pos.y - height) / height;
                position = new Vector3(-pos.x, pos.y, 0.0f);

                // Position the cube.
                transform.position = position;
            }

            if (Input.touchCount == 2)
            {
                touch = Input.GetTouch(1);

                if (touch.phase == TouchPhase.Began)
                {
                    // Halve the size of the cube.
                    transform.localScale = new Vector3(0.75f, 0.75f, 0.75f);
                }

                if (touch.phase == TouchPhase.Ended)
                {
                    // Restore the regular size of the cube.
                    transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
                }
            }
        }

        */









        //MOV EN VERTICAL
        /*Vector3 v2 = rigi.velocity;
        v2.z = Input.GetAxisRaw("Vertical") * 5;
        rigi.velocity = v2;



        /*if (Input.GetAxisRaw("Horizontal") > 0f)//izq
        {
            transform.LookAt(d);
            print("d");
        }

        if (Input.GetAxisRaw("Horizontal") < 0f)//der
        {
            transform.LookAt(a);
            print("a");
        }*/



        /*if (Input.GetAxisRaw("Vertical") > 0f)//arriba
        {
            transform.LookAt(w);
            print("w");
        }

        if (Input.GetAxisRaw("Vertical") < 0f)//abajo
        {
            transform.LookAt(s);
            print("s");
        }

        //MOV EN DIAGONAL
        if (Input.GetAxisRaw("Vertical") > 0f && Input.GetAxisRaw("Horizontal") > 0f)//arriba-derecha
        {
            transform.LookAt(wd);
            print("w-d");
        }


        if (Input.GetAxisRaw("Vertical") > 0f && Input.GetAxisRaw("Horizontal") < 0f)//arriba-izquierda
        {
            transform.LookAt(wa);
            print("w-a");
        }


        if (Input.GetAxisRaw("Vertical") < 0f && Input.GetAxisRaw("Horizontal") < 0f)//abajo-izquierda
        {
            transform.LookAt(sa);
            print("s-a");
        }

        if (Input.GetAxisRaw("Vertical") < 0f && Input.GetAxisRaw("Horizontal") > 0f)//abajo-dereccha
        {
            transform.LookAt(sd);
            print("s-d");
        }*/

        //Si el horizontal es negativo, rota
        /*if (transform.forward.x * Input.GetAxisRaw("Horizontal") < 0f)//izq
        {
            //sign saca el simbolo, si horizontal es positivo son 90 de angulo, 
            //si horizontal es negativo, el angulo son -90
            Quaternion q = Quaternion.Euler(0, 90f * Mathf.Sign(Input.GetAxisRaw("Horizontal")),0);

            rigi.MoveRotation(q);
            //print("HI");
        }
        print(Input.GetAxisRaw("Vertical"));
        print(Input.GetAxisRaw("Horizontal"));

        /*-----------------------BUGS-----------------------------------------
        -SI NO SE MUVE PRIMERO HACIA LA IZQ, NO ROTA A LA DERECHA
        -AL MANTENER DOS EJES SE RALLA
        -LA ROTACION DE 180 FALLA AL ESTAR A 90 O -90


        -----------------------BUGS-----------------------------------------*/


        /*if (Input.GetAxisRaw("Horizontal") != 0.0f || Input.GetAxisRaw("Vertical") != 0.0f)
        { 


            //Si el vertical es negativo, rota para atras 180
            if (transform.forward.z * Input.GetAxisRaw("Vertical") < 0f)//PA ATRAS
            {
                rotasion += 180;
                //Quaternion q2 = Quaternion.Euler(0, 0f * Mathf.Sign(Input.GetAxisRaw("Vertical")), 0);
                Quaternion q2 = Quaternion.Euler(0,rotasion * Mathf.Sign(Input.GetAxisRaw("Vertical")), 0);
                print(rotasion);
                rigi.MoveRotation(q2);
            }

        //print(transform.rotation.y);

        //Si el vertical es positivo, rota para delante
            /*if (transform.forward.z * Input.GetAxisRaw("Vertical") > 0f)//PA LANTE
            {

                //Quaternion q2 = Quaternion.Euler(0, 0f * Mathf.Sign(Input.GetAxisRaw("Vertical")), 0);
                Quaternion q3 = Quaternion.Euler(0, 0f * Input.GetAxisRaw("Vertical"), 0);
                print("w");
                rigi.MoveRotation(q3);
            }
        //print(Input.GetAxisRaw("Vertical"));

        //MOV EN DIAGONAL
        /*
        //derecha
            /* if (Input.GetAxis("Horizontal") > 0)
             {
                 rotito = Input.GetAxisRaw("Horizontal");
                 rotito += Mathf.Clamp(rotito, 0, 90);
                 //transform.Translate(Input.GetAxisRaw("Horizontal") * Time.deltaTime, 0, 0);
                 print(rotito);
                 //Quaternion q = Quaternion.Euler(0,rotito,0);
                 //transform.Rotate(0, 90, 0);
                 //transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime);
                 transform.Translate( 5 * 5 * Time.deltaTime, 0,0);

             }

             if(Input.GetAxis("Horizontal") < 0)
             {
                 transform.Translate(-5 * 5 * Time.deltaTime, 0, 0);
                 rotado = true;

             }*/
        //}









        /*
         if (Input.GetKey(KeyCode.D))
         {
             if (rotado)
             {
                 //rotito = Input.GetAxisRaw("Horizontal");
                 //rotito += Mathf.Clamp(rotito, 0, 90);
                 transform.Rotate(0, 90, 0);
             }
         }
         print(rotado);
         if (Input.GetAxis("Vertical") < 0)
         {
             transform.Translate(0,0,0-5 * 5 * Time.deltaTime);

         }

         if (Input.GetAxis("Vertical") > 0)
         {
             transform.Translate(0,0,5 * 5 * Time.deltaTime);

         }
         //player movement
         /*rigi.velocity = new Vector2(Input.GetAxis("Horizontal") * 5, GetComponent<Rigidbody>().velocity.x);
         rigi.velocity = new Vector2(Input.GetAxis("Vertical") * 5, GetComponent<Rigidbody>().velocity.z);*/
        //transform.Rotate(0,Input.GetAxis("Horizontal") * Time.deltaTime * 200,0);
        //rigi.velocity = new Vector2(Input.GetAxis("Horizontal") * 5, GetComponent<Rigidbody>().velocity.z);

        //delao
        /*if (Input.GetAxisRaw("Horizontal") != 0.0f)
        {
            angle.Set(0f, Input.GetAxisRaw("Horizontal"), 0f);
            //Vector3 angleX = Mathf.Clamp(angleX, 0, 90);
            angle = angle.normalized * 15;//angle con magnitud 1
            angle.y += Mathf.Clamp(angle.y, 0, 90);
            rotC += Input.GetAxisRaw("Horizontal")*Time.deltaTime*.1f;
            //rotC += Mathf.Clamp(rotC, 0, 10);

            Quaternion rot = Quaternion.Euler(angle*5);
            //Quaternion rot = Quaternion.Euler(0,rotC,0);
            //rigi.MoveRotation(rigi.rotation * rot);
            rigi.MoveRotation(rigi.rotation * rot);



            //Vector3 dirV = transform.forward * Input.GetAxisRaw("Vertical")*.5f;
            //Vector3 dirH = transform.right * Input.GetAxisRaw("Horizontal");
            //Quaternion q = Quaternion.Euler(dirH* Time.deltaTime*100); gira en x

        }*/

        //pa la derecha
        /*if (Input.GetAxisRaw("Horizontal") > 0)
        {
            movDer = transform.right;
            movDer = movDer.normalized * 5 * Time.deltaTime; //mov magnitud 1
            rigi.MovePosition(rigi.position + movDer);

            //rotacion
            /*Quaternion rot4 = Quaternion.Euler(0, 90, 0 * Time.deltaTime);
            rigi.MoveRotation(rot4);
        }*/


        //pa la izquierda
        /*else if (Input.GetAxisRaw("Horizontal") < 0)
        {
            movIzq = -transform.right;
            movIzq = movIzq.normalized * 5 * Time.deltaTime; //mov magnitud 1
            rigi.MovePosition(rigi.position + movIzq);

            //rotacion
            /*Quaternion rot5 = Quaternion.Euler(0, -90, 0 * Time.deltaTime);
            rigi.MoveRotation(rot5);
        }*/


        //pa lante
        /*else if (Input.GetAxisRaw("Vertical") > 0){
            movFor = transform.forward;
            //mov2 = transform.right;
            movFor = movFor.normalized * 5 * Time.deltaTime; //mov magnitud 1
            rigi.MovePosition(rigi.position + movFor);
            print("palante");

            //rotacion
            /*Quaternion rot3 = Quaternion.Euler(0, 0, 0 * Time.deltaTime);
            rigi.MoveRotation(rot3);
        }*/

        //pa atras
        /*else if (Input.GetAxisRaw("Vertical") < 0)
        {
            movBack = -transform.forward;
            //mov2 = transform.right;
            movBack = movBack.normalized * 5 * Time.deltaTime; //mov magnitud 1
            rigi.MovePosition(rigi.position + movBack);
            print("patras");

            //rotacion
            Quaternion rot2 = Quaternion.Euler(0, 180, 0 * Time.deltaTime);
            rigi.MoveRotation(rot2);
        }*/

        /* if (Input.GetAxisRaw("Horizontal") != 0.0f || Input.GetAxisRaw("Vertical") != 0.0f)
        {
            Vector3 dirV = transform.forward * Input.GetAxisRaw("Vertical");
            Vector3 dirH = transform.right * Input.GetAxisRaw("Horizontal");
            Quaternion q = Quaternion.Euler(angleVel * Time.deltaTime);

            rigi.MovePosition(dirV+transform.position);
            rigi.MoveRotation(rigi.rotation*q);
        }*/








    }




    void Update()
    {
        //multiplico el valor que le indico al float vMot por el eje Z y el tiempo
        /*transform.Translate(0, 0, Input.GetAxis("Vertical") * Time.deltaTime * vMov);

        //multiplico el valor que le indico al float vRot por el eje X y el tiempo
        transform.Translate(Input.GetAxisRaw("Horizontal") * Time.deltaTime * vRot, 0,0);
        transform.Rotate(0,Input.GetAxisRaw("Horizontal") * Time.deltaTime * 200, 0);*/



        /*Vector3 vector = new Vector3(Input.GetAxis("Horizontal"), .5f, Input.GetAxis("Vertical"));
        rigi.AddForce(vector * 150 * Time.deltaTime);
        print(vector);*/


    }


}
