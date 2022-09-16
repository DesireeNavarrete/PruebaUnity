using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pedidos : MonoBehaviour
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
    public int numPedidos=0;
    public int objsPed1,objsPed2, objsPedRnm;
    public string[] objsArray= {"objA","objV","objR"};
    public List<string> pedidosActivos = new List<string>();


    void Start()
    {
        objsPed1= Random.RandomRange(0, 3);
        objsPed2= Random.RandomRange(0, 3);

        numPedidos = 2;
    }

    void Update()
    {
        
        for(int i=0;i< objsArray.Length; i++)
        {
            print(objsArray[objsPed1]);
            print(objsArray[objsPed2]);
        }
            pedidosActivos.Add(objsArray[objsPed1]);
            pedidosActivos.Add(objsArray[objsPed2]);

        //cada Xseg un aleatorio
    }
}
