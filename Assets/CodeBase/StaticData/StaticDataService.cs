﻿namespace CodeBase.StaticData
{
    public class StaticDataService : IStaticDataService
    {
        // private Dictionary<ItemTypeId, BuildingStaticData> _producedResources;
        //
        // public void LoadResources()
        // {
        //     _producedResources = Resources.LoadAll<BuildingStaticData>("StaticData/Buildings")
        //         .ToDictionary(x => x.ProducedTypeId, x => x);
        // }
        //
        // public BuildingStaticData ForProducedItems(ItemTypeId typeId) => 
        //     _producedResources.TryGetValue(typeId, out BuildingStaticData staticData) ? staticData : null;
        public void LoadResources()
        {
           
            
        }
    }
}