using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
 
public class SimpleCamera : MonoBehaviour 
{
    //�w???�O���⪺��l�Z�áA?�l��?�ԩw?���p��?�q�A�ڧ令����?�q�A?�F��K�b�N?���O�W�ק�
    public float m_distanceAway = 4.5f;
    //??��l����
    public float m_distanceUp = 1.5f;
    //??��??�����ƫ�
    private float m_smooth = 5f;
    //���a?�H
    public Transform m_player;
    //�ۤv
    private Transform m_transsform;
 
    private float maxSuo = 100.0f;//???��S?
    private float minSuo = 2.0f;
 
    private float maxSD = 20.0f;
    private float minSD = 1f;
	void Start () 
	{
        m_transsform = this.transform;//�w?�ۤv
        m_player = GameObject.Find("Player").transform;
	}
	
	
	void Update () 
	{
        Zoom();//?��
        CameraSet();//����?�m
        //�w?�@?�g?
        RaycastHit hit;
        if (Physics.Linecast(m_player.position + Vector3.up,m_transsform.position,out hit))
        {
            string name = hit.collider.gameObject.tag;
            if (name != "MainCamera")
            {
                //�p�G�g?�I�������O����A���\�N���o�g?�I��?�쪱�a���Z��
                float currentDistance = Vector3.Distance(hit.point,m_player.position);
                //�p�G�g?�I��?�p�_���a�O����?���Z�áA�N?�����⨭�Z�O��?��A?�F�קK��?�A�N�����Ԫ�
                if (currentDistance < m_distanceAway)
                {
                    m_transsform.position = hit.point;
                }
            }
        }
	}
    /// <summary>
    /// ?�m����
    /// </summary>
    void CameraSet()
    {
        //���o�����?������
        float m_wangtedRotationAngel = m_player.transform.eulerAngles.y;
        //?������?������
        float m_wangtedHeight = m_player.transform.position.y + m_distanceUp;
        //?�o����?�e����
        float m_currentRotationAngle = m_transsform.eulerAngles.y;
        //?������?�e������
        float m_currentHeight = m_transsform.position.y;
        //�b�@�w?????�e���ק��?���⭱?������
        m_currentRotationAngle = Mathf.LerpAngle(m_currentRotationAngle, m_wangtedRotationAngel, m_smooth * Time.deltaTime);
        //���?�e����
        m_currentHeight = Mathf.Lerp(m_currentHeight, m_wangtedHeight, m_smooth * Time.deltaTime);
        //��^�@?Y?��?���a?�e���ר��\�h����?
        Quaternion m_currentRotation = Quaternion.Euler(0, m_currentRotationAngle, 0);
        //���a����m
        Vector3 m_position = m_player.transform.position;
        //�����m�t���h?��X?�F
        m_position -= m_currentRotation * Vector3.forward * m_distanceAway;
        //?����??��?�����ץ[???��?����?�A?�N�O���󪺷s��m
        m_position = new Vector3(m_position.x, m_currentHeight, m_position.z);
        m_transsform.position = Vector3.Lerp(m_transsform.position, m_position, Time.time);
        //�`?���a
        m_transsform.LookAt(m_player);
    }
 
    /// <summary>
    /// ����????��
    /// </summary>
    void Zoom()
    {
        //??��?��?
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            if (Camera.main.fieldOfView <= maxSuo)//?�񪺭S?
            {
                Camera.main.fieldOfView += 2;
            }
            if (Camera.main.orthographicSize <= maxSD)
            {
                Camera.main.orthographicSize += 0.5f;
            }
        }
 
        //Zoom in
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            if (Camera.main.fieldOfView >= minSuo)
            {
                Camera.main.fieldOfView -= 2;
            }
            if (Camera.main.orthographicSize >= minSD)
            {
                Camera.main.orthographicSize -= 0.5f;
            }
        }
    }
}