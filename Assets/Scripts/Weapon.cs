﻿using UnityEngine;

[CreateAssetMenu(fileName = "Weapon",menuName = "Weapon/NewWeapon")]
public class Weapon :ScriptableObject
{
    //UI툴만드는 느끰적인 느끰
    [SerializeField]
    private GameObject _source = null;

    [SerializeField]
    private AnimatorOverrideController _override = null;

    [SerializeField, Range(10.0f, 50.0f)]
    private float _damage = 10.0f;
    public float Damage { get { return _damage; } }


    [SerializeField, Range(1, 10)]
    private float _range = 3.0f;
    public float Range { get { return _range; } }

    [SerializeField]
    private bool _bRightHanded = true;

    [SerializeField]
    private Projectile _projectile = null;

    //private Projectile _projectile = null;
    private Projectile[] _weapons = null;
    public bool HasProjectile { get { return _projectile  != null; } }

    const string _weaponName = "Weapon";

    public void Spawn(Transform right, Transform left, Animator animator)
    {
        DestroyWeapon(right, left);

        if(_source != null)
        {
            Transform hand = _bRightHanded ? right : left;
            GameObject weapon = Instantiate(_source, hand); //부모를 부르는 것;ㅣ

            weapon.name = _weaponName;
        }

        if(_override != null && animator)
        {
            animator.runtimeAnimatorController = _override;
        }
    }

    private void DestroyWeapon(Transform right, Transform left)
    {
        Transform old = right.Find(_weaponName);
        if (old == null)
            old = left.Find(_weaponName);

        if (old == null) return;

        old.name = "DestoryWeapon";
        Destroy(old.gameObject);
    }
    [SerializeField, Range(5.0f, 20.0f)]
    private float __speed = 7.0f;

    [SerializeField, Range(1.0f, 5.0f)]
    private float _lifeTile = 1.0f;

    public void LaunchProjectile(Transform right, Transform left, Damage damage)
    {
        Transform hand = null;
        
        hand = _bRightHanded ? left : right;
        
        //Projectile projectile1 = Instantiate(_projectile, Vector3.zero, Quaternion.Euler(0,0, 0));
       //_weapons = game.GetComponentsInChildren<Projectile>();
        
        

        for (int i = 0; i < 36; i++)
        {
            Vector3 pos = hand.position;
            
            pos.Set(pos.x + Random.Range(-10,10), pos.y + Random.Range(0, 5), pos.z + Random.Range(-10,10));

            //Projectile projectile = Instantiate(_projectile, hand.position, Quaternion.Euler(0, hand.eulerAngles.y +  i *10, 0));
            Projectile projectile = Instantiate(_projectile, pos, Quaternion.Euler(0, hand.eulerAngles.y + 25, 0));
            projectile.SetTarget(damage, _damage);
            projectile.Speed = __speed;
            projectile.LifeTime = _lifeTile;
        }

    }

}
