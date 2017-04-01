using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeMesh : MonoBehaviour {
    private GameObject center;
    private List<GameObject> edgeVerts;

    private int edgeVertCout; 

	void Start () {
        SetupVerts();
    }
	void SetupVerts() {
        edgeVerts = new List<GameObject>();

        center = GameObject.FindGameObjectWithTag("CenterVert");
        edgeVertCout = GameObject.FindGameObjectsWithTag("EdgeVert").Length;
        
        
        for(int j = 0; j < edgeVertCout; j++) {
            edgeVerts.Add(GameObject.FindGameObjectsWithTag("EdgeVert")[j]);
        }

        //Maybe sorts them? idk
        edgeVerts.Sort((v1, v2) => int.Parse(v1.gameObject.name).CompareTo(int.Parse(v2.gameObject.name)));

        //Add 2 more Springs to each edge vert to connect them to their neighbors
        for (int i = 0; i < edgeVerts.Count; i++) {
            edgeVerts[i].AddComponent<SpringJoint2D>();
            edgeVerts[i].AddComponent<SpringJoint2D>();

            int neighbor1 = i - 1;
            int neighbor2 = i + 1;

            //Wrap the first vert around to the end
            if(neighbor1 < 0) {
                neighbor1 = edgeVerts.Count - 1;
            }

            //Wrap around the last vert back to the beginning
            if(neighbor2 >= edgeVerts.Count) {
                neighbor2 = 0;
            }

            edgeVerts[i].GetComponents<SpringJoint2D>()[0].connectedBody = edgeVerts[neighbor1].GetComponent<Rigidbody2D>();
            edgeVerts[i].GetComponents<SpringJoint2D>()[1].connectedBody = edgeVerts[neighbor2].GetComponent<Rigidbody2D>();

            //Set the params for the spring
            edgeVerts[i].GetComponents<SpringJoint2D>()[0].dampingRatio = 0.05f;
            edgeVerts[i].GetComponents<SpringJoint2D>()[1].dampingRatio = 0.05f;

            //Add a spring to the center vert for connected to each edge vert
            center.AddComponent<SpringJoint2D>();
            center.GetComponents<SpringJoint2D>()[i].connectedBody = edgeVerts[i].GetComponent<Rigidbody2D>();
        }        
    }

    void Update(){
        for (int i = 0; i < edgeVerts.Count; i++){
            //The third index of the sprin joints list will be the joint connecting the edgeVert to the center
            edgeVerts[i].GetComponents<SpringJoint2D>()[2].connectedAnchor = center.transform.position;
        }
    }
}
