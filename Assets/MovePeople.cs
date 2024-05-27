using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePeople : MonoBehaviour {

	GameObject findobj;
	public string m_objName; //assign name from outside
	public bool m_updateFlag;//record whether keep moving




	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {


		if (Input.GetKey (KeyCode.UpArrow)||Input.GetKey(KeyCode.Y)) {
			findobj = GameObject.Find ("Character");
			if (findobj) {
				//SphereMove objstatus = findobj.GetComponent<SphereMove> ();
				print ("This is" + findobj.name);
				//objstatus.enabled = true;
				findobj.GetComponent<Transform>().position += Vector3.forward*0.01f;

			} else {
				print ("Not find");
			}
		}
		/*if (Input.GetKeyUp (KeyCode.LeftArrow)) {
			findobj = GameObject.Find ("Character");
			if (findobj) {
				SphereMove objstatus = findobj.GetComponent<SphereMove> ();
				print ("This is" + objstatus.name);
				objstatus.enabled = false;
			} else {
				print ("Not find");
			}			
		}*/

		if (Input.GetKey (KeyCode.LeftArrow)||Input.GetKey(KeyCode.G)) {
			findobj = GameObject.Find ("Character");
			if (findobj) {
				//SphereMove objstatus = findobj.GetComponent<SphereMove> ();
				print ("This is" + findobj.name);
				//objstatus.enabled = true;
				findobj.GetComponent<Transform>().position += Vector3.left*0.01f;

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
				findobj.GetComponent<Transform>().position += Vector3.right*0.01f;

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
				findobj.GetComponent<Transform>().position += Vector3.back*0.01f;

			} else {
				print ("Not find");
			}
		}
		/*
		if (Input.GetKey (KeyCode.T)) { //左上
			findobj = GameObject.Find ("Character");
			if (findobj) {
				//SphereMove objstatus = findobj.GetComponent<SphereMove> ();
				print ("This is" + findobj.name);
				//objstatus.enabled = true;
				findobj.GetComponent<Transform>().position += new Vector3(-0.2f,0.0f,0.2f);

			} else {
				print ("Not find");
			}
		}
		if (Input.GetKey (KeyCode.U)) { //右上
			findobj = GameObject.Find ("Character");
			if (findobj) {
				//SphereMove objstatus = findobj.GetComponent<SphereMove> ();
				print ("This is" + findobj.name);
				//objstatus.enabled = true;
				findobj.GetComponent<Transform>().position += new Vector3(0.2f,0.0f,0.2f);

			} else {
				print ("Not find");
			}
		}
		if (Input.GetKey (KeyCode.B)) { //左下
			findobj = GameObject.Find ("Character");
			if (findobj) {
				//SphereMove objstatus = findobj.GetComponent<SphereMove> ();
				print ("This is" + findobj.name);
				//objstatus.enabled = true;
				findobj.GetComponent<Transform>().position += new Vector3(-0.2f,0.0f,-0.2f);

			} else {
				print ("Not find");
			}
		}
		if (Input.GetKey (KeyCode.M)) { //右下
			findobj = GameObject.Find ("Character");
			if (findobj) {
				//SphereMove objstatus = findobj.GetComponent<SphereMove> ();
				print ("This is" + findobj.name);
				//objstatus.enabled = true;
				findobj.GetComponent<Transform>().position += new Vector3(0.2f,0.0f,-0.2f);

			} else {
				print ("Not find");
			}
		}*/

		if (Input.GetKeyDown (KeyCode.Space)) { //跳躍
			findobj = GameObject.Find ("Character");
			if (findobj) {
				//SphereMove objstatus = findobj.GetComponent<SphereMove> ();
				print ("This is" + findobj.name);
				//objstatus.enabled = true;
				findobj.GetComponent<Rigidbody>().AddForce(0,1800,0);

			} else {
				print ("Not find");
			}
		}
		if (Input.GetKeyDown (KeyCode.RightAlt)) { //超級跳躍
			findobj = GameObject.Find ("Character");
			if (findobj) {
				//SphereMove objstatus = findobj.GetComponent<SphereMove> ();
				print ("This is" + findobj.name);
				//objstatus.enabled = true;
				findobj.GetComponent<Rigidbody>().AddForce(1,1800,0);

			} else {
				print ("Not find");
			}
		}





	}

}
