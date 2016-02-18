 using UnityEngine;
 using System.Collections;
     
public class PickAxeProjectile : MonoBehaviour {
    float speed;
	Vector2 dir;
	bool isReady;
	 //public Rigidbody2D projectile;
     
    
	void Awake(){
		speed = 5f;
		isReady = false;
	}
	 
     void Start () { 
     }
         
     public void setDirection(Vector2 direction){
		dir= direction.normalized;
		isReady = true;
	 }
	 
     void Update () {
         if (isReady) {  
			Vector2 pos = transform.position;
			pos += dir * speed * Time.deltaTime;
			
			transform.position = pos;
			
			Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0,0));
			
			Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1,1));
			
			if((transform.position.x < min.x) || (transform.position.x > max.x)
				|| (transform.position.y < min.y) || (transform.position.y > max.y)){
				
				Destroy(this.gameObject);
			}
        }    
     }
}
 