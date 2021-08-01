using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinScript : MonoBehaviour {

    void Start () {

    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.name=="Player")
        Destroy(gameObject);
        HealthScript.health += 40f;
    }
    // Update is called once per frame
    void Update () {
}
}
