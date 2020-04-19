using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCharacteristics : MonoBehaviour
{
    public float rotationSpeed; //скорость, с которой объект вращается вокруг своей оси 
    public float planetRadius;  //средний экваториальный радиус
    public float axialTilt; //Наклон оси вращения
    // Start is called before the first frame update
    void Start()
    {
        transform.localScale = Vector3.one * planetRadius;
        transform.localRotation = Quaternion.Euler(axialTilt, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate (Vector3.up, rotationSpeed * Time.deltaTime); //вращение вокруг своей оси
    }
}
