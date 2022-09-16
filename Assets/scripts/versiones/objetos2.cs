using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objetos2 : MonoBehaviour
{
    /*---------------------------AÑADIR/ARREGLAR-------------------------------------
     *  si el padre es el plato y colisiona con el player + boton, hijo del plato
     *      
     */
    
    
    [SerializeField]
    public static bool cajaYObj;
    public static bool playerYObj;
    public static bool mesaOCajaYObj;
    //public string cajaCol;
    public static List<string> colCajasObj=new List<string>();

    void Start()
    {
        gameObject.GetComponent<Rigidbody>().useGravity = false;
        gameObject.GetComponent<Rigidbody>().constraints= RigidbodyConstraints.FreezeAll;
        //gameObject.GetComponent<Rigidbody>().constraints= RigidbodyConstraints.FreezeRotation;
        gameObject.GetComponent<Rigidbody>().isKinematic = true;
        cajaYObj = false;
        mesaOCajaYObj = false;


    }

    private void Update()
    {
        //si es hijo
        if(gameObject.transform.parent != null)
        {
            //print("hijo");
            gameObject.GetComponent<Rigidbody>().useGravity = false;
            gameObject.GetComponent<Rigidbody>().constraints= RigidbodyConstraints.FreezeAll;

        }



    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "detector")
        {
            playerYObj = true;

        }

        //saber que caja tiene obj encima
        if (other.transform.tag == "cajaV" || other.transform.tag == "cajaA" || other.transform.tag == "cajaR" || other.transform.tag == "mesa")
        {

            cajaYObj = true;
            colCajasObj.Add(other.transform.name);

        }

   
    }

    private void OnTriggerStay(Collider other)
    {
        //si un boj colisiona con una caja, q no instancie
        if(other.transform.tag == "cajaV" || other.transform.tag == "cajaA" || other.transform.tag == "cajaR" || other.transform.tag == "mesa")
        {
            cajaYObj = true;
        }

        if (other.transform.tag == "detector")
        {
            playerYObj = true;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "cajaV" || other.transform.tag == "cajaA" || other.transform.tag == "cajaR" || other.transform.tag == "mesa")
        {

            colCajasObj.Remove(other.transform.name);
            cajaYObj = false;

        }

        if (other.transform.tag == "detector")
        {
            playerYObj = false;
            colCajasObj.Remove(other.transform.name);
        }

       

    }

    private void OnCollisionEnter(Collision col)
    {
        //cuando se deja aun obj en una mesa, que se quede en medio de la mesa
        if (col.transform.tag == "mesa" && gameObject.transform.parent == null)
        {
            //print("mesa+obj");
            gameObject.transform.position = col.transform.position;
        }

        
        //solo se puede dejar un obj en la mesa/caja
        if ((col.transform.tag == "cajaV" || col.transform.tag == "cajaA" || col.transform.tag == "cajaR" || col.transform.tag == "mesa"))
        {

            mesaOCajaYObj = true;
            colCajasObj.Add(col.transform.name);

        }

        
    }

    private void OnCollisionStay(Collision col)
    {
        if (col.transform.tag == "plato" )
            //&& col.transform.Find("obj"))
        {
            gameObject.GetComponent<Rigidbody>().useGravity = false;
            gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;

        }
    }

    private void OnCollisionExit(Collision col)
    {
        //solo se puede dejar un obj en la mesa/caja
        if ((col.transform.tag == "cajaV" || col.transform.tag == "cajaA" || col.transform.tag == "cajaR" || col.transform.tag == "mesa"))
        {

            mesaOCajaYObj = false;
            colCajasObj.Remove(col.transform.name);

        }
    }



 
}
