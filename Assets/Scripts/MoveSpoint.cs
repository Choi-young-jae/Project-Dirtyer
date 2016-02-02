using UnityEngine;
using System.Collections;

public class MoveSpoint : MonoBehaviour {

    public GameObject mainshoot; //현재 발사를 할 객체
    public Transform bullet; //포탄 프리팹
    Transform spPoint; //발사 되는 위치
    public int power = 1800;

    int rotspeed = 120; //회전 속도

    void Start()
    {
        spPoint = GameObject.Find("Spanpoint").transform;
    }
	// Update is called once per frame
	void Update () {
        float amtRot = rotspeed * Time.smoothDeltaTime; //부드러운 회전을 위해

        float keyRot = Input.GetAxis("Vertical");

        mainshoot.transform.Rotate(Vector3.right * keyRot * 4);

        //회전각의 제한을 줌
        Vector3 ang = mainshoot.transform.eulerAngles;
        if (ang.x > 180) ang.x -= 360;
        ang.x = Mathf.Clamp(ang.x, -80, 80);
        mainshoot.transform.eulerAngles = ang;

        if(Input.GetButtonDown("Fire1"))
        {
            FireBullet();
        }
	}

    void FireBullet()
    {
        Transform obj = Instantiate(bullet, spPoint.position, spPoint.rotation) as Transform;
        obj.GetComponent<Rigidbody>().AddForce(spPoint.forward * power);
    }
}
