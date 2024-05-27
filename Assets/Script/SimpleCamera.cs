using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
 
public class SimpleCamera : MonoBehaviour 
{
    //定???与角色的初始距离，?始的?候定?成私有?量，我改成公有?量，?了方便在代?面板上修改
    public float m_distanceAway = 4.5f;
    //??初始高度
    public float m_distanceUp = 1.5f;
    //??改??的平滑度
    private float m_smooth = 5f;
    //玩家?象
    public Transform m_player;
    //自己
    private Transform m_transsform;
 
    private float maxSuo = 100.0f;//???放范?
    private float minSuo = 2.0f;
 
    private float maxSD = 20.0f;
    private float minSD = 1f;
	void Start () 
	{
        m_transsform = this.transform;//定?自己
        m_player = GameObject.Find("Player").transform;
	}
	
	
	void Update () 
	{
        Zoom();//?放
        CameraSet();//相机?置
        //定?一?射?
        RaycastHit hit;
        if (Physics.Linecast(m_player.position + Vector3.up,m_transsform.position,out hit))
        {
            string name = hit.collider.gameObject.tag;
            if (name != "MainCamera")
            {
                //如果射?碰撞的不是相机，那么就取得射?碰撞?到玩家的距离
                float currentDistance = Vector3.Distance(hit.point,m_player.position);
                //如果射?碰撞?小于玩家与相机本?的距离，就?明角色身后是有?西，?了避免穿?，就把相机拉近
                if (currentDistance < m_distanceAway)
                {
                    m_transsform.position = hit.point;
                }
            }
        }
	}
    /// <summary>
    /// ?置相机
    /// </summary>
    void CameraSet()
    {
        //取得相机旋?的角度
        float m_wangtedRotationAngel = m_player.transform.eulerAngles.y;
        //?取相机移?的高度
        float m_wangtedHeight = m_player.transform.position.y + m_distanceUp;
        //?得相机?前角度
        float m_currentRotationAngle = m_transsform.eulerAngles.y;
        //?取相机?前的高度
        float m_currentHeight = m_transsform.position.y;
        //在一定?????前角度更改?角色面?的角度
        m_currentRotationAngle = Mathf.LerpAngle(m_currentRotationAngle, m_wangtedRotationAngel, m_smooth * Time.deltaTime);
        //更改?前高度
        m_currentHeight = Mathf.Lerp(m_currentHeight, m_wangtedHeight, m_smooth * Time.deltaTime);
        //返回一?Y?旋?玩家?前角度那么多的度?
        Quaternion m_currentRotation = Quaternion.Euler(0, m_currentRotationAngle, 0);
        //玩家的位置
        Vector3 m_position = m_player.transform.position;
        //相机位置差不多?算出?了
        m_position -= m_currentRotation * Vector3.forward * m_distanceAway;
        //?相机??到?的高度加???到?的坐?，?就是相机的新位置
        m_position = new Vector3(m_position.x, m_currentHeight, m_position.z);
        m_transsform.position = Vector3.Lerp(m_transsform.position, m_position, Time.time);
        //注?玩家
        m_transsform.LookAt(m_player);
    }
 
    /// <summary>
    /// 按鼠????放
    /// </summary>
    void Zoom()
    {
        //??滑?拖?
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            if (Camera.main.fieldOfView <= maxSuo)//?放的范?
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