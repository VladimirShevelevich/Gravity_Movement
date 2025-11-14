using UnityEngine;

namespace App.Platform
{
    public class PlatformFactory 
    {
        private readonly PlatformContent _platformContent;

        public PlatformFactory(PlatformContent platformContent)
        {
            _platformContent = platformContent;
        }
        
        public PlatformView Create()
        {
            return Object.Instantiate(_platformContent.PlatformPrefab).
                GetComponent<PlatformView>();
        }
    }
}