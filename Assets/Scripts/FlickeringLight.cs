using UnityEngine;
using System.Collections;

public class FlickeringLight : MonoBehaviour {
	public Light tmp;
	float high = 104.1f;
	float low = 0f;
	public float radius;
	public bool dim = false;
	public float upper = 104.1f;
	public float lower = 90f;
	// Use this for initialization
	void Start () {
		dim = true;
		tmp = this.GetComponent<Light>();
		InvokeRepeating("flicker", Random.Range(0.0f, 2.0f), 0.2f);
	}
	
	// Update is called once per frame
	void flicker() {
		radius = tmp.range;
		if(radius < lower){
			dim = false;
		}
		if(radius > upper){
			dim = true;
		}
		if(dim == true){
			radius = radius - 5;
		}else if(dim == false){
			radius = radius + 5;
		}
		tmp.range = radius;
	}
}
