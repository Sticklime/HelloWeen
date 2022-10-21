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
    event Action HeroCreated;
    GameObject CreateHud();
    List<ISavedProgressReader> ProgressReaders { get; }
    List<ISavedProgress> ProgressWriters { get; }
    GameObject HeroGameObject { get; }
    void Cleanup();
  }
}