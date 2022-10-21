using System;
using CodeBase.Data;
using CodeBase.Infrastructure.Factory;
using CodeBase.Infrastructure.Services;
using UnityEngine;
using UnityEngine.AI;

namespace CodeBase.Enemy
{
  public class AgentMoveToPlayer : Follow
  {
    private const float MinimalDistance = 1;
    
    public NavMeshAgent Agent;
    
    private Transform _heroTransform;
    private IGameFactory _gameFactory;

    private void Start()
    {
      _gameFactory = AllServices.Container.Single<IGameFactory>();

      if (_gameFactory.HeroGameObject != null)
        InitializeHeroTransform();
      else
        _gameFactory.HeroCreated += HeroCreated;
    }

    private void Update()
    {
      if(IsInitialized() && IsHeroNotReached())
        Agent.destination = _heroTransform.position;
    }

    private void OnDestroy()
    {
      if(_gameFactory != null)
        _gameFactory.HeroCreated -= HeroCreated;
    }

    private bool IsInitialized() => 
      _heroTransform != null;

    private void HeroCreated() =>
      InitializeHeroTransform();

    private void InitializeHeroTransform() =>
      _heroTransform = _gameFactory.HeroGameObject.transform;

    private bool IsHeroNotReached() => 
      Agent.transform.position.SqrMagnitudeTo(_heroTransform.position) >= MinimalDistance;
  }
}