using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trigCli2 : MonoBehaviour
{

    public static bool cli2;
    public string cosa;

    public static bool entregadoCli2;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //print(entregaPed.pedidosActivos2[0]);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "cli")
        {
            cli2 = true;
            other.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;

            if (coctel.pedActivos2.Count == 0)
            {
                print("no ped cli2");
            }
        }
    }
    

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "cli")
        {
            cli2 = false;
        }
    }

    private void OnCollisionEnter(Collision col)
    {
        //entrega de pedido del cliente2
        if (col.transform.tag == "objetos")
        {
            print("col plato+objeto" + col.transform.name);
            cosa = col.transform.name;
            cosa = cosa.Remove(cosa.Length - 1);

            if (cosa == coctel.pedActivos2[0])
            {
                //print("entregado baby al cli2");

                //eliminar el obj entregado del canvas
                entregadoCli2 = true;
                //coctel.pedActivos1.RemoveAt(0);
                col.collider.enabled = false;
                Destroy(col.gameObject, 5);

            }
        }

    }

    private void OnCollisionExit(Collision col)
    {
        if (col.transform.tag == "objetos")
        {
            entregadoCli2 = false;

        }
    }
}
