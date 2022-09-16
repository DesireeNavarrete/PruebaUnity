using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class detector7 : MonoBehaviour
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
    public bool cogido, paraCoger, platoCaja, playerMesa;
    public static bool playerPlato,playerObj, colBasura;

    public List<string> objsPlayer;
    //public List<string> objsPlayer = new List<string>();

    public int cd;
    public float cdF;

    /* cogido: cuando el obj/plato es hijo del detector
     * paraCoger: cuando el obj/plato se puede coger
     * 
     * platoCaja: true cuando el player lleva un plato y abre una caja. Para que un plato se pueda dejar/soltar encima de una caja, pero no instancie obj
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
        platoCaja = false;
        playerPlato = false;
        playerObj = false;
        colBasura = false;
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
        //foreach (string col in objetos.colObjPlato)
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


        if (gameObject.transform.parent == null){
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

        //lista de trig de los objetos con el player
        if (other.transform.tag == "plato")
        {
            //si no esta en la lista
            /*if (!objsPlayer.Contains(other.name))
            {

                objsPlayer.Add(other.transform.name);
            }*/
            //print("lista objs2");

        }
    }


    private void OnTriggerStay(Collider other)
    {

        
        //sacar objetos de la caja Verde
        if (other.transform.tag == "cajaV")
        {

            string col = other.transform.name;
            //print("list name " + objetos.colCajasObj.Contains(col));

            cdF += Time.deltaTime;
            cd = (int)cdF;

            if (cd == 2)
            {
                cdF = 0;

            }

            if (Input.GetButtonDown("Submit") && !cogido)
            {
                
                //solo un obj encima de la caja
                if(!objetos.colCajasObj.Contains(col) && cd >= 0)
                {
                    //solo saca el objeto si no tiene ningun hijo mas, para que solo coja un obj a la vez y no instancie si lleva un plato
                    if(gameObject.transform.childCount == 0 && objsPlayer.Count <2)
                    {
                        //print("caja verde");
                        pelota = Instantiate(obj1, pos.transform.position, Quaternion.identity) as GameObject;
                        pelota.name = "objV"+nV;
                        nV++;
                        pelota.transform.SetParent(gameObject.transform);
                        pelota.GetComponent<Rigidbody>().useGravity = false;
                        cogido = true;
                        playerObj = true;
                        cdF = 0;
                    }
                }
            }
        }

        //sacar objetos de la caja Azul
        if (other.transform.tag == "cajaA")
        {
            string col = other.transform.name;

            cdF += Time.deltaTime;
            cd = (int)cdF;

            if (cd == 2)
            {
                cdF = 0;
            }

            if (Input.GetButtonDown("Submit") && !cogido)
            {
                if(!objetos.colCajasObj.Contains(col) && cd >= 1)
                {

                    //solo saca el objeto si no tiene ningun hijo mas, para que solo coja un obj a la vez y no instancie si lleva un plato
                    if (transform.childCount == 0)
                    {
                        pelota = Instantiate(obj2, pos.transform.position, Quaternion.identity) as GameObject;
                        pelota.name = "objA"+nA;
                        nA++;
                        pelota.transform.SetParent(gameObject.transform);
                        pelota.GetComponent<Rigidbody>().useGravity = false;
                        cogido = true;
                        playerObj = true;
                        cdF = 0;
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
            
            cdF += Time.deltaTime;
            cd = (int)cdF;

            if (cd == 2)
            {
                cdF = 0;
            }

            if (Input.GetButtonDown("Submit") && !cogido)
            {
                if(!objetos.colCajasObj.Contains(col) && cd >= 1)
                {
                    //solo saca el objeto si no tiene ningun hijo mas, para que solo coja un obj a la vez y no instancie si lleva un plato
                    if (transform.childCount == 0)
                    {
                        //print("caja rojo");
                        pelota = Instantiate(obj3, pos.transform.position, Quaternion.identity) as GameObject;
                        pelota.name = "objR"+nR;
                        nR++;
                        pelota.transform.SetParent(gameObject.transform);
                        pelota.GetComponent<Rigidbody>().useGravity = false;
                        cogido = true;
                        playerObj = true;
                        cdF = 0;
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
                //y no esta en trig de otro obj
                if (transform.childCount == 0 && !playerMesa)
                {
                    if (playerPlato)
                    {
                        print("platoototototo");
                    }
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
                }

            }

            

            //soltar obj sin que colisione con mesa(en el suelo)
            else if(gameObject.transform.parent != null)
            {

                //devuelve el nombre del hijo
                string x = "obj";
                string z = gameObject.transform.GetChild(0).gameObject.name;
                Match match;
                match = Regex.Match(z, x);
                
                //        print(match);
                //       print(z);
                //        print(x);

                if (match.Success)
                {
                        //print("no mesilla");
                    if (Input.GetButtonDown("Submit") && cogido && !paraCoger && objsPlayer.Count<2)
                    {

                        if (transform.childCount > 0 && !playerMesa)
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
                }
            }
        }

        //solo dejar un obj en la mesa
        if (other.transform.tag == "mesa")
        {
            playerMesa = true;
            string col = other.transform.name;
            //print("list mesa " + objetos.colCajasObj.Contains(col));
            //print("col: "+col);

            
            
            //para obj en mesa
            //compara el hijo si es un obj por nombre, quitando el num del obj
            if(gameObject.transform.parent != null)
            {
                //devuelve el nombre del hijo
                string x = "obj";
                string z = gameObject.transform.GetChild(0).gameObject.name;
                Match match;
                match = Regex.Match(z, x);
                //print(match);
                //print(match);//obj
                //print(z);//objA1
                //print(x);//obj

               //if (match.Success)
                //{
                    //print("match");
                    //compara el nombre del obj con el del hijo
                    playerObj = true;
                    //print("obj");

                    //añadir que este en trigg con objXX, para que no entre con un plato
                    if (Input.GetButtonDown("Submit") && cogido && !paraCoger && gameObject.transform.parent!=null)
                    {
                        //entra si la mesa no tiene nada encima
                        if (!objetos.colCajasObj.Contains(col) && match.Success)
                        {
                            print("soltado obj mesa");
                            other.transform.parent = null;
                            cogido = false;
                            playerObj = false;
                        }

                        //poder soltar objs en el plato cuando este en la mesa
                        /*if(objetos.colCajasObj.Contains(col))
                        {
                            if (plato.colPlatos.Count == 0)//si la lista de objs en plato esta vacia
                            {

                                //print("para soltar obj en plato");
                                other.transform.parent = null;
                                print("soltado obj mesa a plato");
                                cogido = false;
                                playerObj = false;
                            }
                        }*/

                    //}
                }

            }




            //para soltar platos en mesa
            if (gameObject.transform.Find("plato"))
            {
                string col2 = other.transform.name;

                if (Input.GetButtonDown("Submit") && cogido && !paraCoger && gameObject.transform.parent != null)
                {
                    //print("col2: "+col2);
                    playerMesa = true;
                    print("plato en mesa");
                    if (!objetos.colCajasObj.Contains(col2))//entra al tener un plato cogido y soltarlo en la mesa vacia
                    {
                        if (transform.childCount > 0 && !colBasura & objsPlayer.Count<2) 
                        {
                            print("plati");
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

           //coger plato+obj 
           if (Input.GetButtonDown("Submit") && !cogido && paraCoger && objetos.colPlato)
           {
                    //print("coge plato+obj");
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
            if (Input.GetButtonDown("Submit") && !cogido && paraCoger && !objetos.colPlato)
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
            if (Input.GetButtonDown("Submit") && cogido && !paraCoger && playerPlato)
            {
                //solo un obj cogido, soltar si no es una mesa
                if (transform.childCount > 0 && !playerMesa && objsPlayer.Count<2)
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

            //soltar obj en plato

            

        }

        //si colisiona con un plato con obj, coge el plato con el obj
        /*if (other.transform.tag == "plato" && other.transform.Find("obj1"))
        {
            print("plato con obj");
        }*/


        //dejar plato encima de las cajas y que no instancie el obj, y poder cogerlo
        if (Input.GetButtonDown("Submit") && (other.transform.tag=="cajaA" || other.transform.tag == "cajaV" || other.transform.tag == "cajaR" || other.transform.tag == "mesa") && transform.Find("plato"))
        {
            //print("caja+plato+player");
            platoCaja = true;
            cogido = true;

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
        if(other.transform.tag=="cajaA")
        {
            platoCaja = false;
            cdF = 0;

        }

        if (other.transform.tag == "cajaV")
        {
            platoCaja = false;
            cdF = 0;

        }
        if (other.transform.tag == "cajaR")
        {
            platoCaja = false;
            cdF = 0;

        }
        if (other.transform.tag == "mesa")
        {
            playerMesa= false;

        }

        if (other.transform.tag == "basura")
        {
            colBasura = false;

        }

        if (other.transform.tag == "objetos")
        {
            objsPlayer.Remove(other.transform.name);
            print("trig exit obj");
        }

        if (other.transform.tag == "plato")
        {
            objsPlayer.Remove(other.transform.name);
        }
    }
}


    

