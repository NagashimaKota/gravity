using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour {

    public GameObject player;
    public GameObject terget;

    private float speed = 0;   //目標座標までの速度
    private float rote = 0;    //目標角度までの回転量
    private float angle = 0;   //これまでの回転量の和
    private float thita = 0;   //目標の角度

    private Vector3 startPosition;
    private Vector3 endPostion;     //目標座標
    private Vector3 endRote = Vector3.zero;  //目標角度
    private Vector3 posPL = Vector3.zero;
    private Quaternion rote0 = Quaternion.identity; //回転していない状態

    private Vector3 mousePos1 = Vector3.zero;
    private Vector3 mousePos2 = Vector3.zero;
    
    // Use this for initialization
    void Start () {
        endPostion = player.transform.position;
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetMouseButtonDown(0))
        {
            mousePos1 = Input.mousePosition;
            startPosition = player.transform.position;
        }

        if (Input.GetMouseButtonUp(0))
        {
            mousePos2 = Input.mousePosition;
            endPostion = Move();
        }

        //オブジェクトの移動と回転
        player.transform.position = Vector3.Lerp(player.transform.position, endPostion, speed);
        player.transform.Rotate(0, rote, 0);

        //移動速度
        speed += 0.01f * Time.deltaTime;  //早くなっていきそう

        if (player.transform.position.y <= 0)
        {
            player.transform.position = new Vector3(player.transform.position.x, player.transform.localScale.y/2, player.transform.position.z) ;
        }

        //目標角度まで回転
        if (Mathf.Abs(thita) >= angle)
        {
            angle += rote;
        }
        else
        {
            rote = 0;
            angle = 0;
        }
    }


    Vector3 Move()
    {
        float pos;
        Vector3 endPos = Vector3.zero;
        endPos = mousePos2 - mousePos1;

        pos = endPos.y;
        endPos.y = endPos.z;
        endPos.z = pos;

        //移動後の回転角を計算
        rote0 = Quaternion.LookRotation(endPos);
        thita = Quaternion.Angle(player.transform.rotation, rote0);
        rote = thita * 0.5f * Time.deltaTime;
        //player.transform.rotation = rote0;

        //移動
        endPos = (endPos / 80f) + player.transform.position;
        //endPos = (endPos / 80f) + startPosition;


        //endPos = player.transform.position + (endPos / 80f);

        endPos.y = player.transform.localScale.y / 2;    //y座標最低値
        endRote.y = endPos.y;    //とりあえず回転
        Debug.Log(endPos);
        Debug.Log(thita);

        return endPos;
    }
}
