namespace L1配置和使用
{
    public class L6_配置文件参数
    {
        #region AddressableAssetSettings

        // Profile In Use：可以在这选择使用的是哪一套配置文件
        // Manage Profiles：点击它会打开管理配置文件窗口
        
        // Diagnostics:诊断
        // Send Profiler Events：启用分析器事件，启用它后我们可以在Event Viewer窗口查看Addressable相关信息
        // Log Runtime Exceptions：记录运行时加载相关的异常
        
        // 目录相关设置，将资源的地址映射到其物理位置
        // Player Version Override：重写用于制定远程目录名称的时间戳
        // 如果不设置默认使用时间戳作为远程目录命名
        // Compress Local Catalog：在压缩的AssetBundle文件中生成目录。可以压缩大小，但是会增加生成和加载的时间
        // Optimize Catalog Size：通过为内部ID创建查找表来减小目录的大小。会增加加载目录所需的时间
        
        // Content Update：内容更新
        // Disable Catalog Update on Startup：当可寻址系统在运行时初始化时，禁用自动检查更新的远程目录。您可以手动检查更新的目录。
        // Content State Build Path：在何处生成由默认生成脚本生成的内容状态文件。
        // Build Remote Catalog：构建远程目录 // 勾选后会出现新选项
       
        //Build & Load Paths：
        // 在何处生成和加载远程目录。从列表中选择一个配置文件路径，如果要分别设置生成路径和加载路径，请选择<custom>。
        // 仅在启用生成远程目录时可见
        // Build Path：远程构建路径，在何处构建远程目录。通常，应该使用RemoteBuildPath配置文件变量。
        // 仅当将生成和加载路径设置为<custom>时显示。
        // Load Path：远程加载路径，用于访问远程目录的URL。通常，应该使用RemoteLoadPath配置文件变量。
        // 仅当将生成和加载路径设置为<custom>时显示。
        // Path Preview：路径预览

        #endregion

        #region 组配置

        // Can Change Post Release：可以改变发行后内容，该模式不移动任何资源，如果包中的任何资源发生了更改，则重新构建整个包
        // Cannot Change Post Release：无法改变发布后内容，如果包中任何资源已经改变，
        // 则[检查内容更新限制]工具会将其移动到为更新创建的新组中。在进行更新构建时，
        // 从这个新组创建的AssetBundles中的资产将覆盖现有包中的版本。
        
        // Asset Bundle Compression：AB包的压缩方式，默认为LZ4，它通常是最有效的选项，建议使用
        // Uncompressed：不压缩，包较大，不推荐
        // LZ4：压缩，相对LZMA大一点点，建议使用，用什么解压什么，内存占用低
        // LZMA：压缩最小，解压慢，用一个资源要解压所有
        
        // Include In Build：包含在构建中，是否在内容生成中包含此组中的资源。如果取消勾选，那么在选择打包时，不会打包该组内容
        
        // Use Asset Bundle Cache：使用AB包缓存，是否缓存远程分发的包
        
        // Asset Bundle CRC：是否在加载前验证AB包的完整性
        // Disabled：永远不检查完整性
        // Enabled，Including Cached：检查完整性，包括缓存也检查
        // Enabled，Excluding Cached：检查完整性，但是不检查缓存的包
        
        // Include Addresses in Catalog：是否将地址字符串包括在目录中。如果不使用地址字符串在组中加载资产，则可以通过不包括它们来减小目录的大小。
        
        // Include GUIDs in Catalog：是否在目录中包含GUID字符串。您必须包含guid字符串才能使用资产参考。如果不使用AssetReferences或GUID字符串在组中加载资产，则可以通过不包括它们来减小目录的大小。
        
        // Include Labels in Catalog：是否在目录中包含标签字符串。如果不使用标签在组中加载资产，则可以通过不包括这些资产来缩小目录的大小。
        
        // Internal Asset Naming Mode：如何在内部命名目录中的资源
        // Full Path：全路径
        // FileName：文件名
        // GUID：资源的Guid字符串
        // Dynamic：Addressables根据组中的资源选择最小的内部名称
        
        // Cache Clear Behavior：确定安装的应用程序何时从缓存中清除AB包
        // Clear When Space Is Needed In Cache：在缓存中需要空间时清除
        // Clear When When new Version Loaded：加载新版本时清楚
        
        // Bundle Mode：打包模式，如何将此组中的资产打包到包中
        // Pack Together：创建包含所有资产的单个包
        // Pack Separately：为组中的每个主要资产创建一个包。如精灵图片中的精灵图片被包装在一起。添加到组中的文件夹中的资产也打包在一起
        // Pack Together by Label：为共享相同标签组合的资产创建一个包
        
        // Asset Load Mode：资源加载模式
        // Requested Asset And Dependencies：请求的资源和依赖项
        // All Packed Assets And Dependencies：所有包中的资源和依赖项
        
        #endregion
        
        #region 整包更新
        //组设置为 Can Change Post Release
        //整包更新指，某一个分组的资源发生变化后
        //我们需要将其整体进行打包
        //这种方式比较适用于大范围资源更新时使用

        //注意：Unity自带的 资源服务器模拟工具有问题 有的时候明明开启了服务 但是加载不成功
        //我们干脆就使用第三方工具来搭建我们的模拟本地资源服务器
        #endregion

        #region 局部更新
        //组设置为 Cannot Change Post Release
        //局部更新指，当组中有资源发生变化时
        //我们可以单为发生变化的内容生成AB包
        //之后使用该资源时，Addressables会自动加载最新的内容
        //它相对整包更新来说，更节约时间和流量
        #endregion
    }
}