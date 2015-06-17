using UnityEngine;
using System.Collections;

public class build : MonoBehaviour {

    public GameObject tile;
    public int width=4;
    public int height=4;
    public float offset = 1.2f;

    public int[] test_map;

	// Use this for initialization
	void Start () {
        buildTile();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void refresh(GameObject[] obj) {
        foreach (GameObject g in obj)
        {
            test_map[(int)g.GetComponentInChildren<tileCode>().y * height + (int)g.GetComponentInChildren<tileCode>().x] = 0;
            g.GetComponent<tileCode>().value = 0;
            g.GetComponentInChildren<TextMesh>().text = "0";
        }
    }

    void Awake()
    {
        test_map = new int[]
        {
            1,2,3,4,
            5,6,1,8,
            9,10,11,12,
            13,14,15,16
        };
    }

    private void buildTile() {
        for (int x = 0; x < width;x++ )
        {
            for (int y = 0; y < height;y++ )
            {
                GameObject t = (GameObject)Instantiate(tile, new Vector3(x * offset, -y * offset, 0), Quaternion.identity);
                string name = x.ToString() + y.ToString();
                t.GetComponentInChildren<tileCode>().x = x;
                t.GetComponentInChildren<tileCode>().y = y;
                t.GetComponentInChildren<tileCode>().value = test_map[y * height + x];

                t.GetComponentInChildren<TextMesh>().text = test_map[y* height + x].ToString();
                t.GetComponentInChildren<TextMesh>().name = name;
                t.name = name;
                //GameObject[] go=t.GetComponentsInChildren<GameObject>();
            }
        }
    }
}
