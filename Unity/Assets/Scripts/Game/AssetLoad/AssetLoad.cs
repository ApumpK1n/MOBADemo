using UnityEngine;

namespace Pumpkin
{
    public static class AssetLoad
    {
        public static T Load<T>(string path) where T : Object
        {
            return Resources.Load<T>(path);
        }
    }
}