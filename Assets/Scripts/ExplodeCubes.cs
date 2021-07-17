using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeCubes : MonoBehaviour
{
    public float Force = 50f;
    public float Radius = 5f;
    public GameObject restartButton;

    private bool _collisionSet;

    private void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.tag == "Cube" && !_collisionSet) {
            for(int i = collision.transform.childCount - 1; i >= 0; i--) {
                Transform child = collision.transform.GetChild(i);
                child.gameObject.AddComponent<Rigidbody>();
                child.gameObject.GetComponent<Rigidbody>().AddExplosionForce(Force, Vector3.up, Radius);
                child.SetParent(null);
            }

            restartButton.SetActive(true);
            Camera.main.transform.position -= new Vector3(0, 0, 3f);
            Destroy(collision.gameObject);
            _collisionSet = true;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
