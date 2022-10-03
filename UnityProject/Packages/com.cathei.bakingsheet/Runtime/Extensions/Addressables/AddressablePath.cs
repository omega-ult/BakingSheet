// BakingSheet, Maxwell Keonwoo Kang <code.athei@gmail.com>, 2022

#if BAKINGSHEET_ADDRESSABLES

using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Cathei.BakingSheet.Internal;
using Better.StreamingAssets;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Cathei.BakingSheet.Unity
{
    public partial class AddressablePath
    {
        private AsyncOperationHandle _handle;

        public AsyncOperationHandle<T> LoadAsync<T>() where T : UnityEngine.Object
        {
            if (!this.IsValid())
                return default;

            if (!_handle.IsValid())
            {
                var handle = Addressables.LoadAssetAsync<T>(FullPath);
                _handle = handle;
                return handle;
            }

            return _handle.Convert<T>();
        }

        public T Get<T>() where T : UnityEngine.Object
        {
            if (!_handle.IsValid())
                return null;

            return _handle.Result as T;
        }

        public void Release()
        {
            if (!_handle.IsValid())
                return;

            Addressables.Release(_handle);
            _handle = default;
        }
    }
}

#endif