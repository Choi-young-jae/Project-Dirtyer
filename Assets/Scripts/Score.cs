using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {

	// Use this for initialization
	void Start () {
        StartCoroutine("DisplayScore");
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 pos = transform.position;
        pos.y += 0.01f;
        transform.position = pos;
	}

    IEnumerator DisplayScore()
    {
        yield return new WaitForSeconds(0.5f);

        for(float a = 1; a >=0; a -=0.2f)
        {
            transform.GetComponent<TextMesh>().color = new Vector4(1, 1, 1, a);
            yield return new WaitForFixedUpdate();
        }
        Destroy(gameObject);
    }
}
