using UnityEngine;
using System.Collections;

using System.Collections.Generic;		//Allows us to use Lists. 
using UnityEngine.UI;					//Allows us to use UI.

public class ColisionScript : MonoBehaviour {

    public Transform textprefap;

    //private GetpointScript getpoint;
    void Start()
    {
        Debug.Log("Start Program");
    }
    void OnTriggerEnter(Collider coll)
    {
        if (coll.transform.tag == "Bullet")
        {
            this.GetComponent<BoxCollider>().isTrigger = false;

            GetpointScript.addscore(this.GetComponent<Transform>().position, 200, textprefap);
            return;
        }

        if (coll.transform.tag == "Border" || coll.transform.tag == "Small_Object") return;

        Debug.Log(coll.transform.tag + " / " +  coll.GetComponent<BoxCollider>().isTrigger);


        if (coll.GetComponent<BoxCollider>().isTrigger == false && coll.transform.tag=="Big_Object")
        {
            coll.GetComponent<BoxCollider>().isTrigger = true;
            GetpointScript.addscore(this.GetComponent<Transform>().position, 150, textprefap);
            this.GetComponent<BoxCollider>().isTrigger = false;
        }
    }
}
