   M S B A M L   `   `   `  ����C  ?Restoreo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:Restoreo.ViewsRestoreo.Views  5   	   9!clr-namespace:Restoreo.ViewModelsRestoreo.ViewModels  5   	   $    Restoreo.Views.AllOrdersWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:Restoreo.Views     5   	   8
viewModels!clr-namespace:Restoreo.ViewModels     5   	     � WindowStartupLocation$  Manual=�5	   	    � Left$	 400��5
   
   
 � Top$	 100��6    � WindowStyle$
 None=�5   	    � 
ResizeMode$ CanMinimize=�5   	   
������  � AllowsTransparency .  � Title$ AdminWorkTableWindow��5   	   $	��500��6&   $	��860��63    � 	Resources 5       �� Source�� 5   
   $) #..\Resources\StylesForRegister.xaml?�6   %    	 � DataContext	 5      0  *Restoreo.ViewModels.AllOrdersInfoViewModel  5   
   .��5      �� 
 �� CornerRadius$
 10��6   ���#383235$��1q�64   ._�5   
   �  � RowDefinitions 5      �� 5      $��30 �6    �� 5      $��30 �6    �� 5      .+�5!      � $��0��6   .+�5"      A�  A� Columns$ 2��6   }�.  .+�5#      �� $
��Left=�6    $��30,0,0,0q�6;   $��Center=�6M   $��Restoreo��6h   $��24(�6x   ���#3832356�   �� 5$      $��Right=�6!    �� Orientation$ 
Horizontal=�6=   $��Center=�6V   $��40��6q   $��0,0,10,0q�6}   .+�5%      �� -   5           
TopButtons#��[  5%   !   $��..\Sources\HiddenLine.png��6F   6i   �� 5&      -   5        #��[  5&   !   $��..\Sources\CloseImg.png��6G   6j   5'      5(      5)      � 5+      $��1��6   .+�5,      �� $��Center=�6   $��Center=�69   $��Все заказы��6T   ���#c19a6b$��22(�6{   $��0,0,0,10q�6�   5-      &   System.Windows.Controls.DataGrid  51      $��2��6   
������    AutoGenerateColumns .     
IsReadOnly . ��6=   �� *AdminOrderInfos+   Columns 52      0  *System.Windows.Controls.DataGridTextColumn  53      ,  &System.Windows.Controls.DataGridColumn   Header$ Имя��6)      Width5  /System.Windows.Controls.DataGridLengthConverter$
 0.3* 6U   1  +System.Windows.Controls.DataGridBoundColumn   Binding 66   ��  �� Path$ Login�6e     54      $ Фамилия��6)   $
 0.3* 6]    6:   �� $ 	FirstName�6m     55      $! Номер телефона��6)   $
 0.4* 6a    6A   �� $ Number�6p     56      $ Дата��6)   $
 0.3* 6U    67   �� $
 Date�6d     57      $ 
Время��6)   $
 0.3* 6V    68   �� $
 Time�6e     58      $ ID стола��6)   $
 0.3* 6\    6;   �� $ TableId�6k     59      $ Список блюд��6)   $ 1* 6^    6>   �� $ Dishes�6l   5;      5<      5=      5>      