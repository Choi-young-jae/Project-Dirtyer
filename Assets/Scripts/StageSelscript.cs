using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StageSelscript : MonoBehaviour {

    private int currentpage = 0;
    private int stagenum;
    private bool ploge = false;
    private int endpage = 3;
    public Text storytext;
    public GameObject nextscen;
    public GameObject selectstagebutton;

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if(ploge)
        {
            if(Input.GetKeyDown(KeyCode.Space))
                printstory();
        }
	
	}

    public void stageselect(int selnum)
    {
        stagenum = selnum;
        ploge = true;
        selectstagebutton.SetActive(false);
        printstory();
    }
    void printstory1(int curapge)
    {
        

        switch(curapge)
        {
            case 0:
                storytext.text = "안녕하세요";
                break;
            case 1:
                storytext.text = "게임이에요";
                break;
            case 2:
                storytext.text = "글자에요";
                break;
            case 3:
                storytext.text = "잘가요";
                break;
            default:
                break;
        }

        if (curapge == endpage)
        {
            ploge = false;
            nextscen.SetActive(true);
        }
    }
    void printstory2(int curapge)
    {

    }
    void printstory3(int curapge)
    {

    }
    void printstory4(int curapge)
    {

    }
    public void gotonextscen()
    {
        SceneManager.LoadScene(stagenum + 1); 
    }
    public void printstory()
    {
        switch (stagenum)
        {
            case 1:
                printstory1(currentpage);
                break;
            case2:
                printstory2(currentpage);
                break;
            case3:
                printstory3(currentpage);
                break;
            case4:
                printstory4(currentpage);
                break;
        }

        currentpage++;
    }
}
