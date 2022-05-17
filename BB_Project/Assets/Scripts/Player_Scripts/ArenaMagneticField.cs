using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArenaMagneticField : MonoBehaviour
{
    public float magneticForce;

    public GameObject Playermodel;
    public GameObject arenaField;

    Rigidbody trompo;

    Transform PlayerPosition;
    Transform Magnet;


    void Start()
    {
        Magnet = arenaField.GetComponent<Transform>();
        trompo = Playermodel.GetComponent<Rigidbody>();
        PlayerPosition = Playermodel.GetComponent<Transform>();
    }

    void FixedUpdate()
    {
        //Se le agrega fuerza magnetica al trompo con addforce tomando en cuenta la position del magnet menos la del player por la fuerza magnetica y el time para dar el efecto de bowl.
        trompo.AddForce((Magnet.position - PlayerPosition.position) * magneticForce * Time.deltaTime);
    }

    void OnTriggerExit(Collider other)
    {
        //Aqui se tomara en cuenta si algun player sale del arena y la fuerza magnetica se dejara de aplicar y lo detendra.
        if (other.CompareTag("Player"))
        {
            magneticForce = 0;
            trompo.velocity = Vector3.zero;
            trompo.angularVelocity = Vector3.zero;
        }
    }
}
