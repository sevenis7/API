   M S B A M L   `   `   `  ????A  =WpfApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:WpfAppWpfApp  5   	       WpfApp.AddContactWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:WpfApp     5   	   -   5          ?Name$  addContactWindow??5	   	    ? Title$ AddContactWindow??5   	   $	??550??6"   $	??400??6/    ? 	Resources 5
       ?? 
TargetType ?? Property ?? Value??%?  '??       '?? ?     '?? *    ?? 5   
   " ??6   .?5      ??  ? ??$
 15,0q?6'   ?? 5       ? ??$ 30??6'   ?? 5       ? ??$ Center=?6;   ?? 5       ? ??$ 20(?6)   5      ?? 5   
   " ??6   .?5      ??  ? ??$ Center=?6;   ?? 5       ? ??$ 15(?6)   5      ?? 5   
   " ??6   .?5      ??  ? ??$ 6??6)   ?? 5       ? ??$ 15q?6'   5      5      .??5      ?  ? ColumnDefinitions 5   
   ?? 5      ?? 5       ? RowDefinitions 5   
   ?? 5       ?? 5!      ?? 5"      ?? 5#      ?? 5$      ?? 5%      ?? 5&      .+?5(   
   ?? $??0??6   $??2??6"   .+?5)      ?? .??6   Введите фамилию6&   ?? 5*      -   5         ??Name$ lastNametxt??5*      5+      ?? 5,   
   $??1??6   $??2??6"   .+?5-      ?? .??6   Введите имя6!   ?? 5.      -   5        $ firstNametxt??5.      5/      ?? 50   
   $??2??6   $??2??6"   .+?51      ?? .??6   !Введите отчество6&   ?? 52      -   5        $ middleNametxt??52      53      ?? 54   
   $??3??6   $??2??6"   .+?55      ?? .??6   ,*Введите номер телефона6,   ?? 56      -   5        $ phoneNumbertxt??56      57      ?? 58   
   $??4??6   $??2??6"   .+?59      ?? .??6   Введите адрес6#   ?? 5:      -   5        $ 	addrestxt??5:      5;      ?? 5<   
   $??5??6   $??2??6"   .+?5=      ?? .??6   !Введите описание6&   ?? 5>      -   5        $ descriptiontxt??5>      5?      ?? 5@   
   $??0??6   $??Добавить??6!   ??64   ?? *Add+??6L   ?? 	 ?? ElementName$	 addContactWindow??6?   ?? 5A   
   $??1??6   $??Отмена??6!   ??62   ?? *Cancel+??6M   ?? $	 addContactWindow??6?   5B      5C      