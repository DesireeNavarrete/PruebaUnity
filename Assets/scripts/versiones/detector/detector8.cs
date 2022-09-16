using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class detector8 : MonoBehaviour
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

    GameObject pj, pelota;
    public bool  paraCoger, playerMesa, entregaTrg;
    public static bool playerPlato, playerObj, colBasura, cogido;

    public static List<string> objsPlayer = new List<string>();
    public static  List<string> platosPlayer = new List<string>();


    /* cogido: cuando el obj/plato es hijo del detector
     * paraCoger: cuando el obj/plato se puede coger
     * 
     * platoCaja: true cuando el player lleva un plato y abre una caja. 
     * Para que un plato se pueda dejar/soltar encima de una caja, pero no instancie obj
     * 
     * playerMesa: 
     */
    Rigidbody rigiObj;

    int nV = 1;
    int nR = 1;
    int nA = 1;
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
        //platoCaja = false;
        playerPlato = false;
        playerObj = false;
        colBasura = false;
        //objetos.colCajasObj.Add("hi");



    }

    void Update()
    {

        if (Input.GetButtonDown("Acction")){//boton de accion, mezclar por ejemplo
            print("y");
        }

        //print(Input.GetButtonDown("Submit"));
            if (cogido)
        {
            paraCoger = false;
            //print("child: "+gameObject.transform.childCount);
        }
        if (!cogido && !paraCoger)
        {
            paraCoger = true;
        }

        //printea la lista de colision de objetos
        foreach (string col in objetos.colObjPlato)
        //foreach (string col in objsPlayer)
        {
            //print(col);
        }

        //print("playerObj: " + playerObj);
        //print("playerMesa: " + playerMesa);
        //print("playerPlato: " + playerPlato);
        //print("playerObjPlato: " + playerObjPlato);

        //si el plato es hijo de detector con obj
        /* if (gameObject.transform.Find("plato") && gameObject.transform.Find("plato").transform.Find("obj"))
         {
             print("hijo plato con obj");
             playerObjPlato = true;
         }
         else
             playerObjPlato = false;
         */


        if (gameObject.transform.parent == null) {
            cogido = false;
        }


        //trigg con plato y objA
        /* if (objsPlayer.Contains("plato") && objsPlayer.Contains("objA"))
         {
             //print("plato y obj");
         }*/



    }



    private void OnTriggerEnter(Collider other)
    {
        //lista de trig de los objetos con el player
        if (other.transform.tag == "objetos")
        {
            //si no esta en la lista           
            if (!objsPlayer.Contains(other.name))
            {

                objsPlayer.Add(other.transform.name);
            }
        }


        if (other.transform.tag == "plato")
        {//si no esta en la lista           
            if (!platosPlayer.Contains(other.name))
            {
                platosPlayer.Add(other.transform.name);
            }
        }
    }


    private void OnTriggerStay(Collider other)
    {


        //NO DEJAR NADA ENCMA DE LAS CAJA
        /*if(other.transform.tag == "cajaV" && gameObject.transform.childCount == 1)
        {
            print("CAJTA");
            cogido = true;

        }*/

        //sacar objetos de la caja Verde
        if (other.transform.tag == "cajaAma")
        {
            string col = other.transform.name;
          
            //ntancia sn nada cogdo
            if (Input.GetButtonDown("Submit") && !cogido && gameObject.transform.childCount == 0)
            {

                //solo un obj encima de la caja
                //if (!objetos.colCajasObj.Contains(col) && objsPlayer.Count==0)
               // {
                    //if (gameObject.transform.childCount == 0)
                    //solo saca el objeto si no tiene ningun hijo mas, para que solo coja un obj a la vez y no instancie si lleva un plato
                    //if(gameObject.transform.childCount == 0 && objsPlayer.Count <2)
                    //{
                        //print("caja verde");
                        pelota = Instantiate(obj1, pos.transform.position, Quaternion.identity) as GameObject;
                        pelota.name = "cajaAma" + nV;
                        nV++;
                        pelota.transform.SetParent(gameObject.transform);
                        pelota.GetComponent<Rigidbody>().useGravity = false;
                        cogido = true;
                        playerObj = true;
                    //}
                //}
            }
            
        }

        //sacar objetos de la caja Azul
        if (other.transform.tag == "cajaA")
        {
            string col = other.transform.name;


            if (Input.GetButtonDown("Submit") && !cogido && gameObject.transform.childCount == 0)
            {
                //if (!objetos.colCajasObj.Contains(col) && objsPlayer.Count == 0)
                //{

                    //solo saca el objeto si no tiene ningun hijo mas, para que solo coja un obj a la vez y no instancie si lleva un plato
                    //if (transform.childCount == 0)
                    //{
                        pelota = Instantiate(obj2, pos.transform.position, Quaternion.identity) as GameObject;
                        pelota.name = "objA"+nA;
                        nA++;
                        pelota.transform.SetParent(gameObject.transform);
                        pelota.GetComponent<Rigidbody>().useGravity = false;
                        cogido = true;
                        playerObj = true;
                    //}

                //}
            }
        }

        //sacar objetos de la caja Roja
        if (other.transform.tag == "cajaR")
        {

            string col = other.transform.name;
         
            if (Input.GetButtonDown("Submit") && !cogido && gameObject.transform.childCount == 0)
            {
                //if (!objetos.colCajasObj.Contains(col) && objsPlayer.Count == 0)
                //{
                    //solo saca el objeto si no tiene ningun hijo mas, para que solo coja un obj a la vez y no instancie si lleva un plato
                    //if (transform.childCount == 0)
                    //{
                        //print("caja rojo");
                        pelota = Instantiate(obj3, pos.transform.position, Quaternion.identity) as GameObject;
                        pelota.name = "objR"+nR;
                        nR++;
                        pelota.transform.SetParent(gameObject.transform);
                        pelota.GetComponent<Rigidbody>().useGravity = false;
                        cogido = true;
                        playerObj = true;
                    //}
                //}
            }
        }



        //los objetos 
        if (other.transform.tag == "objetos")
        {

            other.GetComponent<Rigidbody>().isKinematic = false;

            //SOLTAR EN MESA
            //para que suelte el obj, si hay varios en el trigger
            if (!cogido)
            {
                other.transform.parent = null;
                other.GetComponent<Rigidbody>().useGravity = true;
                other.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                other.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
                playerObj = false;
                //print("soltado plato mesa");

            }

            //coger obj de una mesa
            if (Input.GetButtonDown("Submit") && !cogido && paraCoger && playerMesa && platosPlayer.Count==0)
            //if (Input.GetButtonDown("Submit") && !cogido && paraCoger && playerMesa)
            {
                print("cogido obj de mesa");
                other.transform.SetParent(gameObject.transform);
                other.GetComponent<Rigidbody>().useGravity = false;
                other.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                //para que el objeto se quede a la distancia que yo quiero
                other.transform.position = pos.transform.position;
                //coge la rotacion del pj para que el obj siempre este recto
                //other.transform.rotation = Quaternion.Slerp(other.transform.rotation, gameObject.transform.rotation, Time.deltaTime * 50);
                cogido = true;
                playerObj = true;
            }


            //COGER DEL SUELO
            //if (Input.GetButtonDown("Submit") && !cogido && paraCoger && platosPlayer.Count==0 && objsPlayer.Count<2)
            //if (Input.GetButtonDown("Submit") && !cogido && paraCoger && objsPlayer.Count<2)
            if (Input.GetButtonDown("Submit") && !cogido && paraCoger)//va mejor que los demas
            {
                //solo coge el objeto si no tiene ningun hijo mas, para que solo coja un obj a la vez
                //y no esta en trig de otro obj
                if (transform.childCount == 0 && !playerMesa)
                {

                    print("cogido suelo");
                    other.transform.SetParent(gameObject.transform);
                    other.GetComponent<Rigidbody>().useGravity = false;
                    other.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                    //para que el objeto se quede a la distancia que yo quiero
                    other.transform.position = pos.transform.position;
                    //coge la rotacion del pj para que el obj siempre este recto
                    //other.transform.rotation = Quaternion.Slerp(other.transform.rotation, gameObject.transform.rotation, Time.deltaTime * 50);
                    cogido = true;
                    playerObj = true;

                    //para que coja el plato si colisiona con plato y obj
                    if(platosPlayer.Count > 0)
                    {
                        //asd
                    }
                }

            }




            //soltar obj sin que colisione con mesa(en el suelo)
            if (Input.GetButtonDown("Submit") && cogido && !paraCoger && objsPlayer.Count ==1 && !colBasura && !entregaTrg)
            //if (Input.GetButtonDown("Submit") && cogido && !paraCoger && !colBasura && !entregaTrg)
            {
                //print("no mesilla");

                if (transform.childCount==1 && !playerMesa)
                {

                    print("soltado obj suelo");
                    other.transform.parent = null;
                    cogido = false;
                    other.GetComponent<Rigidbody>().isKinematic = false;
                    other.GetComponent<Rigidbody>().useGravity = true;
                    other.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                    other.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
                    playerObj = false;

                }
            }


            //BASURAAAAAAAAAAAAAAAAAAAAAAAAAA
            if (Input.GetButtonDown("Submit") && colBasura){
                basura(other.gameObject);
                print("basurilla");
                //comproibar
                plato.colPlatos.Remove(other.gameObject.name);
                //limpiar losta de objsPlayer
                objsPlayer.Remove(other.gameObject.name);
            }

        }

        //solo dejar un obj en la mesa
        if (other.transform.tag == "mesa")
        {
            playerMesa = true;
            string col5 = other.transform.name;
            //print("col5: " + col5);


            string hijo = gameObject.transform.GetChild(0).gameObject.name;
            hijo = hijo.Substring(0, hijo.Length - 1);
            //print("hijo: " + hijo);

            //si el hijo es un obj
            //if(hijo=="objAma" || hijo == "objR" || hijo == "objA")
            if(hijo!="plato")
            {
                playerObj = true;


                if (Input.GetButtonDown("Submit") && cogido && !paraCoger && gameObject.transform.parent != null)
                {
                    //entra si la mesa no tiene nada encima
                    //if (objsPlayer.Count<2)
                    //if (!objetos.colCajasObj.Contains(col5) && objsPlayer.Count<2)
                    if (objsPlayer.Count == 1)
                    {
                        print("soltado obj mesa");
                        other.transform.parent = null;
                        cogido = false;
                        playerObj = false;
                    }

                    //poder soltar el obj en el plato cuando este en la mesa, y no haya nada en ese plato
                    if (platosPlayer.Count==1 && objsPlayer.Count==1)
                    //if (objetos.colCajasObj.Contains(col5) && platosPlayer.Count>=1 && objsPlayer.Count==0)
                    {
                        other.transform.parent = null;
                        print("soltado obj plato mesa");
                        cogido = false;
                        playerObj = false;
                    }

                }
            }



            //para soltar 1 plato en mesa
            if (hijo == "plato")
            {
                //print("hijo plato");
                if (Input.GetButtonDown("Submit") && cogido && !paraCoger && gameObject.transform.parent != null)
                {
                    playerMesa = true;
                    if (!objetos.colCajasObj.Contains(col5))//entra al tener un plato cogido y soltarlo en la mesa
                    {
                        if (transform.childCount > 0 && platosPlayer.Count<2 && !colBasura)
                        {
                            print("soltado plato mesa2");
                            //gameObject.transform.Find("plato").parent = null;
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
                    other.transform.parent = null;
                    other.GetComponent<Rigidbody>().isKinematic = false;
                    other.GetComponent<Rigidbody>().useGravity = true;
                    other.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                    other.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
                    playerPlato = false;
                    //print("no cogido paltillo");
                }
                else
                {
                    //other.transform.position = pos.transform.position;
                    other.GetComponent<Rigidbody>().isKinematic = true;
                    other.GetComponent<Rigidbody>().useGravity = false;
                    other.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                    other.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;


                }


            //print("trig plato");

           //if (Input.GetButtonDown("Submit") && !cogido && paraCoger && objetos.colPlato)
           //if (Input.GetButtonDown("Submit") && !cogido && paraCoger && platosPlayer.Count>=0 && objsPlayer.Count>=0)


           //coger plato+obj 
           if (Input.GetButtonDown("Submit") && !cogido && paraCoger && plato.colPlatos.Count>0 && objsPlayer.Count>0)
           {
                    print("coge plato+obj");
                    other.transform.SetParent(gameObject.transform);
                    other.GetComponent<Rigidbody>().isKinematic = true;
                    other.GetComponent<Rigidbody>().useGravity = false;
                    other.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;

                    other.transform.position = pos.transform.position;

                    cogido = true;
                    //other.transform.rotation = Quaternion.Slerp(other.transform.rotation, gameObject.transform.rotation, Time.deltaTime * 50);
                    playerPlato = true;

                

           }

            //coger plato 
            if (Input.GetButtonDown("Submit") && !cogido && paraCoger && objsPlayer.Count==0)
            //if (Input.GetButtonDown("Submit") && !cogido && paraCoger && !objetos.colPlato)
            {
                print("coge plato");
                other.transform.SetParent(gameObject.transform);
                other.GetComponent<Rigidbody>().isKinematic = true;
                other.GetComponent<Rigidbody>().useGravity = false;
                other.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;

                other.transform.position = pos.transform.position;
                
                cogido = true;
                //other.transform.rotation = Quaternion.Slerp(other.transform.rotation, gameObject.transform.rotation, Time.deltaTime * 50);
                playerPlato = true;



            }

            //soltar plato si no es una mesa(SUELO)
            if (Input.GetButtonDown("Submit") && cogido && !paraCoger && playerPlato && !colBasura)
            {
                //print("suelo");
                //solo un obj cogido, soltar si no es una mesa
                if (transform.childCount > 0 && !playerMesa && objsPlayer.Count<2 && platosPlayer.Count<2 && !entregaTrg)
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

            //soltar PLATO EN MESA  
            if (Input.GetButtonDown("Submit") && cogido && !paraCoger && playerPlato)
            {

               if (transform.childCount > 0 && playerMesa && platosPlayer.Count<2)
                {
                    
                        print("soltado plato en mesa");
                        other.transform.parent = null;
                        cogido = false;
                        other.GetComponent<Rigidbody>().isKinematic = false;
                        other.GetComponent<Rigidbody>().useGravity = true;
                        other.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                        other.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
                    
                }

                if (transform.childCount > 0 && entregaTrg && platosPlayer.Count < 2)//que no pueda soltar plato en mesa si hay un obj
                {

                    print("soltado plato en mesa2");
                    other.transform.parent = null;
                    cogido = false;
                    other.GetComponent<Rigidbody>().isKinematic = false;
                    other.GetComponent<Rigidbody>().useGravity = true;
                    other.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                    other.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;

                }


            }



        }


        //dejar plato encima de las cajas y que no instancie el obj, y poder cogerlo
        if (Input.GetButtonDown("Submit") && (other.transform.tag=="cajaA" || other.transform.tag == "cajaV" || other.transform.tag == "cajaR" || other.transform.tag == "mesa") && transform.Find("plato"))
        {
            //print("caja+plato+player");
            //platoCaja = true;
            cogido = true;

        }

        //que solo suelte si es plato y objeto
        if (other.transform.tag == "entrega")
        {
            entregaTrg = true;

            
        }

        //--------------------------------------------------------------------------------------------------------

        //BASURA

        if (other.transform.tag == "basura")
        {
            colBasura = true;

        }

    }

    private void OnTriggerExit(Collider other)
    {

        if (other.transform.tag == "entrega")
        {
            entregaTrg = false;
        }

        if (other.transform.tag=="cajaA")
        {
            //platoCaja = false;

        }

        if (other.transform.tag == "cajaV")
        {
           // platoCaja = false;

        }
        if (other.transform.tag == "cajaR")
        {
            //platoCaja = false;

        }
        if (other.transform.tag == "mesa")
        {
            playerMesa= false;
            //platoCaja = false;

        }

        if (other.transform.tag == "basura")
        {
            colBasura = false;

        }

        if (other.transform.tag == "objetos")
        {
            objsPlayer.Remove(other.transform.name);
            //print("trig exit obj");
        }

        if (other.transform.tag == "plato")
        {
            platosPlayer.Remove(other.transform.name);
        }

        


    }

    //elimiar un obj que esta en el plato a ir a la basura
    void basura(GameObject eliminar)
    {
        Destroy(eliminar);
    }

    //MECANICA PRINCIPAL
    void mec()
    {

    }


  
}


    

