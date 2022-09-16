using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pedidos1 : MonoBehaviour
{
/*---------------------------AÑADIR/ARREGLAR-------------------------------------
 *    
 *      
 *  
 *      
 * 
 * 
 * 
 */
    public List<objetos> pedObj;
    public List<GameObject> listObj;
    public List<string> objsLista;

    public GameObject obj1, obj2, obj3;

    public int numPedidos=0;
    public int cantObjList;
    public int queObjsLista;

    void Start()
    {

        objsLista.Add("objV");
        objsLista.Add("objR");
        objsLista.Add("objA");

        cantObjList = Random.RandomRange(0, 3);
        queObjsLista = Random.RandomRange(0, 3);

        //devuelve el obj de  la lista al que pertenece el random
        objsLista[queObjsLista].ToString();
        print(objsLista[queObjsLista]);
        


        if (numPedidos==0)
        {
            print("no hay pedidos");
            //primer pedido autom
            numPedidos++;
                List<string> ped1;
                //ped1.Add(objsLista[queObjsLista].ToString());

            //segundo pedido autom
            numPedidos++;
                List<string> ped2;

        }
    }

    void Update()
    {

        print("objs: "+queObjsLista);
        print("cantidad: "+cantObjList);


    }
}
