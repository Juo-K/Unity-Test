using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Damage : MonoBehaviour
{
    [SerializeField, Range(100.0f, 200.0f)]
    private float _hp = 100.0f;

    private bool _bDead = false;
    public bool Dead { get { return _bDead; } private set { _bDead = value; } }

    private Animator _animator = null;
    private List<Material> _materials = new List<Material>();

    private NavMeshAgent _navMeshAgent = null;
    private Collider[] _colliders = null;

    private void Awake()
    {
        _navMeshAgent = this.GetComponent<NavMeshAgent>();
        _colliders = this.GetComponentsInChildren<Collider>();
        _animator = this.GetComponent<Animator>();

        Renderer[] renderers = this.GetComponentsInChildren<Renderer>();
        foreach(Renderer renderer in renderers)
            _materials.AddRange(renderer.materials);
    }

    public void Hit(float ad)
    {

        if (_bDead == true) return;
        _hp = Mathf.Max(_hp - ad, 0.0f);

        if (_hp <= 0.0f)
            GoAmerica();
        else
        {
            foreach (Material material in _materials)
                material.color = Color.red;

            _animator.SetTrigger("Hit");
            Invoke("RestoreMaterial", 0.7f);
        }
        
    }

    private void GoAmerica()
    {
        _bDead = true;
        _navMeshAgent.enabled = false;
        foreach (Collider col in _colliders)
            col.enabled = false;

        _animator.SetTrigger("Dead");
    }

    private void RemoveObject()
    {
        Destroy(this.gameObject);
    }

    private void OnAmerica()
    {
        //Destroy(this.gameObject);
        //RemoveObject();
        Invoke("RemoveObject", 0.7f);
    }

    private void RestoreMaterial()
    {
        foreach (Material material in _materials)
            material.color = Color.white;
    }

   

}
