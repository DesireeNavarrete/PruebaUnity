using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objetos : MonoBehaviour
{
    /*---------------------------AÑADIR/ARREGLAR-------------------------------------
     *      
     */
    
    
    [SerializeField]

    public static bool cajaYObj;//trig de cajas con el obj
    public static bool playerYObj;//trig player con obj
    public static bool mesaOCajaYObj;//col de mesa/caja con obj
    public static bool objHijo;//si el obj es hijo
    public static bool colPlato;
    //public string cajaCol;
    public static List<string> colCajasObj=new List<string>();
    public static List<string> colObjPlato=new List<string>();

    GameObject plati;

    void Start()
    {
        gameObject.GetComponent<Rigidbody>().useGravity = false;
        gameObject.GetComponent<Rigidbody>().constraints= RigidbodyConstraints.FreezeAll;
        //gameObject.GetComponent<Rigidbody>().constraints= RigidbodyConstraints.FreezeRotation;
        gameObject.GetComponent<Rigidbody>().isKinematic = true;
        cajaYObj = false;
        mesaOCajaYObj = false;
        objHijo = false;
        colPlato = false;
        plati = GameObject.FindGameObjectWithTag("plato");

    }

    private void Update()
    {
        
        
        if (colPlato && plato.playerPlato)
        {
            //posEnCentro(gameObject.transform, plati.transform, plati.transform.position.y / 2);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "detector")
        {
            playerYObj = true;

        }

        //saber que caja tiene obj encima
        /*if (other.transform.tag == "cajaV" || other.transform.tag == "cajaA" || other.transform.tag == "cajaR" || other.transform.tag == "mesa")
        {

            cajaYObj = true;
            colCajasObj.Add(other.transform.name);

        }*/

   
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

        if (other.transform.tag == "plato")
        {
           //gameObject.GetComponent<Rigidbody>().isKinematic = fa;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        /*if (other.transform.tag == "cajaV" || other.transform.tag == "cajaA" || other.transform.tag == "cajaR" || other.transform.tag == "mesa")
        {

            colCajasObj.Remove(other.transform.name);
            cajaYObj = false;

        }

        if (other.transform.tag == "detector")
        {
            playerYObj = false;
            colCajasObj.Remove(other.transform.name);
        }*/

        //si un boj colisiona con una caja, q no instancie
        if (other.transform.tag == "cajaV" || other.transform.tag == "cajaA" || other.transform.tag == "cajaR" || other.transform.tag == "mesa")
        {
            cajaYObj = false;
        }

    }

    private void OnCollisionEnter(Collision col)
    {
        //cuando se deja aun obj en una mesa, que se quede en medio de la mesa
        if (col.transform.tag == "mesa" && gameObject.transform.parent == null)
        {
            //print("mesa+obj");
            //plato.posEnCentro(gameObject.transform,col.transform, col.transform.localScale.y / 2);
        }

        
        //solo se puede dejar un obj en la mesa/caja
        if ((col.transform.tag == "cajaV" || col.transform.tag == "cajaA" || col.transform.tag == "cajaR" || col.transform.tag == "mesa"))
        {

            mesaOCajaYObj = true;
            colCajasObj.Add(col.transform.name);
            plato.posEnCentro(gameObject.transform, col.transform, col.transform.localScale.y / 2);


        }
        if (col.transform.tag == "plato")
        {
            colObjPlato.Add(col.transform.name);
            gameObject.GetComponent<Rigidbody>().useGravity = false;
            gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        }
    }

    private void OnCollisionStay(Collision col)
    {
        if (col.transform.tag == "plato" )
        {
            gameObject.GetComponent<Rigidbody>().useGravity = false;
            gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            colPlato = true;
            
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

        if (col.transform.tag == "plato")
        {

            colPlato = false;
        }

    }




}
