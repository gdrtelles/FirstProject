using UnityEngine;
using System.Collections;

public class Circle : MonoBehaviour
{
	public int segments;
	private float xradius;
	private float yradius;
	private PlayerControls state;
	LineRenderer line;
	
	void Awake ()
	{
		line = gameObject.GetComponent<LineRenderer>();
		//state = gameObject.GetComponent<PlayerControls>();
		state = GameObject.Find("Player").GetComponent<PlayerControls>();
		line.SetVertexCount (segments + 1);
		line.useWorldSpace = false;
		line.enabled = false;
	
	}
	void Update()
	{
		line.enabled = state.OnorOff;
	}
	void FixedUpdate()
	{



		if (gameObject.tag == "player") 
		{
			xradius = transform.localScale.magnitude * (0.01f + (0.5f/transform.localScale.magnitude ));
			//yradius = transform.localScale.magnitude * 0.06f;
			yradius = transform.localScale.magnitude * (0.01f + (0.5f/transform.localScale.magnitude ));
		} 
		else 
		{
			xradius = transform.localScale.magnitude * (0.001f + (0.5f/transform.localScale.magnitude ));
			yradius = transform.localScale.magnitude * (0.001f + (0.5f/transform.localScale.magnitude ));

		}
		 CreatePoints ();
	}
	
	
	void CreatePoints ()
	{
		float x;
		float y;
		float z = 0f;
		
		float angle = 20f;
		
		for (int i = 0; i < (segments + 1); i++)
		{
			x = Mathf.Sin (Mathf.Deg2Rad * angle) * xradius;
			y = Mathf.Cos (Mathf.Deg2Rad * angle) * yradius;
			
			line.SetPosition (i,new Vector3(x,y,z) );
			
			angle += (360f / segments);
		}
	}
}