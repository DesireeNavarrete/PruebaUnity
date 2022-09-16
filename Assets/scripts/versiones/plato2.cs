using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plato2 : MonoBehaviour
{
    /*---------------------------AÑADIR/ARREGLAR-------------------------------------
     *poder dejar el obj en el plato
     *      no hijo, coger la pos como al dejar el obj en la mesa
     *      si hijo, que se quede en medio del plato
     *      
     *poder coger el plato con el obj encima
     *      el obj hijo del plato
     *      el plato hijo del player?
     *      
     *  
     *      
     */
    //float vel = 8;
    public List<string> colCajasPlat = new List<string>();

    void Start()
    {
        gameObject.GetComponent<Rigidbody>().useGravity = false;
        gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        gameObject.GetComponent<Rigidbody>().isKinematic = true;


    }

    void Update()
    {
        if (gameObject.transform.parent != null)
        {
            gameObject.GetComponent<Rigidbody>().useGravity = true;

        }
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
        //si esta en el detector y el obj es su hijo
        if (other.transform.tag == "detector" && gameObject.transform.Find("obj"))
        {
            print("player trig com plato+obj");
            gameObject.GetComponent<Rigidbody>().isKinematic = false;
            gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;

        }

        //cuando se deja aun obj en el plato, que se quede en medio del plato
        if (other.transform.tag == "objetos" && other.transform.parent == null)
        {
            //print("platotrigg");
            other.GetComponent<Rigidbody>().useGravity = true;
            other.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        }

        //cuando se deja aun obj en el plato
        if (other.transform.tag == "objetos" && other.transform.parent != null)
        {
            //print("platotrigg");
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
        }

               
    }

    private void OnCollisionEnter(Collision col)
    {
        //cuando se deja el plato en una mesa
        if (col.transform.tag == "mesa" && gameObject.transform.parent == null)
        {
            //print("mesa+plato");
            gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        }


        //cuando se deja aun obj en el plato, se hace hijo
        if (col.transform.tag == "objetos" && gameObject.transform.parent == null)
        {
            print("plato col enter");
            //col.transform.parent = null;
            //col.transform.SetParent(gameObject.transform);
            //col.transform.position = gameObject.transform.position;
            gameObject.GetComponent<Rigidbody>().useGravity = false;


        }

        //saber que caja/mesa tiene plato encima
        if (col.transform.tag == "cajaV" || col.transform.tag == "cajaA" || col.transform.tag == "cajaR" || col.transform.tag == "mesa")
        {

            objetos.colCajasObj.Add(col.transform.name);

        }
    }

    private void OnCollisionStay(Collision col)
    {

        //cuando se deja aun obj en el plato, se hace hijo
        if (col.transform.tag == "objetos" && gameObject.transform.parent == null)
        {
            print("plato col stay");
            //col.transform.parent = null;
            col.transform.SetParent(gameObject.transform);


        }
    }

    private void OnCollisionExit(Collision col)
    {
        //saber que caja/mesa tiene plato encima
        if (col.transform.tag == "cajaV" || col.transform.tag == "cajaA" || col.transform.tag == "cajaR" || col.transform.tag == "mesa")
        {

            objetos.colCajasObj.Remove(col.transform.name);

        }
        
       
    }
}
