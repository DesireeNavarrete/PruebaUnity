using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class follow : MonoBehaviour
{
    GameObject pj,w,a,s,d,wd,wa,sa,sd;
    Vector3 offset,offset2,offset3,offset4;

    void Start()
    {
        pj = GameObject.FindGameObjectWithTag("Player");
        w = GameObject.FindGameObjectWithTag("w");
        a = GameObject.FindGameObjectWithTag("a");
        s = GameObject.FindGameObjectWithTag("s");
        d = GameObject.FindGameObjectWithTag("d");
        wd = GameObject.FindGameObjectWithTag("w-d");
        wa = GameObject.FindGameObjectWithTag("w-a");
        sa = GameObject.FindGameObjectWithTag("s-a");
        sd = GameObject.FindGameObjectWithTag("s-d");
        offset = wd.transform.position - pj.transform.position;
        offset2 = wa.transform.position - pj.transform.position;
        offset3 = sa.transform.position - pj.transform.position;
        offset4 = sd.transform.position - pj.transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        //hor
        a.transform.position = new Vector3(a.transform.position.x, a.transform.position.y, pj.transform.position.z);
        d.transform.position = new Vector3(d.transform.position.x, d.transform.position.y, pj.transform.position.z);

        //ver
        w.transform.position = new Vector3(pj.transform.position.x, w.transform.position.y, w.transform.position.z);
        s.transform.position = new Vector3(pj.transform.position.x, s.transform.position.y, s.transform.position.z);

        //diagonal
        //arriba-derecha
        wd.transform.position = new Vector3(pj.transform.position.x + offset.x, wd.transform.position.y, pj.transform.position.z + offset.z);
        //arriba-izquierda
        wa.transform.position = new Vector3(pj.transform.position.x + offset2.x, wa.transform.position.y, pj.transform.position.z + offset2.z);
        //abajo-izquierda
        sa.transform.position = new Vector3(pj.transform.position.x + offset3.x, sa.transform.position.y, pj.transform.position.z + offset3.z);
        //abajo-derecha
        sd.transform.position = new Vector3(pj.transform.position.x + offset4.x, sd.transform.position.y, pj.transform.position.z + offset4.z);
    }
}
