using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarFieldDistant : MonoBehaviour
{
    public GameController gameController;
    private ParticleSystem ps;
    public float WinSpeed = 1.0F;

    void Start()
    {
        ps = GetComponent<ParticleSystem>();
    }

    void Update()
    {
        if (gameController.score >= 200)
        {
            var main = ps.main;
            main.simulationSpeed = WinSpeed;
        }
    }
}
