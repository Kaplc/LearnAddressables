using System;
using System.Collections;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace L1配置和使用
{
    public class L8_协程和Async关键字异步加载 : MonoBehaviour
    {
        private AsyncOperationHandle<GameObject> handle;

        private void Start()
        {
            Caching.ClearCache();
            StartCoroutine(CoroutineLoad());
            AsyncLoad();
        }

        private IEnumerator CoroutineLoad()
        {
            handle = Addressables.LoadAssetAsync<GameObject>("BossPanel");
            
            while (handle.IsDone == false)
            {
                // 实现进度条
                DownloadStatus status = handle.GetDownloadStatus();
                Debug.Log($"{status.DownloadedBytes}/{status.TotalBytes}");
                Debug.Log(status.Percent);
                yield return null;
            }

            if (handle.Status == AsyncOperationStatus.Succeeded)
            {
                Debug.Log("协程加载资源成功-" + handle.Result.name);
            }
        }

        private async void AsyncLoad()
        {
            AsyncOperationHandle<GameObject> handle2 = Addressables.LoadAssetAsync<GameObject>("BossPanel");
            AsyncOperationHandle<GameObject> handle3 = Addressables.LoadAssetAsync<GameObject>("BossGamePanel");

            await Task.WhenAll(handle2.Task, handle3.Task);

            if (handle2.Status == AsyncOperationStatus.Succeeded)
            {
                Debug.Log("async加载资源成功-" + handle2.Result.name);
            }

            if (handle3.Status == AsyncOperationStatus.Succeeded)
            {
                Debug.Log("async加载资源成功-" + handle3.Result.name);
            }
        }
    }
}