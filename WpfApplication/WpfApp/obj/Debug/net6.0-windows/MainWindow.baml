   M S B A M L   `   `   `  ????A  =WpfApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:WpfAppWpfApp  5   	       WpfApp.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:WpfApp     5   	   -   5          ?Name$  
mainWindow??5
   	   $	??450??5   	   $	??800??6    ? Title 5	   	   ?? *Name+ ? 	Resources 5         boolVisibility??%   &	        ?? 5   
   6'   5      .??5      ?  ? ColumnDefinitions 5   
   ?? 5      ?? 5      .+?5   
   ]? $??0??6   .+?5      ?? $	??Top=?6   $!??Адресная книга??6)   $??Center=?6B   ?? 5      -   5         ??Name$ contacts??5      ??5      ?? *
Contacts+ ?? SelectedItem 5      ?? *SelectedContact+ ?? View 5      ?? 5      .P?5      ?? $??Id??6)    ?? DisplayMemberBinding 65   ?? *Id+?? 5      $??Фамилия??6)    6:   ?? *
LastName+?? 5      $??Имя??6)    66   ?? *	FirstName+?? 5      $??Отчество??6)    6;   ?? *
MiddleName+5       ? ContextMenu 5       ?? 5!      -   5        	 ??Name$
	 menu??5!   "   .@?5"      m? $??Добавить??6#   
 m? Command
 65   ?? *Add+y?6M   ?? *AddVisibility+ ?? 	Converter# [  m? 5#      $??Удалить??6#   
 64   ?? *Delete+ m? CommandParameter 6O   ?? *SelectedContact+y?6|   ?? *DeleteVisibility+# [  m? 5$      $??Изменить??6#   
 65   ?? *Edit+ 6N   ?? *SelectedContact+y?6{   ?? *EditVisibility+# [  m? 5%      $??Подробнее??6#   
 66   ?? *About+ 6P   ?? *SelectedContact+5&      5(      5)      ]? 5*   
   $??1??6   y?6$   ?? *GridVisibility+# [  .+?5+      ?? $	??Top=?6   $??Пользователи??6)   $??Center=?6@   ?? 5,      -   5        $ users??5,      ??5-      ?? *Users+ 5.      ?? *SelectedUser+ 5/      ?? 50      .P?51      ?? $??Пользователь??6)    6?   ?? *
UserName+52       54      ?? 55      .@?56      m? $??Удалить??6#   
 64   ?? *
DeleteUser+ 6S   ?? *SelectedUser+57      59      5:      5;      5<      