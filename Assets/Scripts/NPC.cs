using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NPC : MonoBehaviour
{
    [SerializeField] private float duracion;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Interactuar(Transform uinteractuador)
    {
        Debug.Log("Hola");
        transform.DOLookAt(uinteractuador.position, duracion, AxisConstraint.Y);
    }
}
