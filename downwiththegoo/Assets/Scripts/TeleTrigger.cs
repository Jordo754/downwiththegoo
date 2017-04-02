using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleTrigger : MonoBehaviour {
    public int level;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Collider>().tag == "CenterVert")
        {
            Debug.Log("HIT TELE");

            GameObject[] temp = GameObject.FindGameObjectsWithTag("InTele");
            for(int i=0;i<temp.Length;i++)
            {
                Debug.Log("Inside search");
                Debug.Log(temp[i]);
                int tempLevel = temp[i].GetComponent<InTele>().level;
                if (tempLevel == (this.level + 1))
                {
                    Debug.Log("Inside if");
                    GameObject.Find("Player").transform.position = new Vector3(temp[i].transform.position.x,temp[i].transform.position.y,0);
                    GameObject.Find("Player").GetComponent<Rigidbody>().velocity = Vector3.zero;
                }
            }
        }
    }
}
