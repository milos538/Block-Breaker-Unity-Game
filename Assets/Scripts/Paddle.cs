using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour{

    [SerializeField] float screenWidthInUnits = 16f;
    [SerializeField] float minX = 1.3f;
    [SerializeField] float maxX = 14.7f;

    void Update(){
        float mousePosition = Input.mousePosition.x / Screen.width * screenWidthInUnits;
        Vector3 pomeraj = new Vector3(transform.position.x, transform.position.y, 2f);
        pomeraj.x = Mathf.Clamp(mousePosition, minX, maxX);
        transform.position = pomeraj;
    }
}
