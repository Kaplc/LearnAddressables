using System;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace L1配置和使用
{
    public class L3_AssetReference: MonoBehaviour
    {
        #region 提供到Inspector窗口绑定

        public AssetReference genericAR; // 通用
        public AssetReferenceAtlasedSprite atlasAR; // 图集
        public AssetReferenceGameObject objAR; // GameObject
        public AssetReferenceSprite spriteAR; // 精灵
        public AssetReferenceTexture textureAR; // 
        public AssetReferenceTexture2D texture2dAR; // 
        public AssetReferenceTexture3D texture3dAR; //
        public AssetReferenceT<GameObject> tAR; // 泛型

        #endregion

        private void Start()
        {
            #region 异步加载绑定到字段的资源

            AsyncOperationHandle genericHandle = genericAR.LoadAssetAsync<GameObject>();
            // 异步加载完成回调
            genericHandle.Completed += handle =>
            {
                // 判断是否加载成功
                if (handle.Status == AsyncOperationStatus.Succeeded)
                {
                    Debug.Log("generic加载成功");
                    Addressables.Release(handle);
                }
                else
                {
                    Debug.Log("generic加载失败");
                }
            };
            
            // 泛型
            AsyncOperationHandle<GameObject> tHandle = objAR.LoadAssetAsync();
            tHandle.Completed += handle =>
            {
                // 判断是否加载成功
                if (handle.Status == AsyncOperationStatus.Succeeded)
                {
                    Debug.Log("tHandle加载成功");
                    Addressables.Release(handle);
                }
                else
                {
                    Debug.Log("tHandle加载失败");
                }

            };

            #region 加载场景

            // genericAR.LoadSceneAsync().Completed += handle =>
            // {
            //     
            // };

            #endregion

            #region 直接实例化

            objAR.InstantiateAsync();

            #endregion

            #region 旧版本实现泛型

            //自定义类 继承AssetReferenceT<Material>类 即可自定义一个指定类型的标识类
            //该功能主要用于Unity2020.1之前，因为之前的版本不能直接使用AssetReferenceT泛型字段

            #endregion

            #endregion

            #region 释放资源
            // 加载完成才能释放            
            // Addressables.Release(genericAR);

            #endregion
        }
    }
}