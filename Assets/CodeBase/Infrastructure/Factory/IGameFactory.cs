using System;
using System.Collections.Generic;
using CodeBase.Infrastructure.Services;
using CodeBase.Infrastructure.Services.PersistentProgress;
using UnityEngine;

namespace CodeBase.Infrastructure.Factory
{
  public interface IGameFactory:IService
  {
    GameObject CreateHero(GameObject at);
    GameObject CreateHud();
    List<ISavedProgressReader> ProgressReaders { get; }
    GameObject HeroGameObject { get; }
    event Action HeroCreated; 
    List<ISavedProgress> ProgressWriters { get; }
    void Cleanup();
  }
}