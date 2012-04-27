using UnityEngine;
using System.Collections;

public class KeepBetweenScenes : MonoBehaviour
{


	void Awake () {
        DontDestroyOnLoad(transform.gameObject);
	}
	

}
