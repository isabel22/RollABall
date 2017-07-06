using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickController : MonoBehaviour {

	private UnityEngine.UI.Button reload;

	// Use this for initialization
	void Start () {
		reload = GameObject.Find("Reload").GetComponent<UnityEngine.UI.Button>();
		disableButton();
		
	}
	
	// Update is called once per frame
	public void Click1 () {
		restart ();
	}

	void disableButton() 
	{
		reload.transform.localScale = new Vector3(0.0f, 0.0f, 0.0f);
	}

	public void restart(){
		reload.transform.localScale = new Vector3(0.0f, 0.0f, 0.0f);
	}
}
