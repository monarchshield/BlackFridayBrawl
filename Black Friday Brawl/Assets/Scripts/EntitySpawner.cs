using UnityEngine;
using System.Collections;

public class EntitySpawner : MonoBehaviour
{
    //This is how often the entitys will spawn
    public float _spawnrateseconds;

    //A arbitary value to keep track of time and when stuff should spawn
    private float _timer;

    //The total amount of minions spawned
    public int _totalamount;
    private int _entityCountAmount;


    public GameObject _Agent;

	// Use this for initialization
	void Start () 
    {
        _entityCountAmount = 0;
        _timer = _spawnrateseconds;   
	}
	
	// Update is called once per frame
	void Update () 
    {
        SpawnEntity();
	}

    void SpawnEntity()
    {
        _timer -= Time.deltaTime;

        if(_timer < 0 && _entityCountAmount <= _totalamount)
        {
            _timer = _spawnrateseconds;
            int rand = Random.Range(0, 4);

            GameObject obj = (GameObject)Instantiate(_Agent, transform.position, Quaternion.identity);
            Seek headingloc = obj.GetComponent<Seek>();
            headingloc.SetStartLocation(transform.position);
            
            switch (rand)
            {

                case 0:
                {
                    headingloc.SetColour(Color.red);
                    Debug.Log("Red");
                }
               break;

               case 1:
               {
                   headingloc.SetColour(Color.blue);
                   Debug.Log("Blue");
               } 
               break;

                case 2:
               {
                   headingloc.SetColour(Color.green);
                   Debug.Log("Green");
               } 
               break;

               case 3:
               {
                   headingloc.SetColour(Color.magenta);
                   Debug.Log("Magenta");
               } 
               break;

                default:
                    Debug.Log("Fix it felix");
                    break;
            }

            _entityCountAmount += 1;
        }
    }

}
