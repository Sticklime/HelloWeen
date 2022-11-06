using System;
using CodeBase.Data;
using CodeBase.Enemy;
using CodeBase.Logic;
using CodeBase.Services;
using CodeBase.Services.Input;
using CodeBase.Services.PersistentProgress;
using UnityEngine;

namespace CodeBase.Hero
{
  [RequireComponent(typeof(HeroAnimator), typeof(CharacterController))]
  public class HeroAttack : MonoBehaviour, ISavedProgressReader
  {
    public HeroAnimator Animator;
    public CharacterController CharacterController;

    private IInputService _inputService;

    private static int _layerMask;
    private Collider[] _hits = new Collider[3];
    private Stats _stats;

    private void Awake()
    {
      _inputService = AllServices.Container.Single<IInputService>();

      _layerMask = 1 << LayerMask.NameToLayer("Hittable");
    }

    private void Update()
    {
      if(_inputService.IsAttackButtonUp() && !Animator.IsAttacking)
        Animator.PlayAttack();
    }

    private void OnAttack()
    {
      PhysicsDebug.DrawDebug(StartPoint() + transform.forward, _stats.DamageRadius, 1.0f);
      for (int i = 0; i < Hit(); ++i)
      {
        _hits[i].transform.parent.GetComponent<IHealth>().TakeDamage(_stats.Damage);
      }
    }

    private int Hit() => 
      Physics.OverlapSphereNonAlloc(StartPoint() + transform.forward, _stats.DamageRadius, _hits, _layerMask);

    private Vector3 StartPoint() =>
      new Vector3(transform.position.x, CharacterController.center.y / 2, transform.position.z);

    public void LoadProgress(PlayerProgress progress)
    {
      _stats = progress.HeroStats;
    }
  }
}