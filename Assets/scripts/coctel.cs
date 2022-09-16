using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class coctel : MonoBehaviour
{
    public static string[] bebidas = { "morado", "naranja", "verde" };
    public string[] decoracion = { "pajita", "sombrilla", "objR" };
    public string[] ingredientes = { "objA", "objAma", "objR" };
    public string[] frutillas = { "naranja", "cereza", "pepino" };




    public static List<string> pedActivos2 = new List<string>();



    void Start()
    {
        //list.Add(array[Random.RandomRange(0, 3)]);


    }


    private void Update()
    {

        //print(pedActivos1[0]);

        //contador de tiempo para el pedido del cli1
        /*if (trigCli.cli1)
        {
            //contt_1 += Time.deltaTime;
            //contt1 = (int)contt_1;


        }

        //contador de tiempo para el pedido del cli2
        if (trigCli2.cli2)
        {
            //contt_2 += Time.deltaTime;
            //contt2 = (int)contt_2;


        }


        /*if (trigCli.cli1 && pedActivos.Count == 0)//si hay un cliente en la primera mesa
        {
            //print("cli1");

            if (contt1 == 3)//3s despues de que el cli1 llegue al trigger
            {
                //añade pedido en la primera mesa
                //añadir varios o no, para que algunos clientes puedan hacer varios

                for (int i = 0; i < Random.RandomRange(2, 6); i++)
                {
                    pedActivos.Add(bebidas[Random.RandomRange(0, 3)]);

                }
            }

        }



        if (trigCli2.cli2 && pedActivos2.Count == 0)//si hay un cliente en la segunda mesa
        {
            //print("cli2");



            if (contt2 == 3)//3s despues de que el cli2 llegue al trigger
            {
                //añade pedido en la segunda mesa
                for (int i = 0; i < Random.RandomRange(2, 6); i++)
                {
                    pedActivos2.Add(bebidas[Random.RandomRange(1, 3)]);

                }
            }

        }*/
    }
}
