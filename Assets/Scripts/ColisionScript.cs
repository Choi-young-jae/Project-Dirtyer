using UnityEngine;
using System.Collections;

public class ColisionScript : MonoBehaviour {

    void OnTriggerEnter(Collider coll)
    {
        if (coll.transform.tag == "Bullet")
        {
            this.GetComponent<BoxCollider>().isTrigger = false;
            return;
        }

        if (coll.transform.tag == "Border" || coll.transform.tag == "Small_Object") return;

        Debug.Log(coll.transform.tag + " / " +  coll.GetComponent<BoxCollider>().isTrigger);
        

        if (coll.GetComponent<BoxCollider>().isTrigger == false)
        {
            coll.GetComponent<BoxCollider>().isTrigger = true;
            this.GetComponent<BoxCollider>().isTrigger = false;
        }
    }
}
