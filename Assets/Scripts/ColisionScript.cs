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
        if (coll.transform.tag == "Border" || coll.transform.tag == "Small_Object"
            || coll.transform.tag =="Untagged") return;
        //만약에 탄환과 충돌하였을 경우
        if (coll.transform.tag == "Bullet")
        {
            //isTrigger를 false로 바꿔줌으로써 충돌 영역을 활성화 시킨다.
            this.GetComponent<BoxCollider>().isTrigger = false;
            //현재 물체의 무게가 30보다 클 경우엔 1로 만들어 주고
            float currentmass = this.GetComponent<Rigidbody>().mass;
            if (currentmass > 30.0f) this.GetComponent<Rigidbody>().mass = 1;
            else this.GetComponent<Rigidbody>().mass = 100;//아닐 경우에는 100으로 만들어준다.
            //물체의 Colider를 미리 물체보다 크게 설정을 한 뒤 총알과 닿을 경우 이를 활성화 하여
            //물체가 펑펑 터지는 듯 하게 보이기 위한 코드이다.

            coll.GetComponent<CapsuleCollider>().isTrigger = false;
            //충돌영역 활성화 후 태그를 바꿔줌으로써 두번 이상 총알과의 충돌이 검출되지 않도록 한다.
            this.transform.tag = "Object";
            //총알의 태그를 바꿔줌으로써 다른 물체들과의 충돌이 두번 이상 검출 되지 않도록 한다.
            coll.transform.tag = "Untagged";
            //총알이 충돌하였을 경우에는 200점을 추가해준다.
            GetpointScript.getpointscript.IncreseScore(this.GetComponent<Transform>().position, "Bullet");
            return;
        }
        //충돌이 1회이상 검출된 물체와 충돌하였을 경우
        else if (coll.transform.tag == "Object")
        {
            //충돌해온 물체의 isTrigger를 비활성화 시키고
            coll.GetComponent<BoxCollider>().isTrigger = true;
            //점수를 더해준다.
            GetpointScript.getpointscript.IncreseScore(this.GetComponent<Transform>().position, "Big_Object");
            //현재 충돌한 물체의 isTrigger를 활성화 시킨다.
            this.GetComponent<BoxCollider>().isTrigger = false;
            //Trigger를 조절해 줌으로써 충돌이 확산 되는 듯한 효과를 주게 된다.
            //이미 충돌이 끝난 것으로 표기해준다.
            this.transform.tag = "Object";
        }
    }
}
