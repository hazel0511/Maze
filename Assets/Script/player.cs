using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour {

	GameObject findobj;

	// Use this for initialization
	public Animator anim;
	public Rigidbody rbody;

	private float inputH;
	private float inputV;
	private bool run;


	private bool hit;



	Canvas exitCanvas;


	void Start () {
		

		anim = GetComponent<Animator> ();
		rbody = GetComponent<Rigidbody> ();
		run = false;


		hit = false;




		exitCanvas = GameObject.Find ("Quit_Canvas").GetComponent<Canvas>();
		exitCanvas.enabled = false;
	}





	// Update is called once per frame
	void Update () {

		if (Input.GetKey (KeyCode.UpArrow)||Input.GetKey(KeyCode.Y)) {
			findobj = GameObject.Find ("Character");
			if (findobj) {
				//SphereMove objstatus = findobj.GetComponent<SphereMove> ();
				print ("This is" + findobj.name);
				//objstatus.enabled = true;
				findobj.GetComponent<Transform>().position += Vector3.forward*0.015f;

			} else {
				print ("Not find");
			}
		}

		if (Input.GetKey (KeyCode.LeftArrow)||Input.GetKey(KeyCode.G)) {
			findobj = GameObject.Find ("Character");
			if (findobj) {
				//SphereMove objstatus = findobj.GetComponent<SphereMove> ();
				print ("This is" + findobj.name);
				//objstatus.enabled = true;
				findobj.GetComponent<Transform>().position += Vector3.left*0.015f;

			} else {
				print ("Not find");
			}
		}
		if (Input.GetKey (KeyCode.RightArrow)||Input.GetKey(KeyCode.J)) {
			findobj = GameObject.Find ("Character");
			if (findobj) {
				//SphereMove objstatus = findobj.GetComponent<SphereMove> ();
				print ("This is" + findobj.name);
				//objstatus.enabled = true;
				findobj.GetComponent<Transform>().position += Vector3.right*0.015f;

			} else {
				print ("Not find");
			}
		}
		if (Input.GetKey (KeyCode.DownArrow)||Input.GetKey(KeyCode.N)) {
			findobj = GameObject.Find ("Character");
			if (findobj) {
				//SphereMove objstatus = findobj.GetComponent<SphereMove> ();
				print ("This is" + findobj.name);
				//objstatus.enabled = true;
				findobj.GetComponent<Transform>().position += Vector3.back*0.015f;

			} else {
				print ("Not find");
			}
		}







		if(Input.GetKeyDown("1"))
		{
			//anim.Play("WAIT01",-1,0f);

		}
		if(Input.GetKeyDown("2"))
		{
			anim.Play("WAIT02",-1,0f);
		}
		if(Input.GetKeyDown("3"))
		{
			anim.Play("WAIT03",-1,0f);
		}
		if(Input.GetKeyDown("4"))
		{
			anim.Play("WAIT04",-1,0f);
		}
		/*if(Input.GetMouseButtonDown(0))  //Fall down > <
		{
			int n = Random.Range(0,2);

			if(n == 0)
			{
				anim.Play ("DAMAGED00",-1,0f);
			}
			else
			{
				anim.Play ("DAMAGED01",-1,0f);
			}
		}*/


		inputH = Input.GetAxis ("Horizontal");//keyboard left&right arrow
		inputV = Input.GetAxis ("Vertical");//keyboard up&down arrow
		anim.SetFloat ("inputH", inputH);
		anim.SetFloat ("inputV", inputV);

		float moveX = inputH * 20f * Time.deltaTime;
		float moveZ = inputV * 40f * Time.deltaTime;

		rbody.velocity = new Vector3(moveX, 0f, moveZ);
		if (Input.GetKeyDown (KeyCode.Space)) {
			rbody.velocity = Vector3.right * 10;
		}


		if (Input.GetKey (KeyCode.RightShift)) {
			run = true;
		} else {
			run = false;
		}
		anim.SetBool ("run", run);
	}

	//private void OnTriggerEnter(Collider collision)
	private void OnCollisionEnter(Collision collision)
	{
		//if (collision.gameObject.tag == "Water")
		//this.gameObject.transform.position = initPos;

		if (collision.gameObject.tag == "enemy")
		{		//Destroy(collision.gameObject);
			anim.Play ("DAMAGED01", -1, 0f);
			//if (anim.Play ("DAMAGED01", -1, 0f)) {
				//print ("yesss");
			//}
			print("hit");
			hit = true;
			anim.SetBool ("hit", hit);



			exitCanvas.enabled = true;

		}

		if (collision.gameObject.tag == "win") 
		{
			anim.Play("WIN00",-1,0f);
			print ("win");
			UnityEngine.SceneManagement.SceneManager.LoadSceneAsync ("win");
		}
	}

}
