using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    private Animator _animator = null;
    private List<Material> _materials = new List<Material>();


    private void Awake()
    {
        _animator = this.GetComponent<Animator>();

        Renderer[] renderers = this.GetComponentsInChildren<Renderer>();
        foreach(Renderer renderer in renderers)
        {
            _materials.AddRange(renderer.materials);
        }


    }
   

   public void Hit()
    {
        foreach (Material material in _materials)
            material.color = Color.red;
        _animator.SetTrigger("Hit");

        Invoke("RestoreMaterial", 0.7f);// 이름안에 함수를 0.7초 후 호출;
    }

   private void RestoreMaterial()
    {
        foreach (Material material in _materials)
            material.color = Color.white;
    }

}
