using UnityEngine;

namespace App.Platform
{
    public interface IPlatformService
    {
        Bounds PlatformBounds { get; }
    }
}