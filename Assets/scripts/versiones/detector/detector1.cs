using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detector1 : MonoBehaviour
{
    public GameObject obj1, obj2, obj3, sp;
    //public List<GameObject> listaObj = new List<GameObject>();//lista de objetos, para instanciarlos en la caja y poder ir añadiendo
    //public List<GameObject> listaObjCog = new List<GameObject>(); 
    GameObject[] caja;
    public GameObject[] objs;
    GameObject pj, pelota;
    public bool cogido,paraCoger;
    Rigidbody rigiObj;

    private void Awake()
    {
        
        pelota = Instantiate(obj1, sp.transform.position, Quaternion.identity) as GameObject;
        rigiObj = pelota.GetComponent<Rigidbody>();
        rigiObj.useGravity = false;
        //listaObj.Add(pelota);

    }

    void Start()
    {
        rigiObj.constraints = RigidbodyConstraints.FreezePosition;
        caja = GameObject.FindGameObjectsWithTag("caja");
        pj = GameObject.FindGameObjectWithTag("Player");
        objs = GameObject.FindGameObjectsWithTag("objetos");
        paraCoger = true;
        cogido = false;


    }

    void Update()
    {
        //añadir a la lista

        rigiObj = pelota.GetComponent<Rigidbody>();
        Debug.Log("parent: " + obj1.transform.parent.name);

        if (cogido)
        {
            paraCoger = false;
            StartCoroutine(gravedadNo());
            //rigiObj.constraints = RigidbodyConstraints.FreezePosition;
        }
        if (!cogido && paraCoger==false)
        {
            StartCoroutine(gravedad());
            paraCoger = true;
        }



    }

    private void OnTriggerStay(Collider other)
    {
        //sacar objetos de la caja
        if (other.transform.tag == "caja")
        {
            if (Input.GetButtonDown("Submit") && cogido == false)
            {
                for (int i = 0; i <= objs.Length; i++)//lista.Count
                {
                    print("cogidoCaja");
                    objs[i].transform.SetParent(pj.transform);
                    //objetos.listaObjCog.Add(objs[i]);
                    cogido = true;
                    rigiObj.constraints = RigidbodyConstraints.FreezeRotation;
                    rigiObj.constraints = RigidbodyConstraints.FreezePosition;
                    StartCoroutine(gravedad());
                }
                /*for (int i = 0; i <= listaObj.Count; i++)//lista.Count
                {
                    listaObj[i].transform.SetParent(pj.transform);
                    cogido = true;
                    rigiObj.constraints = RigidbodyConstraints.FreezeRotation;
                    rigiObj.constraints = RigidbodyConstraints.FreezePosition;
                    StartCoroutine(gravedad());
                    print("cogidoCaja");
                }*/


            }
        }

        //coger los objetos del suelo
        if (other.transform.tag == "objetos")
        {
            print("objeto");
            rigiObj = pelota.GetComponent<Rigidbody>();

            /*for (int i=0;i<=objs.Length; i++)
            {

            rigiObj = objs[i].GetComponent<Rigidbody>();
            }*/

            //coger
            if (Input.GetButtonDown("Submit") && cogido == false && paraCoger)
            {
                print("cogido");

                for (int z = 0; z <= objs.Length; z++)
                {
                    objs[z].transform.SetParent(pj.transform);
                    //objetos.listaObjCog.Add(objs[z]);
                    cogido = true;
                    rigiObj.constraints = RigidbodyConstraints.FreezeRotation;
                    rigiObj.constraints = RigidbodyConstraints.FreezePosition;
                }
                /*for (int z = 0; z <= listaObj.Count; z++)//lista.Count
                {
                    
                    listaObj[z].transform.SetParent(pj.transform);
                    cogido = true;
                    rigiObj.constraints = RigidbodyConstraints.FreezeRotation;
                    rigiObj.constraints = RigidbodyConstraints.FreezePosition;
                    StartCoroutine(gravedadNo());
                    print("cogidoCaja");
                }*/
                //StartCoroutine(gravedadNo());

                //pelota.transform.SetParent(pj.transform);

            }

            //soltar
            if (Input.GetButtonDown("Submit") && cogido && paraCoger==false)
            {
                print("soltado");


                //pelota.transform.parent = null;
                cogido = false;
                rigiObj.constraints = RigidbodyConstraints.None;
                rigiObj.constraints = RigidbodyConstraints.FreezeRotation;
                StartCoroutine(gravedad());

                //al soltar, instanciar otro en la caja, con posicion freezeada
                pelota = Instantiate(obj1, sp.transform.position, Quaternion.identity) as GameObject;
                //rigiObj.constraints = RigidbodyConstraints.FreezePosition;
                //listaObj.Add(pelota);
                for (int i = 0; i <= objs.Length; i++)
                {
                    objs[i].transform.parent = null;
                    //objetos.listaObjCog.Remove(objs[i]);
                }

            }


        }
        
    }

    /*---------------------------------BUGS-----------------------------------
     * 
     * coger obj de la caja cuando ya hay uno fuera
     * 
     * 
     * 
     * 
     * 
     * -----------------------------------------------------------------------*/
    IEnumerator gravedad()
    {
        yield return new WaitForSeconds(.1f);


        for (int i = 0; i <= objs.Length; i++)
        {
            print("gravedad");
            //rigiObj = objs[i].GetComponent<Rigidbody>();
            objs[i].GetComponent<Rigidbody>().useGravity = true;
            //rigiObj.constraints = RigidbodyConstraints.FreezePosition;

        }
    }


    IEnumerator gravedadNo()
    {
        yield return new WaitForSeconds(.1f);

        for (int i = 0; i <= objs.Length; i++)
        {

            print("no gravedad");
            //rigiObj = objs[i].GetComponent<Rigidbody>();
            objs[i].GetComponent<Rigidbody>().useGravity = false;

        }
    }

}
