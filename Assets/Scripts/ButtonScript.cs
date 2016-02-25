using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour {

    public GameObject abouttile;
    public GameObject gametitle;
	// Use this for initialization

    public void showAboout()
    {
        abouttile.SetActive(true);
        gametitle.SetActive(false);
    }

    public void showClose()
    {
        abouttile.SetActive(false);
        gametitle.SetActive(true);
    }
    public void showGamescene()
    {
        //Application.LoadLevel("stage1");
        SceneManager.LoadScene(1); 
    }
}
