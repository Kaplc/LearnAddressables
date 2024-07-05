namespace L1配置和使用
{
    public class L2_使用
    {
        #region 知识点一 让资源变为可寻址资源
        //方法一：选中资源，勾选Inspector窗口中的Addressable
        //方法二：选中资源，拖入Addressables Groups窗口中
        
        //一些常用的各类型的资源
        //1.GameObject预设体
        //2.精灵图片
        //3.图集
        //4.贴图
        //5.材质球
        //6.配置文件（json、xml、txt、2进制）
        //7.Lua脚本
        //8.音效
        //9.Animator Controller 动画状态机控制文件
        //10.场景
        
        //注意：
        //1.C#代码无法作为可寻址资源
        //2.Resources文件夹下资源如果变为寻址资源，会移入Resources_moved文件夹中
        //  原因：Resources文件夹下资源会最终打包出去，如果变为可寻址资源意味着想通过Addressables进行管理
        //  那么它就没有必要通过Resources方式去加载和打包，所以会自动迁移，避免重复打包，浪费空间

        //右键选择资源时菜单内容
        //Move Addressables to Group：将该资源放入到现有的另一个组中
        //Move Addressables to New Gourp：使用与当前组相同设置创建一个新租，并将该资源放入该新组中
        //Rmove Addressables：移除资源，该资源会变为不可寻址资源
        //Simplify Addressable Names：简化可寻址资源名，会删除名称中的路径和拓展，简化缩短名称
        //Copy Address to Clipboard：将地址复制到剪贴板
        //Change Address：改名
        //Create New Group：创建新租
        #endregion

        #region 知识点二 资源组窗口讲解

        #region 资源信息（关键）
        //1.GroupName\Addressable Name：分组名\可寻址名（可重名，描述资源）
        //2.Path：路径（不可重复，资源定位）
        //3.Labels：标签（可重复、可用于区分资源种类，例如青铜装备、黄金装备）
        #endregion

        #region 创建分组相关
        //Create——>Group
        //Packed Assets:打包资源分组
        //Blank(no schema):空白（无架构）
        //区别：Packed Assets默认自带默认打包加载相关设置信息，Blank没有相关信息需要自己关联

        //组对于我们来说意义重大，之后在资源打包时，一个组可以作为一个或多个AB包

        //关于组设置相关信息，之后详细讲解
        #endregion

        #region 选中某一组后右键
        //Remove Group(s):移除组，组中所有资源恢复为不可寻址资源
        //Simplify Addressable Names:简化可寻址名称，会删除名称中的路径和拓展，简化缩短名称
        //Set as Default:设置为默认组，当直接勾选资源中的Addressable时，会自动加入该组
        //Inspect Group Setting:快速选中关联的组相关配置文件
        //Rename:重命名
        //Create New Group:创建新组
        #endregion

        #region 配置概述相关
        //Manage Profiles：管理配置文件
        //可以配置打包目标、本地远程的打包加载路径等等信息（之后再详细讲解）
        #endregion

        #region Tools工具相关
        //Inspect System Settings：检查系统设置
        //Check for content Update Restrictions:检查内容更新限制
        //Window：打开Addressables相关窗口
        //Groups View：分组视图相关
        //  Show Sprite and Subobject Addressable：显示可寻址对象的精灵和子对象，一般想要看到图集资源内内容时可以勾选该选项
        //  Group Hierarchy with Dashes：带破折号的组层次结构
        #endregion

        #region Play Mode Script播放模式脚本（编辑模式下如何运行）
        //确定在编辑器播放模式下运行游戏时，可寻址系统如何访问可寻址资源
        //Use Asset Database（fastest）：
        //使用资源数据库（最快的），一般在开发阶段使用，使用此选项时，您不必打包可寻址内容，它会直接使用文件夹中的资源
        //在实际开发时，可以不使用这种模式，这种模式没有测试的意义

        //Simulate Groups（advanced）：
        //模拟组（后期），一般在测试阶段使用，分析布局和依赖项的内容，而不创建AB包
        //通过ResourceManager从资产数据库加载资产，就像通过AB包加载一样
        //通过引入时间延迟，模拟远程资产绑定的下载速度和本地绑定的文件加载速度
        //在开发阶段可以使用这个模式来进行资源加载

        //Use Existing Build（requires built groups）：
        //正儿八经的从AB包加载资源
        //使用现有AB包（需要构建AB包），一般在最终发布测试阶段使用
        //从早期内容版本创建的AB包加载资产
        //在使用此选项之前，必须使用生成脚本（如默认生成脚本）打包资源
        //远程内容必须托管在用于生成内容的配置文件的RemoteLoadPath上
        #endregion

        #region Build（构建打包相关）
        //New Build：构建AB包资源（相当于打包资源分组）
        //Update a Previour Build：更新以前的版本
        //Clean Build：清空之前的构建资源
        #endregion

        #endregion

        #region 知识点三 资源名注意事项
        //1.资源路径一定不允许相同（后缀不同，名字相同可以）
        //2.资源名我们可以随意修改
        //3.之后在加载资源时我们可以使用名字和标签作为双标识加载指定资源
        #endregion

        #region 知识点四 资源分组
        //我们可以按规则将资源进行分组
        //比如：角色、装备、怪物、UI等等
        #endregion
    }
}