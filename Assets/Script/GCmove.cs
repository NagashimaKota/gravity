using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GCmove : MonoBehaviour {

    private GameObject player;
    private Rigidbody boll;

    private float power = 10;
    private float dx = 0;
    private float dy = 0;
    private string[] conNames;
    public TextMesh text3d;
    private int i = 0;

    // Use this for initialization
	void Start () {

        player = GameObject.Find("Sphere").GetComponent<GameObject>();
        boll = GameObject.Find("Sphere").GetComponent<Rigidbody>();

        conNames = Input.GetJoystickNames();

        if (conNames[0] == "")
        {
            text3d.text = "Error";
        }
        else
        {
            text3d.text = conNames[0];
        }
    }
	
	// Update is called once per frame
	void Update () {
        

        dx = Input.GetAxis("Horizontal");
        dy = Input.GetAxis("Vertical");

        //player.transform.Translate( dx, dy, 0.0f);
        boll.AddForce(dy * power, -dx * power, 0);

        Debug.Log(dx);
        Debug.Log(dy);

    }
}
