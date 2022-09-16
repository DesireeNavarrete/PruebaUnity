using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnClis : MonoBehaviour
{
    public GameObject cliPrefab;
    public int maxCliCola;
    GameObject cli;
    public int t;
    float tFloat;
    public List<string> colaClis = new List<string>();
    public GameObject[] clis;



    void Start()
    {
        //cli = Instantiate(cliPrefab, gameObject.transform.GetChild(0).position, Quaternion.Euler(0,90,0)) as GameObject;
        // cli.transform.SetParent(gameObject.transform.GetChild(0));
        maxCliCola = gameObject.transform.childCount;

    }


    void Update()
    {
        //
        //if(colaClis.Count > 0 && colaClis.Count <= maxCliCola)
        //if(clis.Length > 0 && clis.Length <= maxCliCola)
        if(clis.Length > 0 && clis.Length <= maxCliCola)
        {
            tFloat += Time.deltaTime;
            t = (int)tFloat;

            //if (t == 5)
            //{
                t = 0;
            if (clis.Length==1 && gameObject.transform.GetChild(0).childCount == 0)
            {
                    cli.transform.SetParent(gameObject.transform.GetChild(0));
                    print("cli1");
                    cli.transform.position = gameObject.transform.GetChild(0).transform.position;

                //cli = Instantiate(cliPrefab, gameObject.transform.GetChild(0).position, Quaternion.Euler(0, 90, 0)) as GameObject;
            }

            if (clis.Length == 2 && gameObject.transform.GetChild(1).childCount == 0)
            {
                    cli.transform.SetParent(gameObject.transform.GetChild(1));
                    print("cli2");
                    cli.transform.position = gameObject.transform.GetChild(1).transform.position;

                //cli = Instantiate(cliPrefab, gameObject.transform.GetChild(1).position, Quaternion.Euler(0, 90, 0)) as GameObject;
            }

            if (clis.Length == 3 && gameObject.transform.GetChild(2).childCount == 0)
            {
                    cli.transform.SetParent(gameObject.transform.GetChild(2));
                    print("cli3");
                    cli.transform.position = gameObject.transform.GetChild(2).transform.position;
           
            }
            //}
        print("estamos gucci");
        }

        //lista de clis en la escen
        clis = GameObject.FindGameObjectsWithTag("cli");




        
    }

    public void clisAñadir()
    {

        //cli = Instantiate(cliPrefab, gameObject.transform.position, Quaternion.Euler(0, 90, 0)) as GameObject;
        if (clis.Length == 0)
        {
            //cli.transform.SetParent(gameObject.transform.GetChild(0));
            //cli.transform.position = gameObject.transform.GetChild(0).transform.position;

            cli = Instantiate(cliPrefab, gameObject.transform.GetChild(0).position, Quaternion.Euler(0, 90, 0)) as GameObject;
            //cli.transform.SetParent(gameObject.transform.GetChild(0));

        }

        if (clis.Length == 1)
        {
            //cli.transform.SetParent(gameObject.transform.GetChild(1));
            //cli.transform.position = gameObject.transform.GetChild(0).transform.position;

            cli = Instantiate(cliPrefab, gameObject.transform.GetChild(1).position, Quaternion.Euler(0, 90, 0)) as GameObject;
        }

        if (clis.Length == 2)
        {
            //cli.transform.SetParent(gameObject.transform.GetChild(2));
            //cli.transform.position = gameObject.transform.GetChild(1).transform.position;
            cli = Instantiate(cliPrefab, gameObject.transform.GetChild(2).position, Quaternion.Euler(0, 90, 0)) as GameObject;
        }

        /*if (clis.Length <= 3 && gameObject.transform.GetChild(2).childCount == 0)
        {
            cli.transform.SetParent(gameObject.transform.GetChild(2));
            //cli = Instantiate(cliPrefab, gameObject.transform.GetChild(2).position, Quaternion.Euler(0, 90, 0)) as GameObject;

        }*/
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "cli")
        {
            //numPlatos.Add(col.gameObject.name);
            //colaClis.Add(other.gameObject.name);

            print("cliiiiii");

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "cli")
        {
            //numPlatos.Add(col.gameObject.name);
            //colaClis.Remove(other.gameObject.name);

            //print("cliiiiii");

        }
    }
}
