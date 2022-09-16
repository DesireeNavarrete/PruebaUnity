using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    //public Canvas canvasito;
    public Text segText,minText;
    public static float timer,min,seg,tiempoReal;
    public GameObject panelFinTiempo;
    GameObject pj;


    public static bool start;
    public int tiempoPart;
    public float tiempoPartF;

    void Start()
    {
        // segText = canvasito.GetComponentInChildren<Text>();
        // minText = canvasito.GetComponentInChildren<Text>();
        //timertext.text = timer.ToString();
        //timer = 2.5f;
        pj = GameObject.FindGameObjectWithTag("Player");
        timer *= 60;
        seg = 30;
        min = 2;
        tiempoReal = 0;
        panelFinTiempo.SetActive(false);

        if (timer / 60 == 0)
        {

        }
    }

    void Update()
    {

        if (start)
        {
            //tiempo de partida
            tiempoPartF += Time.deltaTime;
            tiempoPart = (int)tiempoPartF;
        }


        if (start)
        {
            //cuenta atras 2min 30s
            seg -= Time.deltaTime;
            tiempoReal += Time.deltaTime;
            segText.text = seg.ToString();
            segText.text = string.Format("{0:#00}", seg);
            minText.text = min.ToString();
            minText.text = string.Format("{0:#0}", min);

            if (segText.text == "-01")
            {
                min--;
                seg = 60;

            }
            if (minText.text == "0" && segText.text == "00")
            {
                //print("sacabo");
                min = 0;
                seg = 00;
                panelFinTiempo.SetActive(true);
                Time.timeScale = 0;
                //player1.quieto();
            }

            /*
             if (segText.text == "-01")
            {
                min -= 1;
                print("seg=0");
                seg = 05;

                if(minText.text == "0")
                {
                    print("sacabo");
                }
            }
            */
        }
    }
}
