using CodeBase.StaticData;

namespace CodeBase.Services.StaticData
{
  public interface IStaticDataService : IService
  {
    void LoadMonsters();
    MonsterStaticData ForMonster(MonsterTypeId typeId);
  }
}