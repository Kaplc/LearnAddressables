namespace L1配置和使用
{
    public class L5_Profiles
    {
        //所有的变量类型都是string字符串类型
        //你可以在其中填写一些固定的路径或值来决定路径
        //还可以使用两个语法指示符让原本的静态属性变成动态属性

        //[]:方括号，可以使用它包裹变量，在打包构建时会计算方括号包围的内容
        //比如
        //使用自己的变量[BuildTarget]
        //使用别的脚本中变量[UnityEditor.EditorUserBuildSettings.activeBuildTarget]
        //在打包构建时，会使用方括号内变量对应的字符串拼接到目录中

        //{}:大括号，可以使用它包裹变量，在运行时会计算大括号包围的内容
        //比如
        //使用别的脚本中变量{UnityEngine.AddressableAssets.Addressables.RuntimePath}

        //注意：方括号和大括号中使用的变量一定是静态变量或者属性。名称、类型、命名空间必须匹配
        //比如在运行时 UnityEditor编辑器命名空间下的内容是不能使用的

        #region 参数
        
        // Profile：概述文件
        // Variable：变量（所有概述文件通用）
        // Build Load Path Variables：构建加载路径变量（所有概述文件通用）
        
        // 右边
        //     BuildTarget：构建目标，可以在这里设置是哪个平台，默认是你激活哪个平台就是哪个平台
        //     LocalBuildPath：本地构建路径，默认在项目的Library库文件夹中
        //     LocalLoadPath：本地加载路径，在哪里加载本地已有的资源
        //     RemoteBuildPath：远程构建路径
        //     RemoteLoadPath：远程加载路径，在哪里下载远程内容和目录
        //
        //     注意：
        // 1.一般情况下，不要去修改本地构建和加载路径默认值
        // 2.当我们针对不同平台远程分发内容时，通过多个配置文件最方便。如果你想要最终的发布包包含所有内容，那么一个默认配置就够了
        #endregion
    }
}