using UnityEngine;
using System.Collections;

public class DontDestroyOnLoad : MonoBehaviour {

	public static DontDestroyOnLoad a;

	void Awake()
	{
		if(a == null)
		{
			DontDestroyOnLoad(gameObject);
			a = this;
		}
		else if(a != this)
		{
			Destroy(gameObject);
		}
	}
}
