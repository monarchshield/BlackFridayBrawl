using UnityEngine;
using System.Collections;

public class Iteam : MonoBehaviour
{
    //The Score value of said iteam if you return it to base
    [Tooltip("How many points you gain if your return it to objective")]
    protected int _scorevalue;

    //The said weight value this is how much it alters your speed high weight means slower movement
    [Tooltip("The weight of the object, this lowers your players movement")]
    protected float _weightvalue;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    public void SetScoreValue(int val) { _scorevalue = val; }
    public void SetWeightValue(int val) { _weightvalue = val; }

}
