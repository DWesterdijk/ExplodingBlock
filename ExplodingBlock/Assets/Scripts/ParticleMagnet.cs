using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleMagnet : MonoBehaviour
{
    [Header("Particle")]
    [SerializeField]
    private ParticleSystem _pSys;
    private ParticleSystem.Particle[] _pPar;
    private ParticleSystem.ShapeModule _pShape;

    [Header("Float")]
    [SerializeField]
    private float pullStrength;

    private Vector3 _magnetPos;

    private bool _magnetic;
    
    private int _livingParticles;
    
    void Awake()
    {
        Init();
        _magnetPos = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
        _pShape = _pSys.shape;
        _pSys.GetParticles(_pPar);
        _magnetic = true;
    }

    // Update is called once per frame
    void Update()
    {
        _livingParticles = _pSys.GetParticles(_pPar);
        _magnetPos = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
        _pShape.position = _magnetPos;
        Attract(_livingParticles);
    }

    private void Attract(int particleAmount)
    {
        if (_magnetic)
        {
            for (int i = 0; i < particleAmount; i++)
            {
                _pPar[i].position = Vector3.Lerp(_pPar[i].position, _magnetPos, pullStrength);
            }
            _pSys.SetParticles(_pPar, particleAmount);
        }
    }

    private void Init()
    {
        if (_pSys == null)
        {
            _pSys = GetComponent<ParticleSystem>();
        }
        if (_pPar == null || _pPar.Length < _pSys.main.maxParticles)
        {
            _pPar = new ParticleSystem.Particle[_pSys.main.maxParticles];
        }
    }
}
