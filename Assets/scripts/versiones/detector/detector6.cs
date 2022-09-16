using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detector6 : MonoBehaviour
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
    public bool cogido, paraCoger, objCaja, platoCaja, playerMesa;
    public static bool playerPlato,playerObj,playerObjPlato;

    /* cogido: cuando el obj/plato es hijo del detector
     * paraCoger: cuando el obj/plato se puede coger
     * 
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
        playerPlato = false;
        playerObj = false;
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
            //print(col);
        }

        //print("playerObj: " + playerObj);
        //print("playerMesa: " + playerMesa);
        //print("playerPlato: " + playerPlato);
        //print("playerObjPlato: " + playerObjPlato);

        //si el plato es hijo de detector con obj
        if (gameObject.transform.Find("plato") && gameObject.transform.Find("plato").transform.Find("obj"))
        {
            print("hijo plato con obj");
            playerObjPlato = true;
        }
        else
            playerObjPlato = false;
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
                        playerObj = true;

                    }
                }
            }
        }

        //sacar objetos de la caja Azul
        if (other.transform.tag == "cajaA")
        {
            string col = other.transform.name;

            if (Input.GetButtonDown("Submit") && !cogido)
            {
                if(!objetos.colCajasObj.Contains(col))
                {

                    //solo saca el objeto si no tiene ningun hijo mas, para que solo coja un obj a la vez y no instancie si lleva un plato
                    if (transform.childCount == 0)
                    {
                    pelota = Instantiate(obj2, pos.transform.position, Quaternion.identity) as GameObject;
                    pelota.name = "obj";
                    pelota.transform.SetParent(gameObject.transform);
                    pelota.GetComponent<Rigidbody>().useGravity = false;
                    cogido = true;
                    playerObj = true;

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

            if (Input.GetButtonDown("Submit") && !cogido)
            {
                if(!objetos.colCajasObj.Contains(col))
                {
                    //solo saca el objeto si no tiene ningun hijo mas, para que solo coja un obj a la vez y no instancie si lleva un plato
                    if (transform.childCount == 0)
                    {
                        //print("caja rojo");
                        pelota = Instantiate(obj3, pos.transform.position, Quaternion.identity) as GameObject;
                        pelota.name = "obj";
                        pelota.transform.SetParent(gameObject.transform);
                        pelota.GetComponent<Rigidbody>().useGravity = false;
                        cogido = true;
                        playerObj = true;

                    }
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
                playerObj = false;

            }

            //coger del suelo
            if (Input.GetButtonDown("Submit") && !cogido && paraCoger)
            {
                //solo coge el objeto si no tiene ningun hijo mas, para que solo coja un obj a la vez
                //y que no sea hijo de nada
                if (transform.childCount == 0)
                {

                    print("cogido");
                    other.transform.SetParent(gameObject.transform);
                    other.GetComponent<Rigidbody>().useGravity = false;
                    other.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                    //para que el objeto se quede a la distancia que yo quiero
                    other.transform.position = pos.transform.position;
                    //coge la rotacion del pj para que el obj siempre este recto
                    other.transform.rotation = Quaternion.Slerp(other.transform.rotation, gameObject.transform.rotation, Time.deltaTime * 50);
                    cogido = true;
                    playerObj = true;
                }

            }

            //soltar obj sin que colisione con mesa
            if (Input.GetButtonDown("Submit") && cogido && !paraCoger)
            {

                if (transform.childCount > 0 && !playerMesa)
                {

                    print("soltado");
                    other.transform.parent = null;
                    cogido = false;
                    other.GetComponent<Rigidbody>().isKinematic = false;
                    other.GetComponent<Rigidbody>().useGravity = true;
                    other.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                    other.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
                    playerObj = false;

                }
            }
        }

        //solo dejar un obj en la mesa
        if (other.transform.tag == "mesa")
        {
            playerMesa = true;
            string col = other.transform.name;
            //print("list mesa " + objetos.colCajasObj.Contains(col));
            //print(col);

            //para obj en mesa
            if (gameObject.transform.Find("obj"))
            {
                playerObj = true;
                //print("obj");
                if (Input.GetButtonDown("Submit") && cogido && !paraCoger && gameObject.transform.parent != null)
                {
                    //entra si la mesa no tiene nada encima
                    if (!objetos.colCajasObj.Contains(col))
                    {
                        print("soltado obj mesa");
                        other.transform.parent = null;
                        cogido = false;
                        playerObj = false;
                    }

                    //poder soltar en el plato cuando este en la mesa
                    /*else if(objetos.colCajasObj.Contains(col))
                    {
                        other.transform.parent = null;
                        print("soltado obj mesa a plato");
                        cogido = false;
                        playerObj = false;
                    }*/

                }
            }


            //para platos en mesa
            if (gameObject.transform.Find("plato"))
            {
                string col2 = other.transform.name;
                //print("col2: "+col2);

                if (Input.GetButtonDown("Submit") && cogido && !paraCoger && gameObject.transform.parent != null)
                {
                    playerMesa = true;
                    if (!objetos.colCajasObj.Contains(col2))//entra al tener un plato cogido y soltarlo en la mesa
                    {
                        if (transform.childCount > 0)
                        {
                            print("plato en mesa");
                            //print("soltado plato mesa");
                            gameObject.transform.Find("plato").parent = null;
                            cogido = false;
                            playerPlato = false;
                        }
                    }

                }
            }

        }
        




        //---------------------------------------PLATOS--------------------------------------------

        if (other.transform.tag == "plato")
        {

            //para que suelte el plato, si hay varios en el trigger
            //y fisicas al coger y soltar
            if (!cogido)
            {
                //other.transform.parent = null;
                other.GetComponent<Rigidbody>().isKinematic = false;
                other.GetComponent<Rigidbody>().useGravity = true;
                other.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                other.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
                playerPlato = false;

            }
            else
            {
                //other.transform.SetParent(gameObject.transform);
                other.GetComponent<Rigidbody>().isKinematic = true;
                other.GetComponent<Rigidbody>().useGravity = false;
                other.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                other.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
            }



            if (playerMesa)//si trg player+mesa
            {

            }

            //coger plato y plato con obj
            if ((Input.GetButtonDown("Submit") && !cogido && paraCoger) || other.transform.parent != null)
            {
                print("cogido plato");
                other.transform.SetParent(gameObject.transform);
                other.GetComponent<Rigidbody>().isKinematic = true;
                other.GetComponent<Rigidbody>().useGravity = false;
                other.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                //para que el objeto se quede a la distancia que yo quiero
                other.transform.position = pos.transform.position;
                //coge la rotacion del pj para que el plato siempre este recto
                other.transform.rotation = Quaternion.Slerp(other.transform.rotation, gameObject.transform.rotation, Time.deltaTime * 50);
                cogido = true;
                playerPlato = true;

            }
            

            //soltar plato si no es una mesa
            if (Input.GetButtonDown("Submit") && cogido && !paraCoger && playerPlato)
            {
                 //string col = other.transform.name;
                 //print(col);
                 //if (!objetos.colCajasObj.Contains(col))
                 //{
                     if (transform.childCount > 0 && !playerMesa)//solo un obj cogido, soltar si no es una mesa
                    {
                         print("soltado plato");
                         other.transform.parent = null;
                         cogido = false;
                         other.GetComponent<Rigidbody>().isKinematic = false;
                         other.GetComponent<Rigidbody>().useGravity = true;
                         other.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                         other.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
                     }
                 //}
               
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
        if (Input.GetButtonDown("Submit") && (other.transform.tag=="cajaA" || other.transform.tag == "cajaV" || other.transform.tag == "cajaR" || other.transform.tag == "mesa") && transform.Find("plato"))
        {
            //print("caja+plato+player");
            platoCaja = true;
            cogido = true;

        }

        //dejar obj encima de las cajas y que no instancie el obj, y poder cogerlo
        //si el obj es hijo del player y trigg con cajas
        if (Input.GetButtonDown("Submit") && (other.transform.tag == "cajaA" || other.transform.tag == "cajaV" || other.transform.tag == "cajaR") && transform.Find("obj"))
        {
            print("caja+obj+player");
            cogido = true;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if(other.transform.tag=="cajaA")
        {
            platoCaja = false;

        }

        if (other.transform.tag == "cajaV")
        {
            platoCaja = false;

        }
        if (other.transform.tag == "cajaR")
        {
            platoCaja = false;

        }
        if (other.transform.tag == "mesa")
        {
            playerMesa= false;

        }
    }

}
