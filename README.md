# 关机助手 v4.0.5

## 功能概述：
基础功能支持
> * 开关机时间记录：    
便捷的记录每次开机、关机时间
> * 定时关机：    
可设定想要关机电脑的时间
> * 定时重启：    
可设定想要重启电脑的时间
> * 定时休眠：    
可设定想要休眠电脑的时间
> * 定时睡眠：    
可设定想要睡眠电脑的时间

强大的时间管理系统可以让你轻松对储存的时间记录进行
> * 显示    
可选择显示所有记录或者显示最近的记录
> * 编辑    
在窗格中随性编辑，之后点击提交即可
> * 添加    
按照你的意愿存入数据
> * 删除    
按照你的意愿任意删除一条或多条或全部数据
> * 备份    
支持backup格式与rar格式（自带加密）的一键备份
> * 还原    
支持backup格式与rar格式的一键还原

方法多样、满足各用户的使用习惯。

除了基本的增删改查，还添加了多种多样的高级功能，如：
> * 计算每天的开机次数
> * 计算每月的开机次数
> * 计算每月上机累计时长
> * 计算开关机的时间分布

并能将这些结果使用`数据可视化`功能使用图和表格展现出来，给用户最直观的展示。

高级功能还有
> * 日志管理    
记录每次操作日志，操作有异常可以使用该功能查看
> * 注释管理    
对已有的某一次数据附加或修改解释性说明，解释性文件等等
> * 系统休眠管理    
部分用户尚未开启系统休眠可使用该功能一键开启

日志管理内可以查看每次使用软件的记录以及每次执行数据库操作所用的时长，下方得出平均时长，如果检测到执行时间普遍过长，程序会弹出相应的改善建议；注释管理器中用户可以对已有的记录进行备注，并可以查看以前添加的所有备注内容和添加日期，使得记录的内容丰富多样起来。

为了程序的健壮性，特别增加了数据库锁防止因为操作过频繁而产生程序崩溃。即使程序因为未知原因产生崩溃，软件也内置了异常处理功能，当异常情况发生的时候，程序可以进行有效的异常报告与异常修复，使得程序在修复后可以重新在正常的状态下进行工作。

另外还为程序员用户设置了命令行模式，使得不打开窗体直接向窗体程序传参也能完成部分简单功能。这些简单功能包括：

|     选项      |含义                                                           |示例   |
|-----------    |:-:                                                           |:-:    |
|/s [seconds]   |倒计时关机(秒)                                                 |/s 60  |
|/m [minutes]   |倒计时关机(分钟)                                               |/m 1  |
|/c [string]    |执行成功后弹出的字符串                                          | /m 2.5 /c 150秒后将关机|
|/a             |销毁所有倒计时                                                  |/a|
|/d [minutes]   |记录真正的关机时间<br>(记录的是现在的时间加上<br>设定的分钟后的时间)|/d 40| 
|/k             |记录当前的开机时间                                              |/k
|/k [dbFilename]|记录开机时间写入指定文件                                         |/k D:\\database.mdf

注：根据程序员习惯不同，可使用-代替/，如 -m 1

最后顺便提到，主界面在开发1.x版本时内置了多种隐藏功能，用户可通过以下操作进行探索：
> * 主界面右击设置外观等行为
> * 主界面双击激活开发者动作
> * 确定键右击注册、销毁定时关机行为（每次开机启用该关机倒计时，实现防沉迷功能）。

<br>
当前版本：4.0.5(Form版本) + 1.6.1(Console版本)

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

3.10.5:分析界面表格部分中文化，主界面过渡效果更自然

3.10.6:支持使用RAR备份文件还原数据库，Copyright。

3.10.7:备份文件进行特殊加密，在主页可以释放数据库

3.10.8:重启功能自动取消记录关机时间，在管理界面也可以使用终端版本的关机助手

3.10.9:管理员选项可以设置系统休眠状态

3.11.0:代码优化，主界面添加获得管理员权限功能、添加离线模式（不使用数据库）

3.11.1:注释管理器支持最大化，管理窗口更新完数据自动刷新显示的数据

3.11.2:重启时不再一律不记录下次开机时间而是根据用户勾选而定，提供自定义sql脚本的运行功能(beta)，修复异常窗口退出后程序还在执行的问题

3.11.3:主界面添加睡眠功能。内部流程统配修复了用户名不一样产生的错误。代码优化

3.11.4:在主界面添加了临时禁止开机记录时间功能。自定义sql脚本运行交互完善(beta)，使用sqlite数据库加速访问速度(beta)

3.11.5:修复了部分表格宽度过短导致显示不全的问题，自定义数据库改为外链数据库，在主右击菜单增加外链数据库按钮，并整理了右击菜单内容。最后调整异常处理窗体的逻辑，显得不那么混乱。

3.12.0:数据显示方式不使用默认格式，更加美观自然，而且程序会根据内容自动调整到最佳的显示状态，不会有内容显示不全。还修复了注释管理器刷新后界面变乱的问题。

4.0.0:(测试版本)休眠和待机功能首度支持定时执行。采用缓存技术使主窗口操作速度普遍提升95%，并能在管理主窗口显示清除缓存的进度、查看缓存文件。数据库首次实现了所有系统的适配，所有用户可以享受同样的体验。数据表格都可以显示行索引了。

4.0.1:安全模式加固，完全阻断连接保证离线状态，安全模式支持可逆操作。改善缓存查看功能，增添编辑缓存功能。重整管理主界面的管理员选项。修复了不同版本下数据库插入格式不一导致崩溃，修复了系统时钟格式不同导致的首页时间显示异常，数据可视化画图日期混乱问题。修复了由于不同的系统时钟格式，数据表刷新后每列宽度混论问题。管理主窗口支持拖拽大小，并支持在任意一次刷新后根据内容调整各列的宽度功能。外链数据库快捷功能加入防误拖拽功能。防重复启动功能修改。注释管理器去掉HeaderCell的干扰索引号。数据可视化增快速度。

4.0.2:紧急修复无法插入开机记录的问题，增添缓存功能异常报警。

4.0.3:缓存显示编辑部分代码重构，所有相关功能可视化并移到高级功能选项卡。显示功能支持精准查找显示。

4.0.4:隐秘功能去除。连接数据库后离线功能禁用。主窗口行号宽度、界面宽度自适应。

4.0.5:细节措辞修改。缓存管理在安全模式下不可提交到数据库。

<br>
命令行版本 更新日志：

1.0.0:可以进行快捷关机与快捷取消

1.1.0:可以自定义输出以及添加了按分计时的关机选项

1.2.0:增添真正关机时间记录并关机的选项

1.3.0:支持开机记录

1.3.1:解决了提示框显示过快问题

1.4.0:支持指定数据库文件功能

1.5.0:支持主页面的休眠功能，帮助文档全面优化，修复输出功能问题

1.6.0:对开机记录功能使用了缓存加速，速度提升95%

1.6.1:参数防缺失处理
