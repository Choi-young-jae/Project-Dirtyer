using UnityEngine;
using System.Collections;


public class MoveBehaviour : MonoBehaviour {
    public GameObject block;
    private bool _mouseState;
    public Vector3 screenSpace;
    public Vector3 offset;

	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            _mouseState = true;
            screenSpace = Camera.main.WorldToScreenPoint(block.transform.position);
            offset = block.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenSpace.z));
        }
        if (Input.GetMouseButtonUp(0))
        {
            _mouseState = false;
        }
        if (_mouseState)
        {
            //keep track of the mouse position
            Vector3 curScreenSpace = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenSpace.z);

            //convert the screen mouse position to world point and adjust with offset
            Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenSpace) + offset;
            
            Debug.Log(curPosition.x + " " + curPosition.y + " " + curPosition.z);
            //update the position of the object in the world
            block.transform.position = curPosition;
        }
	}
}
