using UnityEngine;
using System.Collections;

public class loadingIcon : MonoBehaviour {

    private int num;

	// Use this for initialization
	void Start () {
        num = (int)Mathf.Floor(Random.Range(0, 7));

    }
	
	// Update is called once per frame
	void Update () {
        this.gameObject.GetComponent<Animator>().SetInteger("ranNum", num);
	
	}
}
