using UnityEngine;
using System.Collections;

public class ColisionScript_ani : MonoBehaviour {
    
    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();    
    }
    void OnTriggerEnter(Collider coll)
    {
        if (coll.transform.tag == "Bullet")
        {
            Debug.Log("Break start");
            this.GetComponent<BoxCollider>().isTrigger = false;
            anim.SetBool("Break", true);
            return;
        }

        if (coll.transform.tag == "Border" || coll.transform.tag == "Small_Object") return;

        Debug.Log(coll.transform.tag + " / " + coll.GetComponent<BoxCollider>().isTrigger);


        if (coll.GetComponent<BoxCollider>().isTrigger == false)
        {
            coll.GetComponent<BoxCollider>().isTrigger = true;
            this.GetComponent<BoxCollider>().isTrigger = false;
        }
    }
}
