using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detector3 : MonoBehaviour
{
/*---------------------------AÑADIR/ARREGLAR-------------------------------------
 *    soltar 1 cuando hay 3 objs en el trigg
 *    
 *    coger plato cuando tendo obj como hijo
 *          se quita el hijo del plato, al hacer al plato hijo del player
 *  
 *     con un obj cogido, q no instncie otro    
 *          
 * 
 * 
 * 
 */
    public GameObject obj1, obj2, obj3, pos;
    GameObject[] caja;
    //public GameObject[] objs;
    GameObject pj, pelota;
    public bool cogido,paraCoger,cajas,platoCaja;
    /* cogido: cuando el obj/plato es hijo del detector
     * paraCoger: cuando el obj/plato se puede coger
     * plato: true cuando el player lleva un plato y va a una caja. Para que un plato se pueda dejar encima de una caja, y no instancie obj
     * cajas: es true cuando se va a sacar el obj de la caja. Para que si el player lleva un obj no se instancien mas al ir a la caja.
     */
    Rigidbody rigiObj;

    private void Awake()
    {

        //pelota = Instantiate(obj1, sp.transform.position, Quaternion.identity) as GameObject;
        //rigiObj = pelota.GetComponent<Rigidbody>();
        //rigiObj.useGravity = false;
    }

    void Start()
    {
        caja = GameObject.FindGameObjectsWithTag("caja");
        pj = GameObject.FindGameObjectWithTag("Player");
        paraCoger = true;
        cogido = false;
        platoCaja = false;


    }

    void Update()
    {
        if (cogido)
        {
            paraCoger = false;
        }
        if (!cogido && !paraCoger)
        {
            paraCoger = true;
        }


    }

    private void OnTriggerStay(Collider other)
    {
        //sacar objetos de la caja Verde
        if (other.transform.tag == "cajaV")
        {
            if (Input.GetButtonDown("Submit") && !cogido)
            {

                //solo saca el objeto si no tiene ningun hijo mas, para que solo coja un obj a la vez y no instancie si lleva un plato
                if (transform.childCount == 0)
                {
                    pelota = Instantiate(obj1, pos.transform.position, Quaternion.identity) as GameObject;
                    pelota.name = "obj";
                    pelota.transform.SetParent(gameObject.transform);
                    pelota.GetComponent<Rigidbody>().useGravity = false;
                    cogido = true;
                    //cajas = true;
                }
            }
        }

        //sacar objetos de la caja Azul
        if (other.transform.tag == "cajaA")
        {


            if (Input.GetButtonDown("Submit") && !cogido && !platoCaja)
            {
                //solo saca el objeto si no tiene ningun hijo mas, para que solo coja un obj a la vez y no instancie si lleva un plato
                if (transform.childCount == 0)
                {
                    print("caja azul");
                    pelota = Instantiate(obj2, pos.transform.position, Quaternion.identity) as GameObject;
                    pelota.name = "obj";
                    pelota.transform.SetParent(gameObject.transform);
                    pelota.GetComponent<Rigidbody>().useGravity = false;
                    cogido = true;
                    //cajas = true;

                }

                //cuando el player tenga un plato y lo vaya a dejar en una caja
                /*if (plato)
                {
                    //no instanciar
                }*/
            }
        }

        //sacar objetos de la caja Roja
        if (other.transform.tag == "cajaR")
        {
            if (Input.GetButtonDown("Submit") && !cogido)
            {

                //solo saca el objeto si no tiene ningun hijo mas, para que solo coja un obj a la vez y no instancie si lleva un plato
                if (transform.childCount == 0)
                {
                    pelota = Instantiate(obj3, pos.transform.position, Quaternion.identity) as GameObject;
                    pelota.name = "obj";
                    pelota.transform.SetParent(gameObject.transform);
                    pelota.GetComponent<Rigidbody>().useGravity = false;
                    cogido = true;
                    //cajas = true;

                }
            }
        }

        

        //coger los objetos del suelo
        if (other.transform.tag == "objetos")
        {

            other.GetComponent<Rigidbody>().isKinematic = false;

            

            //coger del suelo
            if (Input.GetButtonDown("Submit") && !cogido && paraCoger)
            {
                //solo coge el objeto si no tiene ningun hijo mas, para que solo coja un obj a la vez
                if (transform.childCount == 0)
                {

                    print("cogido");
                    other.transform.SetParent(gameObject.transform);
                    other.GetComponent<Rigidbody>().useGravity = false;
                    other.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                    //para que el objeto se quede a la distancia que yo quiero
                    //other.transform.Translate(0, 0.5f, .2f);
                    other.transform.position = pos.transform.position;
                    cogido = true;
                }
                
            }

            //soltar
            if (Input.GetButtonDown("Submit") && cogido && !paraCoger )
            {
                if (transform.childCount > 0)
                {
                    print("soltado");
                    other.transform.parent = null;
                    cogido = false;
                    other.GetComponent<Rigidbody>().isKinematic = false;
                    other.GetComponent<Rigidbody>().useGravity = true;
                    other.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                    other.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;

                    //al soltar, instanciar otro en la caja, con posicion freezeada
                    //si se instancia al soltarlo, cada vez q se suelte uno, se instanciaran muchos
                    //pelota = Instantiate(obj1, sp.transform.position, Quaternion.identity) as GameObject;
                }

            }
            
        }


        

        //PLATOS

        if (other.transform.tag == "plato")
        {
            //plato = true;
            //other.GetComponent<Rigidbody>().isKinematic = false;

            //coger plato
            if (Input.GetButtonDown("Submit") && cogido == false && paraCoger)
            {
                print("cogido plato");
                other.transform.SetParent(gameObject.transform);
                other.GetComponent<Rigidbody>().isKinematic = true;
                other.GetComponent<Rigidbody>().useGravity = false;
                other.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                //para que el objeto se quede a la distancia que yo quiero
                other.transform.position = pos.transform.position;
                //coge la rotacion del pj para que el plato siempre este recto
                other.transform.rotation = Quaternion.Slerp(other.transform.rotation, gameObject.transform.rotation,Time.deltaTime*50);
                cogido = true;
                //plato = true;
                
            }

            

            //soltar plato
            if (Input.GetButtonDown("Submit") && cogido && !paraCoger)
            {
                if (transform.childCount > 0)//solo un obj cogido
                {
                    print("soltado plato");
                    other.transform.parent = null;
                    cogido = false;
                    other.GetComponent<Rigidbody>().isKinematic = false;
                    other.GetComponent<Rigidbody>().useGravity = true;
                    other.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                    other.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
                }
                
            }


            //coger plato con obj


            //soltar plato con obj
        }

        //si colisiona con un plato con obj, coge el plato con el obj
        /*if (other.transform.tag == "plato" && other.transform.Find("obj1"))
        {
            print("plato con obj");
            other.transform.SetParent(gameObject.transform);
        }*/


        //dejar plato encima de las cajas y que no instancie el obj, y poder cogerlo
        if (Input.GetButtonDown("Submit") && (other.transform.tag=="cajaA" || other.transform.tag == "cajaV" || other.transform.tag == "cajaR") && transform.Find("plato"))
        {
            print("caja+plato+player");
            //transform.parent = null;
            //plato = false;
            //transform.Find("plato").parent = null;
            platoCaja = true;
        }
            //platoCaja = false;

    }

    private void OnTriggerExit(Collider other)
    {
        if(other.transform.tag=="cajaA")
        {
            //plato = true;
            //cajas = false;
            platoCaja = false;

        }

        if (other.transform.tag == "cajaV")
        {
            //plato = true;
            //cajas = false;
            platoCaja = false;

        }

        if (other.transform.tag == "cajaR")
        {
            //plato = true;
            //cajas = false;
            platoCaja = false;

        }

    }

}
