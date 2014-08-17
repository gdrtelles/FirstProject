using UnityEngine;
using System.Collections;

public class PowerUp : MonoBehaviour {
	
	
	void destroyer()
	{
		Destroy (this.gameObject);
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == "player") 
		{
			Destroy (this.gameObject);
				
		}
	}
	

}
