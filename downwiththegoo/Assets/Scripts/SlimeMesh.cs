using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeMesh : MonoBehaviour {
    private int edgeVertCout;
    #region Spring Objects
    private GameObject center;
    private List<GameObject> edgeVerts;
    private Vector3 avgVertPos;
    #endregion

    #region Physics Params
    public float centerSpringFreq;
    public float edgeSpringFreq;

    public float edgeSpringDamping;
    public float centerSpringDamping;

    public float moveForce;
    public float jumpForce;
    #endregion

    #region Mesh Building
    private Vector3[] blobMeshVertices;
    private Vector2[] blobMeshUVs;
    private int[] blobMeshTris;

    private Mesh blobMesh;
    private MeshFilter meshFilter;

    public Material blueMat;
    #endregion

    void Start () {
        SetupBlobPhysics();
        BuildMesh();
    }
    void BuildMesh() {
        blobMesh = new Mesh();
        meshFilter = GetComponent<MeshFilter>();


        //Fill the vertex array
        List<Vector3> blobPhysVertPositions = new List<Vector3>();
        for(int i = 0; i < edgeVertCout; i++) {
            blobPhysVertPositions.Add(edgeVerts[i].transform.position);
        }
        blobMeshVertices = blobPhysVertPositions.ToArray();

        //Fill the uv array

        //Fill the triangle array
        List<int> tris = new List<int>();
        for(int j = 0; j < edgeVertCout; j++) {
            //tris.Add
        }

        //Assign all the arrays and stuff
        blobMesh.vertices = blobMeshVertices;
        blobMesh.uv = blobMeshUVs;
        blobMesh.triangles = blobMeshTris;
    }
    void UpdateMesh() {
        for(int i = 0; i < blobMeshVertices.Length; i++) {
            //blobMeshVertices[i] = 
        }
    }

	void SetupBlobPhysics() {
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

            /*//Use PHYSICS!!!
            Rigidbody2D vert = edgeVerts[i].GetComponent<Rigidbody2D>();
            vert.AddForce(0.1f * (vert.transform.position - edgeVerts[neighbor1].transform.position) * Vector2.Distance(vert.transform.position, edgeVerts[neighbor1].transform.position));
            vert.AddForce(0.1f * (vert.transform.position - edgeVerts[neighbor2].transform.position) * Vector2.Distance(vert.transform.position, edgeVerts[neighbor2].transform.position));
            
            vert.AddForce((vert.transform.position - avgVertPos) * Vector2.Distance(vert.transform.position, center.transform.position));*/


            //Using Unity springs

            edgeVerts[i].GetComponents<SpringJoint2D>()[0].connectedBody = edgeVerts[neighbor1].GetComponent<Rigidbody2D>();
            edgeVerts[i].GetComponents<SpringJoint2D>()[1].connectedBody = edgeVerts[neighbor2].GetComponent<Rigidbody2D>();

            //Set the params for the spring
            edgeVerts[i].GetComponents<SpringJoint2D>()[0].enableCollision = false;
            edgeVerts[i].GetComponents<SpringJoint2D>()[1].enableCollision = false;
            
            edgeVerts[i].GetComponents<SpringJoint2D>()[0].dampingRatio = edgeSpringDamping;
            edgeVerts[i].GetComponents<SpringJoint2D>()[1].dampingRatio = edgeSpringDamping;

            edgeVerts[i].GetComponents<SpringJoint2D>()[1].frequency = edgeSpringFreq;
            edgeVerts[i].GetComponents<SpringJoint2D>()[1].frequency = edgeSpringFreq;

            //Add a spring to the center vert for connected to each edge vert
            center.AddComponent<SpringJoint2D>();
            center.GetComponents<SpringJoint2D>()[i].enableCollision = false;
            center.GetComponents<SpringJoint2D>()[i].connectedBody = edgeVerts[i].GetComponent<Rigidbody2D>();
            center.GetComponents<SpringJoint2D>()[i].dampingRatio = centerSpringDamping;
            center.GetComponents<SpringJoint2D>()[i].frequency = centerSpringFreq;
        }        
    }
    void CalcAvgBlobPhysPos(){
        avgVertPos = Vector3.zero;

        for (int i = 0; i < edgeVerts.Count; i++){
            avgVertPos += edgeVerts[i].transform.position;
        }

        avgVertPos /= edgeVerts.Count;
    }
    
    void TestMove() {
        if(Input.GetKey(KeyCode.A)) {
            center.GetComponent<Rigidbody2D>().AddForce(Vector2.left * moveForce);
        }else if(Input.GetKey(KeyCode.D)) {
            center.GetComponent<Rigidbody2D>().AddForce(Vector2.right * moveForce);
        }
        if(Input.GetKeyDown(KeyCode.Space)) {
            center.GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpForce);
        }
    }

    void Update(){
        CalcAvgBlobPhysPos();
        TestMove();

        for (int i = 0; i < edgeVerts.Count; i++){
            //The third index of the sprin joints list will be the joint connecting the edgeVert to the center
            edgeVerts[i].GetComponents<SpringJoint2D>()[2].connectedAnchor = center.transform.position;
        }

        UpdateMesh();
    }
}
