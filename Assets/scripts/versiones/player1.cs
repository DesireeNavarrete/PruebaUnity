using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player1 : MonoBehaviour
{
    public static Rigidbody rigi;
    //Vector3 angle, movDer, movIzq, movFor, movBack;
    float hor,ver;
    //bool rotado;
    //float rotasion=0;
    float vel = 8;

    void Start()
    {
        rigi = this.GetComponent<Rigidbody>();
        hor = Input.GetAxisRaw("Horizontal");
        ver = Input.GetAxisRaw("Vertical");
        //angle = new Vector3(0, 90, 0);
    }

    private void FixedUpdate()
    {

        //MOVIMIENTO
        Vector3 mov = new Vector3(hor * vel, rigi.velocity.y, ver * vel);
        rigi.velocity = mov;

        if (hor != 0 || ver != 0)
        {
            Quaternion rot = Quaternion.LookRotation(new Vector3(mov.x, 0, mov.z));
            rot = rot.normalized;
            transform.rotation = Quaternion.Slerp(transform.rotation, rot, vel * Time.deltaTime);
        }

        //MOV EN HORIZONTAL
        /*Vector3 v = rigi.velocity;
        v.x = Input.GetAxisRaw("Horizontal") * 5;
        rigi.velocity = v;

        if (Input.GetAxisRaw("Horizontal") > 0f)//izq
        {
            transform.LookAt(d);
            print("d");
        }

        if (Input.GetAxisRaw("Horizontal") < 0f)//der
        {
            transform.LookAt(a);
            print("a");
        }


        //MOV EN VERTICAL
        Vector3 v2 = rigi.velocity;
        v2.z = Input.GetAxisRaw("Vertical") * 5;
        rigi.velocity = v2;

        if (Input.GetAxisRaw("Vertical") > 0f)//arriba
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
        }
        
    }

    void Update()
    {
     

    }

    private void OnTriggerStay(Collider other)
    {
        
    }

    public static void quieto()
    {
        //print("quieto");
    }*/
    }
}
