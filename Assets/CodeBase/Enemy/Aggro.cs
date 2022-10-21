using System.Collections;
using UnityEngine;

namespace CodeBase.Enemy
{
  public class Aggro : MonoBehaviour
  {
    public TriggerObserver TriggerObserver;
    public Follow Follow;

    public float Cooldown;
    private bool _hasAggroTarget;

    private WaitForSeconds _switchFollowOffAfterCooldown;
    private Coroutine _aggroCoroutine;

    private void Start()
    {
      _switchFollowOffAfterCooldown = new WaitForSeconds(Cooldown);
      
      TriggerObserver.TriggerEnter += TriggerEnter;
      TriggerObserver.TriggerExit += TriggerExit;

      Follow.enabled = false;
    }

    private void OnDestroy()
    {
      TriggerObserver.TriggerEnter -= TriggerEnter;
      TriggerObserver.TriggerExit -= TriggerExit;
    }

    private void TriggerEnter(Collider obj)
    {
      if(_hasAggroTarget) return;
      
      StopAggroCoroutine();

      SwitchFollowOn();
    }

    private void TriggerExit(Collider obj)
    {
      if(!_hasAggroTarget) return;
      
      _aggroCoroutine = StartCoroutine(SwitchFollowOffAfterCooldown());
    }

    private void StopAggroCoroutine()
    {
      if(_aggroCoroutine == null) return;
      
      StopCoroutine(_aggroCoroutine);
      _aggroCoroutine = null;
    }

    private IEnumerator SwitchFollowOffAfterCooldown()
    {
      yield return _switchFollowOffAfterCooldown;
      
      SwitchFollowOff();
    }

    private void SwitchFollowOn()
    {
      _hasAggroTarget = true;
      Follow.enabled = true;
    }

    private void SwitchFollowOff()
    {
      Follow.enabled = false;
      _hasAggroTarget = false;
    }
  }
}