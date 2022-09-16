using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class entregaPed4 : MonoBehaviour
{
    public GameObject canvas;
    
    public List<string> numPlatos = new List<string>();
    public GameObject sp, platoPref;//spawn
    GameObject platos;
    public int t,puntos;
    float tFloat;

    public Text punticos;

    public int numPedidos = 0;//recuento de num de pedidos
    public int objsPed1, objsPed2, objsPedRnm,cont;
    int p=5;
    public string[] objsArray = {"objA", "objV", "objR"};
    public List<string> pedidosActivos = new List<string>();
    string coli; //para la col del obj de entrega

    //public bool entregado, platoEntrega;
    public static bool start;//para que empiece el crono


    public GameObject ped1, ped2, ped3,ped4;//canvas pedidos
    public GameObject ui_objV,ui_objA,ui_objR;//prefabs de las imagenes de los obj para los pedidos

    int maxPed=4;

    public int tiempoPed;
    float tiempoPedF;
    public bool startCont;

    public int tiempoPart;
    public float tiempoPartF;

     float lifeF1 = 0;
     float lifeF2 = 0;
     float lifeF3 = 0;
     float lifeF4 = 0;

    public int life1 = 0;
    public int life2 = 0;
    public int life3 = 0;
    public int life4 = 0;


    

    public bool vida1, vida2,vida3,vida4;
    public bool ped10s;
    public int ped10;

    private void Awake()
    {
        ped1.SetActive(false);
        ped2.SetActive(false);
        ped3.SetActive(false);
        ped4.SetActive(false);
    }

    void Start()
    {


        

        t = 0;//tiempo en int

        //los 2 pedidos iniciales
        objsPed1 = Random.RandomRange(0, 3);
        objsPed2 = Random.RandomRange(0, 3);

        //numPedidos = 2;
        for (int i = 0; i < objsArray.Length; i++)
        {
            //print(objsArray[objsPed1]);
            //print(objsArray[objsPed2]);
        }
      
        pedidosActivos.Add(objsArray[objsPed1]);
        pedidosActivos.Add(objsArray[objsPed2]);
        

    }

    void Update()
    {
        //tiempo de partida
        if (start)
        {
            //tiempo de partida
            tiempoPartF += Time.deltaTime;
            tiempoPart = (int)tiempoPartF;
        }


        //spawn de pedidos
        if (startCont)
        {
            tiempoPedF += Time.deltaTime;//contador de tiempo entre pedidos
            tiempoPed = (int)tiempoPedF;
            //startCont = false;

            //spawn de 5s al entregar
            if (tiempoPart <= 30 && tiempoPed == 3)
            {

                //generar pedidos aleatorios hasta 4, despues de Xseg, dependiendo de numPed
                if (pedidosActivos.Count < 4 && numPedidos>0)
                {
                    pedidosActivos.Add(objsArray[Random.RandomRange(0, 3)]);
                    startCont = false;
                    tiempoPedF = 0;
                    numPedidos--;
                    print("añadido 3s");

                    reinicioVida();

                }
            }

            //spawn de 2s al entregar, despues de 30s de partida
            if(tiempoPart >30 && tiempoPed == 1)
            {
                if (pedidosActivos.Count < 4 && numPedidos > 0)
                {
                    pedidosActivos.Add(objsArray[Random.RandomRange(0, 3)]);
                    startCont = false;
                    tiempoPedF = 0;
                    numPedidos--;
                    print("añadido 1s");
                    //reinicioVida();
                    
                }
            }

            //spawn de 2s al sin empezar partida
            if (tiempoPart == 0 && tiempoPed == 2)
            {
                if (pedidosActivos.Count < 4 && numPedidos > 0)
                {
                    pedidosActivos.Add(objsArray[Random.RandomRange(0, 3)]);
                    startCont = false;
                    tiempoPedF = 0;
                    numPedidos--;
                    //print("añadido 2s");
                    //reinicioVida();

                }
            }

            //spawn de 2s al entregar, despues de 30s de partida
            /*if (tiempoPart < 151 && tiempoPed == 2)
            {
                if (pedidosActivos.Count < 4 && numPedidos > 0)
                {
                    pedidosActivos.Add(objsArray[Random.RandomRange(0, 3)]);
                    startCont = false;
                    tiempoPedF = 0;
                    numPedidos--;
                    print("añadido varios");
                    //reinicioVida();

                }
            }*/


            if (tiempoPart>=30 && tiempoPart%10==0 && tiempoPart%2==0 && pedidosActivos.Count < 4)
            {
                pedidosActivos.Add(objsArray[Random.RandomRange(0, 3)]);
                print("añadido varios");

            }

        }
       


        //al primer pedido que se entrega, empieza el timer
        if (cont == 1)
        {
            start = true;
            
        }



        //----------------INTERFAZ---------------------------------------------------------------------------------------

        //VIDA PED1
        if (ped1.transform.childCount == 1)
        {
            lifeF1 += Time.deltaTime;
            life1 = (int)lifeF1;

            ped1.GetComponentInChildren<Slider>().value = life1;

            if (life1 == ped1.GetComponentInChildren<Slider>().maxValue)//fin vida
            {
                vida1 = true;
                numPedidos++;
                startCont = true;
                lifeF1 = 0;
                
            }

        }

        if (vida1)//cuandose acaba la vida
        {
            Destroy(ped1.transform.GetChild(0).gameObject);
            pedidosActivos.RemoveAt(0);
            vida1 = false;
            //print("vida1: " + vida1);
            //print("l2: " + life2);

            if (pedidosActivos.Count >= 1)//si hay mas de 1, que se mueva a la izq
            {
                lifeF1 = lifeF2;
                lifeF2 = lifeF3;
                lifeF3 = lifeF4;
                ped2.transform.GetChild(0).gameObject.transform.SetParent(ped1.transform, false);
                ped3.transform.GetChild(0).gameObject.transform.SetParent(ped2.transform, false);
                ped4.transform.GetChild(0).gameObject.transform.SetParent(ped3.transform, false);
            }

        }

    
        if (ped1.transform.childCount >= 2)
        {
            Destroy(ped1.transform.GetChild(0).gameObject);

        }

        
        //VIDA PED2
        if (ped2.transform.childCount == 1)
        {
            lifeF2 += Time.deltaTime;
            life2 = (int)lifeF2;

            ped2.GetComponentInChildren<Slider>().value = life2;
            //startCont = false;

            if (life2 == ped2.GetComponentInChildren<Slider>().maxValue)//fin vida
            {
                vida2 = true;
                numPedidos++;
                startCont = true;
                lifeF2 = 0;
            }
        }

        if (vida2)//cuando se acaba la vida
        {
            Destroy(ped2.transform.GetChild(0).gameObject);
            pedidosActivos.RemoveAt(0);
            vida2 = false;

            if (pedidosActivos.Count >= 2)//si ha mas de dos, que se mueva a la izq
            {
                lifeF2 = lifeF3;
                lifeF3 = lifeF4;
                ped3.transform.GetChild(0).gameObject.transform.SetParent(ped2.transform, false);
                ped4.transform.GetChild(0).gameObject.transform.SetParent(ped3.transform, false);
            }

        }
        if (ped2.transform.childCount >= 2)
        {
            Destroy(ped2.transform.GetChild(0).gameObject);

        }

        //VIDA PED3
        if (ped3.transform.childCount == 1)
        {
            lifeF3 += Time.deltaTime;
            life3 = (int)lifeF3;

            ped3.GetComponentInChildren<Slider>().value = life3;
            //startCont = false;

            if (life3 == ped3.GetComponentInChildren<Slider>().maxValue)//fin vida
            {
                vida3 = true;
                numPedidos++;
                startCont = true;
                lifeF3 = 0;
            }
        }

        if (vida3)//cuando se acaba la vida
        {
            Destroy(ped3.transform.GetChild(0).gameObject);
            pedidosActivos.RemoveAt(0);
            vida3 = false;

            if (pedidosActivos.Count >= 3)//si ha mas de tres, que se mueva a la izq
            {
                lifeF3 = lifeF4;
                lifeF4 = 0;
                ped4.transform.GetChild(0).gameObject.transform.SetParent(ped3.transform, false);
            }

        }

        if (ped3.transform.childCount >= 2)
        {
            Destroy(ped3.transform.GetChild(0).gameObject);

        }


        //VIDA PED4
        if (ped4.transform.childCount == 1)
        {
            lifeF4 += Time.deltaTime;
            life4 = (int)lifeF4;

            ped4.GetComponentInChildren<Slider>().value = life4;
            //startCont = false;

            if (life4 == ped4.GetComponentInChildren<Slider>().maxValue)//fin vida
            {
                vida4 = true;
                numPedidos++;
                startCont = true;
                lifeF4 = 0;
            }
        }

        if (vida4)//cuando se acaba la vida
        {
            Destroy(ped4.transform.GetChild(0).gameObject);
            pedidosActivos.RemoveAt(0);
            vida4 = false;

            if (pedidosActivos.Count >= 4)//si ha mas de tres, que se mueva a la izq
            {
                //ped4.transform.GetChild(0).gameObject.transform.SetParent(ped3.transform, false);
                //lifeF3 = lifeF4;
                lifeF4 = 0;
            }
        }

        if (ped4.transform.childCount >= 2)
        {
            Destroy(ped4.transform.GetChild(0).gameObject);

        }




        //si no hay pedidos
        if (pedidosActivos.Count == 0)
        {
            ped1.SetActive(false);
            ped2.SetActive(false);
            ped3.SetActive(false);
            ped4.SetActive(false);
        }


        //si hay 1 pedido, pone la imagen del obj que toca
        if (pedidosActivos.Count >=1)
        {
            ped1.SetActive(true);
            ped2.SetActive(false);
            ped3.SetActive(false);
            ped4.SetActive(false);



            if (pedidosActivos[0] == "objV" && !ped1.transform.Find("pedidoObjV(Clone)"))
            {
                GameObject v = Instantiate(ui_objV) as GameObject;
                v.transform.SetParent(ped1.transform, false);
                ped1.GetComponentInChildren<Slider>().maxValue = Random.Range(10, 12);
                lifeF1 = 0;
            }

            if (pedidosActivos[0] == "objR" && !ped1.transform.Find("pedidoObjR(Clone)"))
            {
                
                GameObject r = Instantiate(ui_objR) as GameObject;
                r.transform.SetParent(ped1.transform, false);
                ped1.GetComponentInChildren<Slider>().maxValue = Random.Range(10, 12);

                lifeF1 = 0;

            }

            if (pedidosActivos[0] == "objA" && !ped1.transform.Find("pedidoObjA(Clone)"))
            {
                
               GameObject a = Instantiate(ui_objA) as GameObject;
               a.transform.SetParent(ped1.transform, false);
               ped1.GetComponentInChildren<Slider>().maxValue = Random.Range(10, 12);

                lifeF1 = 0;

            }
        }

        //si hay 2 pedidos, pone la imagen del obj que toca
        if (pedidosActivos.Count >= 2 )
        {

            ped1.SetActive(true);
            ped2.SetActive(true);
            ped3.SetActive(false);
            ped4.SetActive(false);

            if (pedidosActivos[1] == "objV" && !ped2.transform.Find("pedidoObjV(Clone)"))
            {
                GameObject v = Instantiate(ui_objV) as GameObject;
                v.transform.SetParent(ped2.transform, false);
                ped2.GetComponentInChildren<Slider>().maxValue = Random.Range(14, 16);

                lifeF2 = 0;

            }

            if (pedidosActivos[1] == "objR" && !ped2.transform.Find("pedidoObjR(Clone)"))
            {
                GameObject r = Instantiate(ui_objR) as GameObject;
                r.transform.SetParent(ped2.transform, false);
                ped2.GetComponentInChildren<Slider>().maxValue = Random.Range(14, 16);

                lifeF2 = 0;

            }

            if (pedidosActivos[1] == "objA" && !ped2.transform.Find("pedidoObjA(Clone)"))
            {
                
                GameObject a = Instantiate(ui_objA) as GameObject;
                a.transform.SetParent(ped2.transform, false);
                ped2.GetComponentInChildren<Slider>().maxValue = Random.Range(14, 16);

                lifeF2 = 0;

            }

        }

        //si hay 3 pedidos, pone la imagen del obj que toca
        if (pedidosActivos.Count >= 3)
        {

            ped1.SetActive(true);
            ped2.SetActive(true);
            ped3.SetActive(true);
            ped4.SetActive(false);

            if (pedidosActivos[2] == "objV" && !ped3.transform.Find("pedidoObjV(Clone)"))
            {
                GameObject v = Instantiate(ui_objV) as GameObject;
                v.transform.SetParent(ped3.transform, false);
                ped3.GetComponentInChildren<Slider>().maxValue = Random.Range(18, 20);

                lifeF3 = 0;


            }

            if (pedidosActivos[2] == "objR" && !ped3.transform.Find("pedidoObjR(Clone)"))
            {
                GameObject r = Instantiate(ui_objR) as GameObject;
                r.transform.SetParent(ped3.transform, false);
                ped3.GetComponentInChildren<Slider>().maxValue = Random.Range(18, 20);

                lifeF3 = 0;


            }

            if (pedidosActivos[2] == "objA" && !ped3.transform.Find("pedidoObjA(Clone)"))
            {
                GameObject a = Instantiate(ui_objA) as GameObject;
                a.transform.SetParent(ped3.transform, false);
                ped3.GetComponentInChildren<Slider>().maxValue = Random.Range(18, 20);

                lifeF3 = 0;


            }
        }

        //si hay 4 pedidos, pone la imagen del obj que toca
        if (pedidosActivos.Count >= 4)
        {

            ped1.SetActive(true);
            ped2.SetActive(true);
            ped3.SetActive(true);
            ped4.SetActive(true);

            if (pedidosActivos[3] == "objV" && !ped4.transform.Find("pedidoObjV(Clone)"))
            {
                GameObject v = Instantiate(ui_objV) as GameObject;
                v.transform.SetParent(ped4.transform, false);
                ped4.GetComponentInChildren<Slider>().maxValue = Random.Range(10, 16);

                lifeF4 = 0;


            }

            if (pedidosActivos[3] == "objR" & !ped4.transform.Find("pedidoObjR(Clone)"))
            {
                GameObject r = Instantiate(ui_objR) as GameObject;
                r.transform.SetParent(ped4.transform, false);
                ped4.GetComponentInChildren<Slider>().maxValue = Random.Range(10, 16);

                lifeF4 = 0;


            }

            if (pedidosActivos[3] == "objA" & !ped4.transform.Find("pedidoObjA(Clone)"))
            {
                GameObject a = Instantiate(ui_objA) as GameObject;
                a.transform.SetParent(ped4.transform, false);
                ped4.GetComponentInChildren<Slider>().maxValue = Random.Range(10, 16);

                lifeF4 = 0;


            }
        }


        //----------------INTERFAZ---------------------------------------------------------------------------------------

        else if (numPlatos.Count > 0)//mientras haya un plato en la lista, seguira instanciando
        {
            //print("no 4");
            tFloat += Time.deltaTime;
            t = (int)tFloat;//tiempo en float

            //contador de 5s para el spawn del plato
            if (t == 5)
            {
                t = 0;
                tFloat = 0f;
                //intentar instanciar un plato encima de otro? si ya hay uno.. 
                
                platos = Instantiate(platoPref, sp.transform.position, platoPref.transform.rotation);
                //platos.gameObject.GetComponent<Rigidbody>().isKinematic = false;
                platos.name = "plato"+p;
                platos.gameObject.GetComponent<Rigidbody>().useGravity = true;
                platos.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None; 
                p++;
                numPlatos.RemoveAt(0);
            }
        }



    }

    private void OnCollisionEnter(Collision col)
    {
        //si colisiona el plato con la entrega
        if (col.transform.tag == "plato")
        {
            numPlatos.Add(col.gameObject.name);
            print("col plato y entrega");

        }

        
        if (col.transform.tag == "objetos")
        {
            cont++;
            coli = col.gameObject.transform.name;//comparar objX que lleva con la lista de pedidos
            coli = coli.Substring(0, coli.Length - 1);//quita el num del obj para poder compararlo con la lista
            coli.ToString();


            detector.objsPlayer.Remove(col.transform.name);//borra el obj con el que colisionaba

            // ENTREGADO BIEN
            //compara el nombre de la colision y si esta en la lista. Y borrarlo de la lista

            if (pedidosActivos.Contains(coli))
            {
               

                print("entregado bien");

                startCont = true;
                numPedidos++;

                //borrar el obj
                Destroy(col.gameObject);
                

                //----------------INTERFAZ---------------------------------------------------------------------------------------
            }
            //ENTREGADO MAL
            else
                //deja el plato y se entrega y todo, pero no suma punto
                print("entregado mal");
                Destroy(col.gameObject);

         
            //ponerlo a cero si es un pedido nuevo
          
            if (pedidosActivos[0] == coli)//ped1
            {
                print("hi");

                float max = ped1.GetComponentInChildren<Slider>().maxValue;
                print(max);
                print(life1);
                //PUNTOS

                puntosLife(life1);


                //100 puntos, si la vida esta entre la mitad y el 100%
                /*if (life1 <=max && life1 >= max/2)
                {
                    print("-puntos");
                    puntos+=50;
                    punticos.text = puntos.ToString();

                }

                //50 puntos, si la vida esta entre el 50% y el 0%
                if (life1 <=max/2 && life1>0)
                {
                    print("+puntos");
                    puntos+=100;
                    punticos.text = puntos.ToString();

                }*/

                //limpiar lista con el nombre que colsiona
                pedidosActivos.Remove(coli);

                print("entregado el primero");//entrega del obj que esta en el ped1


                //borrar la img del obj que se ha entregado
                Destroy(ped1.transform.GetChild(0).gameObject);

                //mover todas las demas imgs a un ped a la  izq
                ped2.transform.GetChild(0).gameObject.transform.SetParent(ped1.transform, false);
                ped3.transform.GetChild(0).gameObject.transform.SetParent(ped2.transform,false);
                ped4.transform.GetChild(0).gameObject.transform.SetParent(ped3.transform,false);



            }

            else if (pedidosActivos[1] == coli)//ped2
            {

                puntosLife(life2);

                //PUNTOS
                /*if (life2 <= 30 && life2 >= 15)//menos puntos, porque tarda en entregarlo
                {
                    print("+puntos");
                    puntos += 100;
                    punticos.text = puntos.ToString();

                }

                if (life1 >= 0 && life1 <= 15)//mas puntos, porque lo entrega pronto
                {
                    print("-puntos");
                    puntos += 50;
                    punticos.text = puntos.ToString();

                }*/

                //limpiar lista con el nombre que colsiona
                pedidosActivos.Remove(coli);

                print("entregado el segundo");//entrega del obj que esta en el ped2

                //borrar la img del obj que se ha entregado
                Destroy(ped2.transform.GetChild(0).gameObject);

                //mover todas las demas imgs a un ped a la  izq
                ped3.transform.GetChild(0).gameObject.transform.SetParent(ped2.transform, false);
                ped4.transform.GetChild(0).gameObject.transform.SetParent(ped3.transform, false);

            }

            else if (pedidosActivos[2] == coli)//ped3
            {

                puntosLife(life3);

                //PUNTOS
                /*if (life3 <= 30 && life3 >= 15)//menos puntos, porque tarda en entregarlo
                {
                    print("+puntos");
                    puntos += 100;
                    punticos.text = puntos.ToString();

                }

                if (life3 >= 0 && life3 <= 15)//mas puntos, porque lo entrega pronto
                {
                    print("-puntos");
                    puntos += 50;
                    punticos.text = puntos.ToString();

                }*/

                //limpiar lista con el nombre que colsiona
                pedidosActivos.Remove(coli);

                print("entregado el tercero");//entrega del obj que esta en el ped3

                //borrar la img del obj que se ha entregado
                Destroy(ped3.transform.GetChild(0).gameObject);

                //mover todas las demas imgs a un ped a la  izq
                ped4.transform.GetChild(0).gameObject.transform.SetParent(ped3.transform, false);

            }

            else if (pedidosActivos[3] == coli)//ped4
            {


                //PUNTOS
                /*if (life4 <= 30 && life4 >= 15)//menos puntos, porque tarda en entregarlo
                {
                    print("+puntos");
                    puntos += 100;
                    punticos.text = puntos.ToString();

                }

                if (life4 >= 0 && life4 <= 15)//mas puntos, porque lo entrega pronto
                {
                    print("-puntos");
                    puntos += 50;
                    punticos.text = puntos.ToString();

                }*/
                puntosLife(life4);

                //limpiar lista con el nombre que colsiona
                pedidosActivos.Remove(coli);

                print("entregado el cuarto");//entrega del obj que esta en el ped4

                //borrar la img del obj que se ha entregado
                Destroy(ped4.transform.GetChild(0).gameObject);

            }
            //----------------INTERFAZ---------------------------------------------------------------------------------------


            
                

        }

        if (col.transform.tag == "plato")
        {
            //borrar el plato, para que lo instancie
            Destroy(col.gameObject);


            //borrar el plato de la lista de col con el detector al entregarlo
            detector.platosPlayer.Remove(col.gameObject.name);



        }

        
    }

    private void OnCollisionExit(Collision col)
    {
        //if (col.transform.tag == "plato" && numPlatos.Count <= 4)
        if (col.transform.tag == "plato")
        {
            numPlatos.Remove(col.gameObject.name);
            //print("col plato exit");

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        
    }


    void reinicioVida()
    {
        //reiniciar vida del que spawnea, dependiendo de la cantidad de pedidos
        if (pedidosActivos.Count == 1)
        {
            lifeF1 = 0;

        }
        if (pedidosActivos.Count == 2)
        {
            lifeF2 = 0;

        }
        if (pedidosActivos.Count == 3)
        {
            lifeF3 = 0;
        }
        if (pedidosActivos.Count == 4)
        {
            lifeF4 = 0;
        }
    }



    //puntos por vida de pedido
    void puntosLife(int l)
    {
        //PUNTOS
        if (l <= 30 && l >= 15)//menos puntos, porque tarda en entregarlo
        {
            print("+puntos");
            puntos += 100;
            punticos.text = puntos.ToString();

        }

        if (l >= 0 && l <= 15)//mas puntos, porque lo entrega pronto
        {
            print("-puntos");
            puntos += 50;
            punticos.text = puntos.ToString();

        }
    }

    /*--------------------------------------BUGS------------------------------------------------
     * 
     * 
     * 
     * 
     * 
     * 
     */




}
