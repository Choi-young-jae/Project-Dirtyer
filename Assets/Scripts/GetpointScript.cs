using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;				

public class GetpointScript : MonoBehaviour {

    static public int score;
    static public Text scoretext;
    public Transform textprefap;
    public bool increasescore = true;
    public GameObject endui;
	// Update is called once per frame
    void Start()
    {
        score = 0;
        scoretext = GameObject.Find("scoreText").GetComponent<Text>();
        scoretext.text = "Score : " + score;
    }
	void OnTriggerEnter(Collider coll)
    {
        if (coll.transform.tag == "Small_Object" || coll.transform.tag == "Bullet") 
        {
            IncreseScore(coll.transform.position, coll.transform.tag);
            coll.transform.tag = "Object";
            Debug.Log(score);
        }
    }

    public void IncreseScore(Vector3 pos,string tagname)
    {
        switch(tagname)
        {
            case "Small_Object":
                addscore(pos, 100, textprefap);
                break;
            case "Big_Object":
                addscore(pos, 150, textprefap);
                break;
            case "Bullet":
                addscore(pos, 200, textprefap);
                break;
        }

        if(increasescore)
        {
            increasescore = false;
            StartCoroutine(checkscore());
        }

    }
    static public void addscore(Vector3 pos, int point,Transform textprefap)
    {
        score += point;
        Quaternion resetrote = new Quaternion();
        resetrote.SetEulerAngles(new Vector3(0, 0, 0));

        Transform obj = Instantiate(textprefap, pos, resetrote) as Transform;
        //obj.GetComponent<Transform>().rotation = new Vector3(0, 0, 0);
        obj.GetComponent<TextMesh>().text = "+" + point;
        Debug.Log(GetpointScript.score);

        scoretext.text = "Score : " + score;

    }
	IEnumerator checkscore()
    {
        int currentscore;
        while (true)
        {
            currentscore = score;
            yield return new WaitForSeconds(3.0f);

            if (currentscore != 0 && currentscore == score)
            {
                endui.SetActive(true);
                this.GetComponent<BoxCollider>().enabled = false;
            }

        }
    }

    public void backtostatesel()
    {
        SceneManager.LoadScene(1);
    }
}
