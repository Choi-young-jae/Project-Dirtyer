using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;				

public class GetpointScript : MonoBehaviour {

    public static GetpointScript getpointscript = null;
    public int score;
    static public Text scoretext;
    public Transform textprefap;
    public bool increasescore = true;
    public GameObject endui;
    static public bool printtext = true;
	// Update is called once per frame
    void Awake()
    {
        getpointscript = this;
    }
    void Start()
    {
        score = 0;
        scoretext = GameObject.Find("scoreText").GetComponent<Text>();
        scoretext.text = "Score : " + score;
    }

	void OnTriggerEnter(Collider coll)
    {
        if (coll.transform.tag != "Small_Object")
            return;
        //만약에 점수판정 범위에 작은물체가 들어올 경우
        if (coll.transform.tag == "Small_Object") 
        {
            //태그에 따라서 점수를 증가시켜 준다.
            IncreseScore(coll.transform.position, coll.transform.tag);
            //이미 점수 체크가 끝난 것으로 수정한다.
            coll.transform.tag = "Object";
        }
    }

    public void IncreseScore(Vector3 pos,string tagname)
    {
        //태그에 따라서 다른 점수를 부여한다.
        //총알 : 200, 큰물체(책상,의자..) : 150, 작은물체(책,노트북..) : 100
        //큰 물체와 총알은 외부에서 이 함수를 호출하여 사용한다.
        //왜냐하면 큰 물체는 처음부터 점수체크 범위 안에 있으므로
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
            default:
                break;
        }
    }

    void addscore(Vector3 pos, int point,Transform textprefap)
    {
        if (!this.GetComponent<BoxCollider>().enabled)
            return;

        score += point;
        //옵션으로 점수 텍스트를 출력할지 말지를
        //결정 할 수 있도록 하였다.
        if (!printtext)
        {
            return;
        }
        //충돌한 물체의 위치에 점수 텍스트를 출력해준다.
        Quaternion resetrotatte = new Quaternion();
        resetrotatte.eulerAngles = new Vector3(0, 0, 0);
        Transform obj = Instantiate(textprefap, pos, resetrotatte) as Transform;
        obj.GetComponent<TextMesh>().text = "+" + point;
        scoretext.text = "Score : " + score;

    }
	public IEnumerator checkscore()
    {
        //게임이 끝났는지 아닌지 판정해 주는 함수이다.
        //총알을 쏘고 난 뒤에 코루틴으로 호출된다.
        int currentscore;
        while (true)
        {
            currentscore = score;
            yield return new WaitForSeconds(3.0f);
            //3초간 점수가 증가하지 않았다면 게임이 끝났것으로 판정한다.
            if (currentscore == score)
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
