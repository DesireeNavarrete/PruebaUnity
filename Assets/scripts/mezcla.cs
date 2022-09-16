using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mezcla : MonoBehaviour
{
    public string cosa;

    public GameObject ingrediente1,ingrediente2,ingrediente3,ingrediente4,vasoOk;

    public GameObject ui_objAma, ui_objA, ui_objR;//prefabs de las imagenes de los obj para los pedidos

    public int contadorIngredientes;

    public bool vasoPuesto;

    void Start()
    {
        vasoOk.SetActive(false);
        vasoPuesto = false;

    }

    void Update()
    {
        
    }



    private void OnCollisionEnter(Collision other)
    {

        if (other.transform.tag == "objetos")
        {
            cosa = other.transform.name;
            cosa = cosa.Remove(cosa.Length - 1);

            //AÑADIR VASO A LA MEZCLA
            if (cosa == "vaso")
            {
                print("vasito");
                vasoPuesto = true;
                //other.collider.enabled = false;
                vasoOk.SetActive(true);
            }


            //AÑADIR INGREDIENTES A MEZCLA
            if (cosa == "objAma")//activar la imagen del objAma
            {

                print("amarillito");
                contadorIngredientes++;
                GameObject v = Instantiate(ui_objAma) as GameObject;
                other.collider.enabled = false;
                Destroy(other.gameObject,5);

                //hacerlo pequeño y que se ponga arriba a la derecha
                if (contadorIngredientes == 1)
                {
                    v.transform.SetParent(ingrediente1.transform, false);

                }

                if (contadorIngredientes == 2)
                {
                    v.transform.SetParent(ingrediente2.transform, false);

                }

                if (contadorIngredientes == 3)
                {
                    v.transform.SetParent(ingrediente3.transform, false);
                }

                if (contadorIngredientes == 4)
                {
                    v.transform.SetParent(ingrediente4.transform, false);

                }
            }

           
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.transform.tag == "objetos")
        {
        }
    }

    void vaciarMesaMezcla()
    {
        contadorIngredientes = 0;

        //borrar de la UI los ingredientes puestos
        Destroy(ingrediente1.transform.GetChild(0).gameObject);
        Destroy(ingrediente2.transform.GetChild(0).gameObject);
        Destroy(ingrediente3.transform.GetChild(0).gameObject);
        Destroy(ingrediente4.transform.GetChild(0).gameObject);
    }
}
