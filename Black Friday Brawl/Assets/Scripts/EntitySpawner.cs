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


    public GameObject _redAgent;
    public GameObject _blueAgent;
    public GameObject _pinkAgent;
    public GameObject _orangeAgent;



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
            int rand = Random.Range(0, 3);

            switch (rand)
            {
                case 0:
                {
                    GameObject obj = (GameObject)Instantiate(_redAgent, transform.position, Quaternion.identity);
                    Seek headingloc = obj.GetComponent<Seek>();
                    headingloc.SetStartLocation(transform.position);
                }
               break;

               case 1:
               {
                   GameObject obj = (GameObject)Instantiate(_blueAgent, transform.position, Quaternion.identity);
                   Seek headingloc = obj.GetComponent<Seek>();
                   headingloc.SetStartLocation(transform.position);
               } 
               break;

                case 2:
               {
                   GameObject obj = (GameObject)Instantiate(_pinkAgent, transform.position, Quaternion.identity);
                   Seek headingloc = obj.GetComponent<Seek>();
                   headingloc.SetStartLocation(transform.position);
               } 
               break;

                case 3:
                {
                   GameObject obj = (GameObject)Instantiate(_orangeAgent, transform.position, Quaternion.identity);
                   Seek headingloc = obj.GetComponent<Seek>();
                   headingloc.SetStartLocation(transform.position);
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
