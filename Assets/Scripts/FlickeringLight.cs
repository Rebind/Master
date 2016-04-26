using UnityEngine;
using System.Collections;

public class FlickeringLight : MonoBehaviour {
	public Light tmp;
	float high = 104.1f;
	float low = 0f;
	 float radius;
	 bool dim = false;
	 float upper = 0f;
	 float lower = 90f;
	public float rangeModifier;
	public float changePerTick;
	public float tickInterval; 
	// Use this for initialization
	void Start () {
		dim = true;
		tmp = this.GetComponent<Light>();
		upper = tmp.range;
		lower = tmp.range - rangeModifier;
		InvokeRepeating("flicker", Random.Range(0.0f, 2.0f),tickInterval);
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
			radius = radius - changePerTick;
		}else if(dim == false){
			radius = radius + changePerTick;
		}
		tmp.range = radius;
	}
}
