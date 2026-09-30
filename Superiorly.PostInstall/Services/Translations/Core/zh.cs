namespace Superiorly.PostInstall.Services;

public static partial class TranslationService
{
    private static readonly Dictionary<string, string> SectionTitles_zh = new()
    {
 ["home"]="主页", ["browsers"]="浏览器", ["tools"]="工具", ["tweaking"]="系统调整", ["troubleshooting"]="故障排除" 
    };
    private static readonly Dictionary<string, string> SectionDescs_zh = new()
    {
 ["home"]="欢迎使用您的工具箱", ["browsers"]="浏览器相关工具和修复", ["tools"]="下载并运行便携式工具", ["tweaking"]="驱动、GPU和系统调整。", ["troubleshooting"]="快速切换和系统修复。" 
    };
    private static readonly Dictionary<string, string> TabTitles_zh = new()
    {
 ["mainstream"]="主流", ["privacy"]="隐私", ["forks"]="分支和自定义", ["software"]="软件", ["store-downloader"]="Microsoft Store 下载器", ["utilities"]="实用工具", ["amd"]="AMD", ["nvidia"]="NVIDIA", ["registry"]="注册表调整", ["win32"]="Win32PrioritySeparation", ["powerplans"]="电源计划", ["connectivity"]="网络连接", ["devices"]="设备", ["security"]="安全", ["gaming"]="游戏", ["ai"]="人工智能", ["debloat"]="Debloat", ["system"]="系统" , ["telemetry"]="Telemetry"
    };
    private static readonly Dictionary<string, string> Notifications_zh = new()
    {
 ["opened"]="已打开 - 已启动", ["installed"]="安装成功", ["failed"]="安装失败", ["open_failed"]="打开失败", ["enabled"]="已启用", ["disabled"]="已禁用", ["apply_failed"]="应用失败", ["applied"]="已应用" , ["telemetry"]="Telemetry"
    };
    private static readonly Dictionary<string, string> Ui_zh = new()
    {

            ["settings"]="设置", ["language"]="语言", ["theme"]="主题", ["dark"]="深色", ["light"]="浅色", ["auto"]="自动", ["default_theme"]="默认主题",
            ["style"]="样式", ["win10_style"]="Windows 10 样式", ["win11_style"]="Windows 11 样式", ["close"]="关闭",
            ["search_placeholder"]="按名称、URL 或 ID 搜索。", ["store_no_results"]="未找到结果。请尝试其他搜索。", ["search"]="搜索", ["install"]="安装",
            ["run"]="运行", ["download"]="下载", ["apply"]="应用",
            ["check_updates"]="检查更新", ["update"]="Update", ["disclaimer"]="修改由您自行负责。",
            ["quantum_title"]="Quantum 映射", ["quantum_subtitle"]="所有有效的 Win32PrioritySeparation 值。单击一行即可应用。",
            ["open_quantum"]="打开 Quantum 映射", ["current_win32"]="当前 Win32PrioritySeparation",
            ["load_list"]="加载列表", ["unload_list"]="关闭列表", ["activate"]="激活", ["import"]="导入", ["export"]="导出",
            ["select_all"]="全选", ["unselect_all"]="取消全选", ["uninstall"]="卸载", ["delete"]="删除",
            ["restore_default"]="恢复默认值", ["yes"]="是", ["no"]="否",
            ["searching_for"]="正在搜索“{0}”...", ["downloading"]="正在下载 {0}...", ["starting"]="正在启动 {0}...",
            ["applying"]="正在应用 {0}...", ["installing"]="正在安装 {0}...",             ["loading"]="正在加载 {0}...",
            ["reading_plans"]="正在读取电源计划...", ["populating_list"]="正在生成列表...",
            ["apps_found"]="找到 {0} 个应用", ["nothing_found"]="未找到任何内容", ["loaded_items"]="已加载 {0} 项",
            ["list_unloaded"]="列表已清空",
            ["exported"]="已导出 {0}",
            ["installed_n"]="已安装 {0} 个应用", ["install_failed"]="安装失败",
            ["failed_admin"]="失败 - 请以管理员身份运行或重启", ["failed"]="失败",
            ["win32_set"]="Win32PrioritySeparation 已设为 {0}",
        
    };
    private static readonly Dictionary<string, string> OptionLabels_zh = new()
    {
 ["run"]="运行", ["download"]="下载", ["apply"]="应用", ["enable"]="启用", ["disable"]="禁用", ["search"]="搜索", ["install"]="安装", ["load list"]="加载列表", ["uninstall"]="卸载", ["activate"]="激活", ["delete"]="删除", ["import .pow"]="导入 .pow", ["default"]="默认", ["custom"]="自定义", ["minimum"]="最小", ["disable mmcss"]="禁用 MMCSS", ["bypass"]="绕过", ["repeater"]="中继", ["realtime"]="实时", ["high"]="高", ["abovenormal"]="高于正常", ["normal"]="正常", ["belownormal"]="低于正常", ["enhanced"]="增强", ["legacy"]="旧版", ["disabled"]="已禁用", ["enabled"]="已启用", ["alwayson"]="始终开启", ["alwaysoff"]="始终关闭", ["optin"]="选择加入", ["optout"]="选择退出", ["open cru"]="打开 CRU", ["coming soon"]="即将推出", ["safe fivem/minecraft services"]="安全的 FiveM/Minecraft 服务", ["kernelos default"]="Superiorly 默认" , ["telemetry"]="Telemetry"
    };
    private static readonly Dictionary<string, string> UiExtra_zh = new()
    {
["state_on"]="开", ["state_off"]="关", 
            ["confirm_delete"]="确认删除",
            ["confirm_enable"]="要应用此更改吗？",
            ["delete_plans"]="删除 {0} 个电源计划？",
            ["cant_delete_active"]="无法删除正在使用的电源计划。请先切换到其他计划。",
            ["import_plan"]="导入电源计划", ["export_plan"]="导出电源计划",
            ["ratio"]="比例", ["long"]="长", ["short"]="短", ["fixed"]="固定", ["variable"]="可变", ["boost"]="加速", ["current"]="当前",
            ["needs_admin"]="此操作需要管理员权限。",
            ["restart_driver"]="重启显示驱动", ["reset_all"]="全部重置", ["download_cru"]="下载 CRU",
            ["modify_quantum"]="修改 Quantum", ["quantum_length"]="Quantum 长度", ["quantum_interval"]="Quantum 间隔",
            ["fix"]="固定", ["preview_hex"]="十六进制预览", ["preview_bits"]="二进制预览",
            ["minimize"]="最小化", ["maximize"]="最大化", ["toggle_theme"]="切换浅色 / 深色主题",
            ["follow_theme"]="跟随 Windows 主题", ["square"]="直角", ["rounded"]="圆角",
            ["join"]="加入", ["follow"]="关注", ["visit"]="访问", ["copy_link"]="复制链接", ["copied"]="已复制",
            ["no_profiles_found"]="未找到配置文件。请将 .nip 文件放入 Nvidia Profiles 文件夹。",
            ["confirm_disable"]="禁用此保护吗?",
            ["home_discord_desc"]="Superiorly Community",
            ["home_instagram_desc"]="@sebastianportella",
            ["home_github_desc"]="chiLL-Gekk0",
            ["security"]="安全：", ["power_plan_filter"]="电源计划",
            ["theme_changed"]="主题已切换为{0}", ["style_changed"]="样式已切换为{0}",
            ["powerplan_custom"]="自定义", ["powerplan_restore"]="恢复官方",
            ["update_available"]="有可用更新 {0}", ["new_update"]="新版本：{0}", ["up_to_date"]="已是最新版本", ["update_check_failed"]="无法检查更新",
        
    };
}
