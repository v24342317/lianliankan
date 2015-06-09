using UnityEngine;
using System.Collections;

public class build : MonoBehaviour {

    public GameObject tile;
    public int width=4;
    public int height=4;
    public float offset = 1.2f;

	// Use this for initialization
	void Start () {
        buildTile();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    private void buildTile() {
        for (int i = 0; i < width;i++ )
        {
            for (int j = 0; j < height;j++ )
            {
                GameObject t = (GameObject)Instantiate(tile, new Vector3(i * offset, -j * offset, 0), Quaternion.identity);
                string name = i.ToString() + "" + j.ToString();
               
                t.GetComponentInChildren<TextMesh>().text = name;
                t.GetComponentInChildren<TextMesh>().name = name;

                t.name = name;
                //GameObject[] go=t.GetComponentsInChildren<GameObject>();
            }
        }
    }
}
