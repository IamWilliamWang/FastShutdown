# 关机助手

## 功能概述：
支持
> * 开关机时间记录
> * 定时关机
> * 定时重启
> * 休眠功能
> * 数据的导入与导出

强大的时间管理系统可以让你轻松对储存的时间记录进行
> * 显示
> * 编辑
> * 添加
> * 修改
方法多样、满足各用户的使用习惯。

除了基本的增删改查，还添加的多种多样的高级功能，如：
> * 计算每天的开机次数
> * 计算每月的开机次数
> * 计算每月上机累计时长
> * 计算开关机的时间分布
并能将这些结果使用`图和表格展现`出来给用户最直观的展示。

高级功能还有
> * 日志管理
> * 注释管理
日志管理内可以查看每次使用软件的记录以及每次执行数据库操作所用的时长，下方得出平均时长，如果检测
到执行时间普遍过长，程序会弹出相应的改善建议；注释管理器中用户可以对已有的记录进行备注，并可以查看以前添加的所有备注内容和添加日期，使得
记录的内容丰富多样起来。

另外还为程序员用户设置了命令行模式，使得不打开窗体也能完成部分简单功能。这些简单功能包括：

|     选项      |含义                                                           |示例   |
|-----------    |:-:                                                           |:-:    |
|/s [seconds]   |倒计时关机(秒)                                                 |/s 60  |
|/m [minutes]   |倒计时关机(分钟)                                               |/m 1  |
|/c [string]    |执行成功后弹出的字符串                                          | /m 2.5 /c 150秒后将关机|
|/a             |销毁所有倒计时                                                  |/a|
|/d [minutes]   |记录真正的关机时间<br>(记录的是现在的时间加上<br>设定的分钟后的时间)|/d 40| 
|/k             |记录当前的开机时间                                              |/k
|/k [dbFilename]|记录开机时间写入指定文件                                         |/k D:\\database.mdf

最后，为了开发的便捷，内置多种隐藏功能，用户可通过以下操作进行探索：
> * 主界面右击设置外观等行为
> * 主界面双击激活开发者动作
> * 确定键右击注册、销毁定时关机行为（每次开机启用该关机倒计时，用于防沉迷）。

当前版本：3.10.4(Form版本) + 1.4(Console版本)

更新日志：

1.0.0:菜单栏基本选项构建完成，支持关机、重启、取消指令、退出

1.0.1:栏内增加了自定义选项，可以通过自定义选项设置任意的关机时间；增加了退出按钮

1.0.2:修复了自定义选项内只支持输入整形的问题

1.1.0:增加了程序的主题界面。可通过主界面完成之前的操作

1.2.0:增加了强大的右键功能。主界面右键包含【透明度，任务栏显示，退出】和确认键右键【注册关机事件，销毁关机事件，打开启动文件夹】

1.2.1:将“任务栏显示”功能改为“隐匿”功能。主程序的界面显示改为默认不隐匿

1.2.2:修复因权限不足导致注册事件失败。增加菜单栏右键【应用App】

1.2.3:防止误触立即关机

1.3.0:增加定时关机，用户可选择要关机的具体时间，而不是倒计时多少分钟

1.3.1:修复1.3的错误，增加菜单右菜单增加【帮助】

1.3.2:增加了开发者模式，将【帮助】移至主界面

1.3.3:取消防误触功能，Enter键可以代替确认按钮，q键取消任务，Esc键可以退出

1.4.0:改善弹窗外观，修复IME模式禁止出现中文

2.0.0:添加记录开关机的功能。新建全新的管理界面

2.1.0:关机可以计算时长并记录，计算当天次数。修复了时间插入失败的问题

2.2.0:开机程序修复并大大优化速度。

2.3.0:支持数据的全部导出到excel功能

2.6.0:可以统计出每个月使用的累计时间，调整数据库管理的界面与菜单

2.7.0:滚轮操作支持，支持在面板内更新数据

2.8.0:标题显示时间，修改管理器启动按钮

3.0.0:统计窗体全面升级，软件全面翻新

3.1.4:备份还原功能完美实现，性能优化

3.1.6:添加了开发者模式，可以直接使用SQL语句管理数据库（仅限开发者用户）

3.2.0:使用多线程实现了软件零卡顿，实现了终端模式

3.2.5:开启数据库日志功能

3.3.0:添加了日志管理

3.3.1:增加数据库稳定性

3.3.5:增加了报告错误的窗体，便于检查与反馈错误

3.5.0:增加了休眠模式，主页可以方便的插入开机时间

3.5.1:正式改名为关机助手，修复因卡顿产生的错误

3.5.2:查询功能微调，报错窗口微调

3.5.4:添加删除任意条记录的功能

3.5.5:增加延缓模式，可以储存真正关机的时间

3.6.0:数据可视化界面添加开关机时间分析，并将该界面微调

3.6.2:支持界面最大化，查询功能由查询10条改为15条

3.7.0:将数据库文件导向至软件所在文件夹，添加了欢迎页面与自动初始化的功能，数据管理页面微调

3.7.1:修复日志管理中可能存在数据量过大而产生的数值溢出的问题

3.7.2:数据可视化默认图形改变，优化开发者模式

3.7.3:当执行需要管理员权限的操作，程序可以询问后自己获取管理员权限

3.8.0:主界面隐藏不常用功能，并将退出改为显示拓展功能。日志窗口设置为不可变长宽。重启时不再调用开机启动程序，节省系统资源也省去需要手动删除记录的操
作。

3.8.1:手动添加关机时间后，选择填充空处可以进行填充时长栏。改进异常处理

3.9.0:增加了注释管理器，可以对单条数据进行添加和修改注释。数据管理界面调整

3.9.1:主界面快捷栏调整。管理员选项中增添查看数据库连接文件和状态的选项。删除全部功能完善

3.9.2:修复了选择休眠状态下滚动鼠标报错的问题，增添了针对报错框的调试功能（强制报错）

3.9.3:首次在主管理窗口中添加“添加一条关机记录”，错误弹窗能显示更全面的信息

3.9.4:支持了使用winrar进行数据库备份的功能

3.9.5:界面细节优化，注释管理器添加选项卡清爽界面，优化显示信息

3.9.6:对主界面添加拓展功能动画，注释管理器的修改功能问题修复

3.9.7:注释管理器会判断序号是否合法。将mdf数据库文件拖入主页面可以载入该数据库而不是载入默认数据库。

3.10.0:注释管理器使用Unicode编码技术支持中文输入。数据库相关代码重构

3.10.1:注释管理器修复了Unicode显示异常的问题，不再对非中文字符进行转化。并对确认修改功能作出相应的调整

3.10.2:分析界面切换到分析时间分布时不再重置图像为柱状图。并修复了初始化数据库不可用的问题。

3.10.3:对于硬盘速度较慢的用户，在日志管理内提供合理建议以提高软件使用速度。

3.10.4:主界面菜单栏调整，界面提示修改，删除不必要的部分。异常处理窗口可快捷退出。
