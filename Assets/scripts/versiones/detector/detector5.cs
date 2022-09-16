using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detector5 : MonoBehaviour
{
/*---------------------------AÑADIR/ARREGLAR-------------------------------------  
 *    coger plato cuando tendo obj como hijo
 *          se quita el hijo del plato, al hacer al plato hijo del player
 *  
 * 
 * 
 */
    public GameObject obj1, obj2, obj3, pos;
    GameObject[] caja;
    //public GameObject[] objs;
    GameObject pj, pelota;
    public bool cogido,paraCoger,objCaja,platoCaja;
    /* cogido: cuando el obj/plato es hijo del detector
     * paraCoger: cuando el obj/plato se puede coger
     * platoCaja: true cuando el player lleva un plato y abre una caja. Para que un plato se pueda dejar/soltar encima de una caja, pero no instancie obj
     * objCaja: es true cuando se va a sacar el obj de la caja. Para que si el player lleva un obj no se instancien mas al ir a la caja.
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
        objCaja = false;
        //objetos.colCajasObj.Add("hi");



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

        //printea la lista de colision de objetos
        foreach (string col in objetos.colCajasObj)
        {
            print(col);
        }


    }

    private void OnTriggerStay(Collider other)
    {

        
        //sacar objetos de la caja Verde
        if (other.transform.tag == "cajaV")
        {
                string col = other.transform.name;
                //print("list name " + objetos.colCajasObj.Contains(col));

            if (Input.GetButtonDown("Submit") && !cogido)
            {
                    //print("FALSE CAJA VERDE");
                if(!objetos.colCajasObj.Contains(col))
                {
                    //solo saca el objeto si no tiene ningun hijo mas, para que solo coja un obj a la vez y no instancie si lleva un plato
                    if(transform.childCount == 0)
                    {
                        //print("caja verde");
                        pelota = Instantiate(obj1, pos.transform.position, Quaternion.identity) as GameObject;
                        pelota.name = "obj";
                        pelota.transform.SetParent(gameObject.transform);
                        pelota.GetComponent<Rigidbody>().useGravity = false;
                        cogido = true;
                        //cajas = true;
                    }
                }
            }
        }

        //sacar objetos de la caja Azul
        if (other.transform.tag == "cajaA")
        {
            string col = other.transform.name;
            //print("list nameA " + objetos.colCajasObj.Contains(col));


            if (Input.GetButtonDown("Submit") && !cogido)
            //if (Input.GetButtonDown("Submit") && !cogido && !objetos.cajaYObj && !objetos.playerYObj)
            {
                    //print("FALSE CAJA azul");
                if(!objetos.colCajasObj.Contains(col))
                {

                    //solo saca el objeto si no tiene ningun hijo mas, para que solo coja un obj a la vez y no instancie si lleva un plato
                    if (transform.childCount == 0)
                    {
                    //print("caja azul");
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
        }

        //sacar objetos de la caja Roja
        if (other.transform.tag == "cajaR")
        {

            string col = other.transform.name;
            //print("list name " + objetos.colCajasObj.Contains(col));


            if (Input.GetButtonDown("Submit") && !cogido)
            //if (Input.GetButtonDown("Submit") && !cogido && !objetos.cajaYObj && !objetos.playerYObj)
            {
                //print("FALSE CAJA azul");
                if(!objetos.colCajasObj.Contains(col))
                {

                    //solo saca el objeto si no tiene ningun hijo mas, para que solo coja un obj a la vez y no instancie si lleva un plato
                    //if (transform.childCount == 0)
                    //{
                    print("caja rojo");
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


            //para que suelte el obj, si hay varios en el trigger
            if (!cogido)
            {
                other.transform.parent = null;
                other.GetComponent<Rigidbody>().useGravity = true;
                other.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                other.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;

            }

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
                    //coge la rotacion del pj para que el obj siempre este recto
                    other.transform.rotation = Quaternion.Slerp(other.transform.rotation, gameObject.transform.rotation, Time.deltaTime * 50);
                    cogido = true;
                }
                
            }

            //soltar obj
            if(Input.GetButtonDown("Submit") && cogido && !paraCoger)
            {
           
                if (transform.childCount > 0 && !objetos.mesaOCajaYObj)
                {

                    print("soltado");
                    other.transform.parent = null;
                    cogido = false;
                    other.GetComponent<Rigidbody>().isKinematic = false;
                    other.GetComponent<Rigidbody>().useGravity = true;
                    other.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                    other.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
                    
                }
            }
            
        }

        




        //---------------------------------------PLATOS--------------------------------------------

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
            cogido = true;

        }

        //dejar obj encima de las cajas y que no instancie el obj, y poder cogerlo
        if (Input.GetButtonDown("Submit") && (other.transform.tag == "cajaA" || other.transform.tag == "cajaV" || other.transform.tag == "cajaR") && transform.Find("obj"))
        {
            print("caja+obj+player");
            //transform.parent = null;
            //plato = false;
            cogido = true;
            //objCaja = true;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if(other.transform.tag=="cajaA")
        {
            //plato = true;
            //cajas = false;
            platoCaja = false;
            objCaja = false;

        }

        if (other.transform.tag == "cajaV")
        {
            //plato = true;
            //cajas = false;
            platoCaja = false;
            objCaja = false;

        }

        if (other.transform.tag == "cajaR")
        {
            //plato = true;
            //cajas = false;
            platoCaja = false;
            objCaja = false;

        }

    }

}
