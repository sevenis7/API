   M S B A M L   `   `   `  ????A  =WpfApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:WpfAppWpfApp  5   	       WpfApp.RegistrationWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:WpfApp     5   	   -   5          ?Name$  registrationWindow??5	   	    ? Title$ RegistrationWindow??5   	   $	??500??6$   $	??400??61    ? 	Resources 5
       ?? 
TargetType ?? Property ?? Value   boolVisibility??%~  '??       '?? ?     &	  M    ?? 5   
   " ??6   .?5      ??  ? ??$ Center=?6;   ?? 5       ? ??$ 15(?6)   ?? 5       ? ??$ 5q?6'   5      ?? 5   
   " ??6   .?5      ??  ? ??$
 15,0q?6'   ?? 5       ? ??$ 30??6'   ?? 5       ? ??$ Center=?6;   ?? 5       ? ??$ 20(?6)   5      ?? 5   
   6'   5      .??5      ?  ? RowDefinitions 5   
   ?? 5      ?? 5      ?? 5      ?? 5      ?? 5      .+?5    
   ?? $??0??6   .+?5!      ?? $4??.Введите имя пользователя??6   ?? 5"      -   5         ??Name$ userNametxt??5"      5#      ?? 5$   
   $??1??6   .+?5%      ?? $!??Введите пароль??6   G? 5&      -   5         G?Name$ passbox??5&      $??15q?6+   $??30??67   $??20(?6C   	 G? PasswordChar$		 •??6Q   $??Center=?6b   5'      ?? 5(   
   $??2??6   .+?5)      ?? $%??Повторите пароль??6   G? 5*      -   5        $ confirmPassbox??5*      $??15q?62   $??30??6>   $??20(?6J   $		 •??6X   $??Center=?6i   5+      ?? 5,   
   -   5        
 ??Name$
 radio??5,   "   $??3??6   .+?5-      	? -   5         	?Name$ admin??5-       	? 	GroupName$
 role??6)   $??Admin??6:   $??20(?6J   	? 5.      -   5        $
 user??5.      $
 role??6(   $
??User??69   $??20(?6H   5/      ? 50   
   $??4??6    ? ColumnDefinitions 51      ?? 52      ?? 53      .+?55      ?? $??0??6   $??40,20q?6%   $??Регистрация??64   $??15(?6J   ??6X   ?? *RegistrationCommand+??6?   ??  ?? ElementName$ registrationWindow???? 56      $??1??6   $??40,20q?6%   $??Отмена??64   $??15(?6E   ??6S   ?? *CancelCommand+??6u   ?? $ registrationWindow??57      58      59      