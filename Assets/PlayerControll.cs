using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControll : MonoBehaviour {

    Animator m_anim;
    Rigidbody m_rigid;

    [Header("角色的起始位置")]
    public Vector3 initPos;

    [Header("角色目前的位置")]
    public Vector3 curPos;

    // Use this for initialization
    void Start () {
        m_anim = this.gameObject.GetComponent<Animator>();
        m_rigid = this.gameObject.GetComponent<Rigidbody>();
        initPos = this.gameObject.transform.position;
    }
	
	// Update is called once per frame
	void Update ()
    {
        Anim_Machine();
        curPos = this.gameObject.transform.position;


    }

    private void OnTriggerEnter(Collider collision)
    {

    }



    //Don't touch
    void Anim_Machine()
    {
        if (Mathf.Abs(transform.position.x - curPos.x) > 0.1f || Mathf.Abs(transform.position.z - curPos.z) > 0.1f)
            m_anim.SetBool("isRunning", true);
        else
            m_anim.SetBool("isRunning", false);
    }
}
