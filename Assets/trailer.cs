using UnityEngine;
using System.Collections;

public class trailer : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.L)) {
            gameObject.GetComponent<Ferr2DT_PathTerrain>().vertexColor = Color.yellow;
        }
    }
}
