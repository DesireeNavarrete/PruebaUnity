using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plato : MonoBehaviour
{
    /*---------------------------AÑADIR/ARREGLAR-------------------------------------     
     *poder coger el plato con el obj encima
     *      el obj hijo del plato
     *      el plato hijo del player
     *      
     *      al cogerlo, solo coge el plato
     *      
     */

    public static List<string> colPlatos = new List<string>();
    public bool platoMesa,spawnPlato;
    public static bool playerPlato;
    public bool platoObj;

    void Start()
    {
        //gameObject.GetComponent<Rigidbody>().useGravity = true;
        //gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
        //gameObject.GetComponent<Rigidbody>().isKinematic = false;

        //posObj = GameObject.FindGameObjectWithTag("posObj");

        spawnPlato = false;
    }

    void Update()
    {
        //print("platoObj: " + platoObj);

        //print(gameObject.transform.Find("obj"));

     

    }

    private void OnTriggerEnter(Collider other)
    {
        //saber que caja/mesa tiene plato encima
        if (other.transform.tag == "cajaV" || other.transform.tag == "cajaA" || other.transform.tag == "cajaR" || other.transform.tag == "mesa")
        {

            objetos.colCajasObj.Add(other.transform.name);

        }

       
    }

    private void OnTriggerStay(Collider other)
    {

        if (other.transform.tag == "detector")
        {
            playerPlato = true;
        }

        //cuando se deja aun obj en el plato
        if (other.transform.tag == "objetos" && other.transform.parent == null)
        {
            print("platotrigg");
            other.GetComponent<Rigidbody>().useGravity = true;
            other.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            
        }
    


    }

    private void OnTriggerExit(Collider other)
    {
        //saber que caja/mesa tiene plato encima
        if (other.transform.tag == "cajaV" || other.transform.tag == "cajaA" || other.transform.tag == "cajaR" || other.transform.tag == "mesa")
        {

            objetos.colCajasObj.Remove(other.transform.name);

        }

        if (other.transform.tag == "detector")
        {
            objetos.colCajasObj.Remove(other.transform.name);
            playerPlato = false;
        }

        if (other.transform.tag == "objetos")
        {
            colPlatos.Remove(other.transform.name);

        }
    }

    private void OnCollisionEnter(Collision col)
    {

        if (col.transform.tag == "objetos" && playerPlato)
        {
            //posEnCentro(col.transform, gameObject.transform, col.transform.localScale.y/2);
            //print("pos");
            platoObj = true;
        }

        //cuando se deja el plato en una mesa
        //cuando el plato col con la mesa, pone al plato en medio
        if (col.transform.tag == "mesa" && gameObject.transform.parent == null)
        {
            //print("mesa+plato");
            gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            //posEnCentro(gameObject.transform,col.transform);
            //posEnCentro(gameObject.transform, col.transform, gameObject.transform.localScale.y);
            platoMesa = true;

        }



        //cuando se deja aun obj en el plato
        if (col.transform.tag == "objetos" && gameObject.transform.parent == null)
        {
            //print("plato col enter");
            gameObject.GetComponent<Rigidbody>().useGravity = false;

            
        }

        //saber que caja/mesa tiene plato encima
        if (col.transform.tag == "cajaV" || col.transform.tag == "cajaA" || col.transform.tag == "cajaR" || col.transform.tag == "mesa")
        {
            //print("plato col enter");
            objetos.colCajasObj.Add(col.transform.name);
            posEnCentro(gameObject.transform, col.transform, gameObject.transform.localScale.y);

        }

        if (col.transform.tag == "objetos")
        {
            colPlatos.Add(col.transform.name);

        }

        if (col.transform.tag == "spawnPlatos")
        {
            //print("spawn plato");
            spawnPlato = true;

        }

        if (col.transform.tag == "plato" && spawnPlato)
        {
            print("col plato+plato");
            posEnCentro(col.transform, gameObject.transform, col.transform.localScale.y);

        }

    }

    private void OnCollisionStay(Collision col)
    {

        //cuando se deja aun obj en el plato, se hace hijo
        if (col.transform.tag == "objetos" && gameObject.transform.parent == null)
        {
            //print("plato col stay");
            //posEnCentro(col.transform, gameObject.transform, col.transform.localScale.y / 2);
            /*if (platoObj)
            {
                print("ya hay obj");
                posEnCentro(col.transform, gameObject.transform, col.transform.localScale.y / 2);

            }*/
        }



        //cuando el obj col con el plato, pone al obj en medio
        if (col.transform.tag == "objetos")//va bien para no soltar el plato habiendo obj en la mesa
        {
            posEnCentro(col.transform, gameObject.transform, col.transform.localScale.y/2);
            //print("pos");
            
        }

        if(col.transform.tag == "objetos" && detector.playerPlato)
        {
            posEnCentro(col.transform, gameObject.transform, col.transform.localScale.y / 2);

        }


    }

    private void OnCollisionExit(Collision col)
    {
        //saber que caja/mesa tiene plato encima
        if (col.transform.tag == "cajaV" || col.transform.tag == "cajaA" || col.transform.tag == "cajaR" || col.transform.tag == "mesa")
        {
            //print("plato col exit");
            objetos.colCajasObj.Remove(col.transform.name);

        }

        if (col.transform.tag == "mesa")
        {
            platoMesa = false;
        }

       
        if (col.transform.tag == "objetos")
        {
            platoObj = false;
        }

        if (col.transform.tag == "objetos")
        {
            colPlatos.Remove(col.transform.name);

        }

        if (col.transform.tag == "spawnPlatos")
        {
            print("spawn plato");
            spawnPlato = false;

        }

    }

    //le pasamamos el obj que se tiene q posicionar, la colision y la escala para que no lo atraviese
    public static void posEnCentro(Transform objtillo, Transform col, float scale)
    {
        //pos usando el obj vacio
        //objtillo.position = gameObject.transform.Find("posObj").position;
        //print(gameObject.GetComponentInChildren<Transform>());

        //probar cogiendo los ejes del plato
        objtillo.position = new Vector3(col.transform.position.x, col.transform.position.y, col.transform.position.z);

    }


}
