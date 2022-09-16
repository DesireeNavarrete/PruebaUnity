using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class entregaPed : MonoBehaviour
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
    public string[] objsArray = {"objA", "objAma", "objR"};
    public static List<string> pedidosActivos1 = new List<string>();
    public static List<string> pedidosActivos2 = new List<string>();
    string coli; //para la col del obj de entrega

    //public bool entregado, platoEntrega;
    public static bool start;//para que empiece el crono


    public GameObject ped1, ped2, ped3,ped4;//canvas pedidos
    public GameObject ui_morado,ui_verde,ui_naranja;//prefabs de las imagenes de los obj para los pedidos

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

    public int contt1 = 0;
    float contt_1 = 0;

    public int contt2 = 0;
    float contt_2 = 0;
    
    private void Awake()
    {
        ped1.SetActive(false);
        ped2.SetActive(false);
        ped3.SetActive(false);
        ped4.SetActive(false);
    }

    void Start()
    {




        /* t = 0;//tiempo en int

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

         */
        start = true;


    }
    /*class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    Person[] people = {
        new Person(){ FirstName="Steve", LastName="Jobs"},
        new Person(){ FirstName="Bill", LastName="Gates"},
        new Person(){ FirstName="Lary", LastName="Page"}
    };

    class PersonComparer : IComparer
    {
        public int Compare(object x, object y)
        {
    	return (new CaseInsensitiveComparer()).Compare(((Person)x).LastName, ((Person)y).LastName);
           
        }
    }*/








    void Update()
    {

        //tiempo de partida
        if (start)
        {
            //tiempo de partida
            tiempoPartF += Time.deltaTime;
            tiempoPart = (int)tiempoPartF;
        }

        //print(ped1.transform.GetChild(0).ToString());
        //print("pedActivos1: " + coctel.pedActivos1.Count);
        //print("pedActivos2: " + coctel.pedActivos2.Count);
        
        //contador de tiempo para el pedido del cli1
        /*if (trigCli1.entregadoCli1)
        {
            contt_1 += Time.deltaTime;
            contt1 = (int)contt_1;
            print("contador start");

            if(contt1 == 1)
            {
                print("entregao");
                //se elimina el entregado del canvas
                Destroy(ped1.transform.GetChild(0).gameObject);


            }

            if (contt1 > 1 && contt1 < 7)
            {
                print("quita ui");
                ped1.transform.GetChild(0).gameObject.SetActive(false);

            }

            //se espera 7s para poner el siguiente ped, poner en aleatorio entre 4 y 10 por ejemplo?¿?¿?¿?

            if (contt1 == 7)
            {
                //eliminar el pedido de la lista para que spwnee el siguiente

                print("sale ui");
                //ped1.transform.GetChild(0).gameObject.SetActive(true);
                coctel.pedActivos1 .RemoveAt(0);
                trigCli1.entregadoCli1 = false;
                contt1 = 0;
                contt_1 = 0;
            }



        }



        //contador de tiempo para el pedido del cli2
        if (trigCli2.entregadoCli2)
        {
            contt_2 += Time.deltaTime;
            contt2 = (int)contt_2;

            if (contt2 == 1)
            {
                print("entregao");
                //se elimina el entregado del canvas
                Destroy(ped2.transform.GetChild(0).gameObject);
            }
        }

        if (contt2 >1 && contt2<7)
        {
            ped2.transform.GetChild(0).gameObject.SetActive(false);

        }

        //se espera 7s para poner el siguiente ped, poner en aleatorio entre 4 y 10 por ejemplo?¿?¿?¿?
        if (contt2 == 7)
        {
            //eliminar el pedido de la lista para que spwnee el siguiente
            coctel.pedActivos2.RemoveAt(0);
            trigCli2.entregadoCli2 = false;
            contt2 = 0;
            contt_2 = 0;
            
        }*/


        //---------------- VIDA ---------------------------------------------------------------------------------------

        //VIDA PED1
        /*if (ped1.transform.childCount == 1)
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

        if (vida1)//cuando se acaba la vida
        {
            Destroy(ped1.transform.GetChild(0).gameObject);
            coctel.pedActivos1.RemoveAt(0);
            vida1 = false;

        }*/

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
            coctel.pedActivos2.RemoveAt(0);
            vida2 = false;

        }

        //---------------- UI PEDIDOS ---------------------------------------------------------------------------------------

        //si hay pedidos para el cliente1, pone la imagen del coctel que toca
       /* if (coctel.pedActivos1.Count >=1)
        {
            ped1.SetActive(true);



            if (coctel.pedActivos1[0] == "morado" && !ped1.transform.Find("pedidoMorado(Clone)"))
            {
                GameObject x = Instantiate(ui_morado) as GameObject;
                x.transform.SetParent(ped1.transform, false);
                ped1.GetComponentInChildren<Slider>().maxValue = Random.Range(30,31);
                lifeF1 = 0;
            }

            if (coctel.pedActivos1[0] == "naranja" && !ped1.transform.Find("pedidoNaranja(Clone)"))
            {
                
                GameObject x = Instantiate(ui_naranja) as GameObject;
                x.transform.SetParent(ped1.transform, false);
                ped1.GetComponentInChildren<Slider>().maxValue = Random.Range(30, 31);

                lifeF1 = 0;

            }

            if (coctel.pedActivos1[0] == "verde" && !ped1.transform.Find("pedidoVerde(Clone)"))
            {
                
               GameObject x = Instantiate(ui_verde) as GameObject;
               x.transform.SetParent(ped1.transform, false);
               ped1.GetComponentInChildren<Slider>().maxValue = Random.Range(30, 31);

               lifeF1 = 0;

            }
        }*/
        
        //si hay pedidos para el cli2, pone la imagen del coctel que toca
        if (coctel.pedActivos2.Count >= 1 )
        {

            ped2.SetActive(true);

            if (coctel.pedActivos2[0] == "morado" && !ped2.transform.Find("pedidoMorado(Clone)"))
            {
                GameObject x = Instantiate(ui_morado) as GameObject;
                x.transform.SetParent(ped2.transform, false);
                ped2.GetComponentInChildren<Slider>().maxValue = Random.Range(30, 31);
                lifeF2 = 0;
            }

            if (coctel.pedActivos2[0] == "naranja" && !ped2.transform.Find("pedidoNaranja(Clone)"))
            {

                GameObject x = Instantiate(ui_naranja) as GameObject;
                x.transform.SetParent(ped2.transform, false);
                ped2.GetComponentInChildren<Slider>().maxValue = Random.Range(30, 31);

                lifeF2 = 0;

            }

            if (coctel.pedActivos2[0] == "verde" && !ped2.transform.Find("pedidoVerde(Clone)"))
            {

                GameObject x = Instantiate(ui_verde) as GameObject;
                x.transform.SetParent(ped2.transform, false);
                ped2.GetComponentInChildren<Slider>().maxValue = Random.Range(30, 31);

                lifeF2 = 0;

            }

        }
        /*  

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

                }

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

                }

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

                }

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

                }
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
        */
    }
    
       


    }
