using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class PlayerController : MonoBehaviour {

	private Rigidbody rb;
	private int count;
	private UnityEngine.UI.Button reload;

	public float speed;
	public Text countText;
	public Text winText;

	void Start () {
		rb = GetComponent<Rigidbody>();
		reload = GameObject.Find("Reload").GetComponent<UnityEngine.UI.Button>();
		count = 0;
		setCountText ();
		winText.text = "";
	}

	void FixedUpdate ()
	{
		
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		rb.AddForce (movement * speed);
	}

	void OnTriggerEnter(Collider other) 
	{
		if (other.gameObject.CompareTag ("Pick Up"))
		{
			other.gameObject.tag = "Picked Up";
			other.transform.localScale = new Vector3(0.0f,0.0f,0.0f);
			count++;
			setCountText ();
		}
	}

	void setCountText ()
	{
		countText.text = "Count: " + count.ToString ();
		if (count >= 11) {
			winText.text = "You won";
			enableButton ();
		}
	}

	void enableButton() 
	{
		reload.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
	}

	public void Restart()
	{
		winText.text = "";
		count = 0;
		setCountText ();
		rb.transform.position = new Vector3 (0.0f, 0.0f, 0.0f);
		GameObject[] collinders = GameObject.FindGameObjectsWithTag ("Picked Up");
		foreach (GameObject collinder in collinders) {
			collinder.transform.localScale = new Vector3(0.5f,0.5f,0.5f);
			collinder.gameObject.tag = "Pick Up";
		}
	}
}