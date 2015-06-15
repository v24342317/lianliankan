using UnityEngine;
using System.Collections;

public class clickTile : MonoBehaviour {

    public Camera mainCamera;
    public bool firstSelected=false;
    public GameObject[] selected;

    GameObject[] obj= new GameObject[2];
    LineRenderer line;

	// Use this for initialization
	void Start () {
        GameObject lineObj = new GameObject("line1");
        line = lineObj.AddComponent<LineRenderer>();
        line.SetWidth(0.1f,0.1f);
        line.SetVertexCount(2);
	}

    void drawLine(int linkType) {
        if (linkType==0)
        {
        line.SetPosition(0,obj[0].transform.position+new Vector3(0,0,-1));
        line.SetPosition(1, obj[1].transform.position + new Vector3(0, 0, -1));
        }
    }

    void drawLineZero() {
        line.SetPosition(0, Vector3.zero);
        line.SetPosition(1, Vector3.zero);
    }

	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Fire1"))
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (firstSelected)
                {
                    firstSelected = false;
                    obj[1]=hit.transform.gameObject;
                    selected[1].transform.position = obj[1].transform.position+new Vector3(0,0,1);
                    drawLine(0);
                }
                else 
                {
                    drawLineZero();
                    foreach (GameObject g in selected)
                    {
                        g.transform.position = new Vector3(-10f,-2f,0f);
                    }
                    obj = null;
                    obj= new GameObject[2];
                    firstSelected = true;
                    obj[0] = hit.transform.gameObject;
                    selected[0].transform.position = obj[0].transform.position + new Vector3(0, 0, 1);
                }
            }
        }
	
	}
}
