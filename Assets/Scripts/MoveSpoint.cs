﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;	

public class MoveSpoint : MonoBehaviour {

    public GameObject mainshoot; //현재 발사를 할 객체
    public Transform bullet; //포탄 프리팹
    Transform spPoint; //발사 되는 위치
    private int power = 0;
    private bool keypressed = false;
    private Text powertext;

    int rotspeed = 120; //회전 속도

    void Start()
    {
        spPoint = GameObject.Find("Spanpoint").transform;
        powertext = GameObject.Find("powerText").GetComponent<Text>();
        powertext.text = "Power : " + power;

    }
	// Update is called once per frame
	void Update () {
        float amtRot = rotspeed * Time.smoothDeltaTime; //부드러운 회전을 위해
        Vector3 ang = mainshoot.transform.eulerAngles;

        float keyRot = Input.GetAxis("Vertical");
        float keyLR = Input.GetAxis("Horizontal");

        mainshoot.transform.Rotate(Vector3.right * keyRot * 4);
        this.transform.Rotate(Vector3.up * keyLR * 4);

        if (mainshoot.transform.eulerAngles.x > 45 &&  mainshoot.transform.eulerAngles.x<330)
            mainshoot.transform.eulerAngles = ang;
        //회전각의 제한을 줌
        
        /*if (ang.x > 180) ang.x -= 360;
        ang.x = Mathf.Clamp(ang.x, -80, 80);
        mainshoot.transform.eulerAngles = ang;*/
        if (Input.GetButtonDown("Fire1"))
        {
            keypressed = true;
            //StartCoroutine(addPower());
        }
        if(Input.GetButtonUp("Fire1"))
        {
            keypressed = false;
            FireBullet();
        }
        if(keypressed)
        {
            power += 50;
            powertext.text = "Power : " + power;
        }
	}

    void FireBullet()
    {
        Debug.Log(power);
        Transform obj = Instantiate(bullet, spPoint.position, spPoint.rotation) as Transform;
        obj.GetComponent<Rigidbody>().AddForce(spPoint.forward * power);
        power = 0;
    }
    IEnumerator addPower()
    {
        while (power > 3000 && keypressed)
        {
            //    0.1초마다 반복
            yield return new WaitForSeconds(0.1f);
            Debug.Log(power);
            //    텍스쳐 배열의 인덱스값의 텍스쳐를 시작 텍스쳐로 넣음.
            power += 100;
        }
    }

}
