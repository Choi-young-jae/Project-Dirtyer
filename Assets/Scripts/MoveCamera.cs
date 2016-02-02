using UnityEngine;
using System.Collections;

public class MoveCamera : MonoBehaviour {

    public float movespeed = 0.1f;
    public float rotationspeed = 1.0f;
    public float smooth = 2.0F;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        float amtMove = movespeed * Time.smoothDeltaTime;

        Vector3 movepos;
        movepos.x = 0;
        movepos.y = 0;
        movepos.z = 0;
        Vector3 rotationpos;
        rotationpos.x = 0.0f;
        rotationpos.y = 1.0f;
        rotationpos.z = 0.0f;

        if(Input.GetKey(KeyCode.W))
        {
            movepos.z = movespeed;
        }
        if (Input.GetKey(KeyCode.S))
        {
            movepos.z = -movespeed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            movepos.x = movespeed;
        }
        if (Input.GetKey(KeyCode.A))
        {
            movepos.x = -movespeed;
        }
        if(Input.GetKey(KeyCode.Q))
        {
            float tiltAroundY = rotationspeed;
            //Quaternion target = Quaternion.Euler(0, tiltAroundY,0 );
            //transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
            transform.Rotate(rotationpos, tiltAroundY);

        }
        if (Input.GetKey(KeyCode.E))
        {
            float tiltAroundY = -rotationspeed;
            //Quaternion target = Quaternion.Euler(0, tiltAroundY, 0);
            //transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
            transform.Rotate(rotationpos, tiltAroundY);
        }
        transform.Translate(movepos);
	}
}
