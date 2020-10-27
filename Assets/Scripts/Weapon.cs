using UnityEngine;

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

}
