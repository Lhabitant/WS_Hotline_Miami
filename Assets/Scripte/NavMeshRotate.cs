using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshRotate : MonoBehaviour
{

    [SerializeField]
    NavMeshAgent agent; //reference to an object with NavMeshAgent agent, set it in inspector, for example

    // Start is called before the first frame update
    void Start()
    {
        //BuildNav();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void BuildNav()
    {
        /*
        grids.transform.rotation = Quaternion.Euler(90, 0, 0);
        transform.rotation = Quaternion.Euler(0, 0, 0);
        GetComponent<NavMeshSurface>().BuildNavMesh();
        grids.transform.rotation = Quaternion.Euler(0, 0, 0);
        transform.rotation = Quaternion.Euler(-90, 0, 0);
        */
    }
}
