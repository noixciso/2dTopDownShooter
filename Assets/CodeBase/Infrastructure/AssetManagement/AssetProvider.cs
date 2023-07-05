using UnityEngine;

namespace CodeBase.Infrastructure.AssetManagement
{
    public class AssetProvider : IAssetProvider
    {
        public GameObject Instantiate(string path)
        {
            return Resources.Load<GameObject>(path).gameObject;
        }

        public GameObject Instantiate(string path, Vector3 transformPosition)
        {
            return Resources.Load<GameObject>(path);
        }
    }
}