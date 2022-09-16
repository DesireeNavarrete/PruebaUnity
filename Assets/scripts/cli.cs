using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class cli : MonoBehaviour
{
    public bool cli1, entregadoCli1, paraCobrar;
    public string cosa;


    public int dineros;

    //contadores de ui pedidos
    public int contt1 = 0;
    public float contt_1 = 0;

    //contador para crear el primer pedido, 3s despues de cli=true
    public int contt1Ped = 0;
    float contt_1Ped = 0;


    public GameObject ui_morado, ui_verde, ui_naranja, dinero;//prefabs de las imagenes de los obj para los pedidos

    Canvas ped1;

    float lifeF1 = 0;
    public int life1 = 0;
    public bool vida1;


    public int numPed = 0;//recuento de num de pedidos

    public List<string> pedActivos = new List<string>();


    public static bool player;

    public Vector3 touchedPos;
    void Start()
    {

        //posUI = new Rect(-357.3f, -159.3f, Screen.width, Screen.height);
        ped1 = GetComponentInChildren<Canvas>();
        cli1 = false;
        paraCobrar = false;
    }

    void Update()
    {

        if (Input.touchCount > 0)//buscar forma de filtrar por tag para poder preguntarle cuando esta tocando el dedo al cli
        {
            Touch touch = Input.GetTouch(0); 

            if (touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved)
            {
                print("asdasd");
                // get the touch position from the screen touch to world point
                touchedPos = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 10));
                // lerp and set the position of the current object to that of the touch, but smoothly over time.
                transform.position = Vector3.Lerp(transform.position, touchedPos, Time.deltaTime);
            }
        }

        /*if(detector.datafono && player)
        {
            print("a cobrar");
            
        }*/

        //print(entregaPed.pedidosActivos1[0]);
        //print(cosa);

        //print("cogido: "+ detector.cogido);
        //print("entregadoCli1: " + entregadoCli1);



        //PARA $$$$$
        if (numPed == 0 && !paraCobrar)
        {
            //paraCobrar = true;
        }


        //AÑADE PEDIDOS AL ARRAY
        //if (cli1)//cliente en trigger de la mesa
        //{
            contt_1Ped += Time.deltaTime;
            contt1Ped = (int)contt_1Ped;

            if (pedActivos.Count == 0 && !paraCobrar)
            {

                if (contt1Ped == 3)//3s despues de que el cli1 llegue al trigger
                {
                    UI_Manager.start = true;
                    //añade pedido en la primera mesa
                    //añadir varios o no, para que algunos clientes puedan hacer varios

                    for (int i = 0; i < Random.RandomRange(2, 6); i++)
                    {
                        pedActivos.Add(coctel.bebidas[Random.RandomRange(0, 3)]);
                        numPed = pedActivos.Count;
                    }
                }
            }
        //}
    

        //contador de tiempo para el pedido del cli1
        if (entregadoCli1)
        {
            contt_1 += Time.deltaTime;
            contt1 = (int)contt_1;
            //print("contador start");



            //-----ENTREGADO--------------------------
            if (contt1 == 1)
            {
                //print("entregao");
                //se elimina el entregado del canvas
                Destroy(ped1.transform.GetChild(0).gameObject);

                //float max = ped1.GetComponentInChildren<Slider>().maxValue;

                //restar al entregar
                numPed--;


                //100 puntos, si la vida esta entre la mitad y el 100%
                /*if (life1 <=max && life1 >= max/2)
                {
                    print("-puntos");
                    dineros+=50;
                    //punticos.text = puntos.ToString();

                }

                //50 puntos, si la vida esta entre el 50% y el 0%
                if (life1 <=max/2 && life1>0)
                {
                    print("+puntos");
                    dineros += 100;
                    //punticos.text = puntos.ToString();

                }*/

            }
            //-----NO UI---------------------------------
            if (contt1 > 1 && contt1 < 7)
            {
                print("quita ui");
                ped1.transform.GetChild(0).gameObject.SetActive(false);

            }


            //-----SIGUIENTE PEDIDO--------------------
            //se espera 7s para poner el siguiente ped, poner en aleatorio entre 4 y 10 por ejemplo?¿?¿?¿?
            if (contt1 == 7)
            {

                print("sale ui");
                //eliminar el pedido de la lista para que spwnee el siguiente y reset contadores
                pedActivos.RemoveAt(0);
                entregadoCli1 = false;
                contt1 = 0;
                contt_1 = 0;


                //UI ---------------$$$$$
                if (numPed == 0 && UI_Manager.start)
                {
                    paraCobrar = true;
                    GameObject x = Instantiate(dinero) as GameObject;
                    x.transform.SetParent(ped1.transform, false);
                    x.transform.localScale = new Vector3(0.01f, 0.01f);
                    print("cobrar");
                    //con vida o sin vida para cobrar????

                }
            }



        }

        //---------------- UI VIDA PEDIDO ---------------------------------------------------------------------------------------

        //VIDA PED1
        if (ped1.transform.childCount == 1)
        {
            lifeF1 += Time.deltaTime;
            life1 = (int)lifeF1;

            ped1.GetComponentInChildren<Slider>().value = life1;

            if (life1 == ped1.GetComponentInChildren<Slider>().maxValue)//fin vida
            {
                vida1 = true;
                lifeF1 = 0;

            }

        }

        if (vida1)//cuando se acaba la vida
        {
            Destroy(ped1.transform.GetChild(0).gameObject);
            pedActivos.RemoveAt(0);
            vida1 = false;

        }


        //---------------- IMAGEN DE PEDIDO ---------------------------------------------------------------------------------------
        //si hay pedidos para el cliente1, pone la imagen del coctel que toca
        if (pedActivos.Count >= 1)
        {
            ped1.enabled = true;


            if (pedActivos[0] == "morado" && !ped1.transform.Find("pedidoMorado(Clone)"))
            {
                GameObject x = Instantiate(ui_morado) as GameObject;
                x.transform.SetParent(ped1.transform, false);
                x.transform.localScale = new Vector3(0.01f, 0.01f);
                ped1.GetComponentInChildren<Slider>().maxValue = Random.Range(30, 31);
                lifeF1 = 0;
            }

            if (pedActivos[0] == "naranja" && !ped1.transform.Find("pedidoNaranja(Clone)"))
            {

                GameObject x = Instantiate(ui_naranja) as GameObject;
                x.transform.SetParent(ped1.transform, false);
                x.transform.localScale = new Vector3(0.01f, 0.01f);
                ped1.GetComponentInChildren<Slider>().maxValue = Random.Range(30, 31);
                lifeF1 = 0;

            }

            if (pedActivos[0] == "verde" && !ped1.transform.Find("pedidoVerde(Clone)"))
            {

                GameObject x = Instantiate(ui_verde) as GameObject;
                x.transform.SetParent(ped1.transform, false);
                x.transform.localScale = new Vector3(0.01f, 0.01f);
                ped1.GetComponentInChildren<Slider>().maxValue = Random.Range(30, 31);
                lifeF1 = 0;

            }

        }

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "cli")
        {
            cli1 = true;
            other.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            if (pedActivos.Count == 0 && dineros > 0)
            {
                print("no ped cli");



                //other.gameObject.SetActive(false);
                //Destroy(other.gameObject, 2);

            }
        }
    }


    private void OnTriggerStay(Collider other)
    {

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "cli")
        {
            cli1 = false;
        }

        if (other.transform.tag == "objetos")
        {
            objetos.colCajasObj.Remove(other.transform.name);

        }
    }

    private void OnCollisionEnter(Collision col)
    {
        //entrega de pedido del cliente1
        if (col.transform.tag == "objetos")
        {
            print("col plato+objeto " + col.transform.name);
            cosa = col.transform.name;
            cosa = cosa.Remove(cosa.Length - 1);

            if (cosa == pedActivos[0])
            {
                //eliminar el obj entregado del canvas
                entregadoCli1 = true;
                //coctel.pedActivos1.RemoveAt(0);
                col.collider.enabled = false;

                objetos.colCajasObj.Remove(col.transform.name);

                Destroy(col.gameObject, 5);


            }
        }




    }

    private void OnCollisionStay(Collision col)
    {
        if (col.transform.tag == "Player")
        {
            player = true;
        }
    }

    private void OnCollisionExit(Collision col)
    {
        if (col.transform.tag == "objetos")
        {
            entregadoCli1 = false;
            objetos.colCajasObj.Remove(col.transform.name);

        }

        if (col.transform.tag == "Player")
        {
            player = false;
        }
    }
}
