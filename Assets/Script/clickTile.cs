using UnityEngine;
using System.Collections;

public class clickTile : MonoBehaviour {

    public Camera mainCamera;
    public bool firstSelected=false;
    public GameObject[] selected;

    GameObject[] obj= new GameObject[2];
    LineRenderer line;
    int[] temp_map;

	// Use this for initialization
	void Start () {
        GameObject lineObj = new GameObject("line1");
        line = lineObj.AddComponent<LineRenderer>();
        line.SetWidth(0.1f,0.1f);
        line.SetVertexCount(2);
        temp_map = GetComponent<build>().test_map;
	}

    bool isSame() {
        if (obj[0].GetComponent<tileCode>().value == obj[1].GetComponent<tileCode>().value) {
            return true;
        }
        return false;
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

    void deleteTile() {
        foreach (GameObject g in obj)
        {
            Destroy(g);
        }
    }

    void initSelectedObj() 
    {
        foreach (GameObject g in selected)
        {
            g.transform.position = new Vector3(-10f, -2f, 0f);
        }
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

                    if (isSame())
                    {
                        drawLine(0);
                        gameObject.GetComponent<build>().refresh(obj);
                        Invoke("drawLineZero", 2.0f);
                        Invoke("deleteTile", 2.0f);
                        Invoke("initSelectedObj", 2.0f);
                    }
                    else {
                        initSelectedObj();
                        drawLineZero();
                    }
                }
                else 
                {                
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
