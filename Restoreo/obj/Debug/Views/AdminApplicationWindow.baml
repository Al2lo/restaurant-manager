   M S B A M L   `   `   `  ����C  ?Restoreo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:Restoreo.ViewsRestoreo.Views  5   	   9!clr-namespace:Restoreo.ViewModelsRestoreo.ViewModels  5   	   +    %Restoreo.Views.AdminApplicationWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:Restoreo.Views     5   	   8
viewModels!clr-namespace:Restoreo.ViewModels     5   	     � WindowStartupLocation$  CenterScreen=�5	   	    � WindowStyle$
 None=�5
   	    � 
ResizeMode$ CanMinimize=�5   	   
������  � AllowsTransparency .  � Title$ AdminApplicationWindow��5   	   $	��700��6(   $
��1200��65    � 	Resources 5       �� Source�� 5   
   $) #..\Resources\StylesForRegister.xaml?�6   %    .��5      �� ���#383235 �� CornerRadius$ 30��6"   ._�5   
   �  � RowDefinitions 5      �� 5      $��30 �6    6.   �� 5      6"   �� 5      $��25 �6    6.   .+�5      � $��0��6   .+�5      A� 	 A� Columns$	 2��6   }�.  .+�5      �� $
��Left=�6    $��20,0,0,0q�6;   $��Center=�6M   $��Restoreo��6h   $��24(�6x   ���#D2B48C6�   �� 5       $��Right=�6!   
 �� Orientation$
 
Horizontal=�6=   $��Center=�6V   $��40��6q   $��0,0,10,0q�6}   .+�5!      �� -   5           
TopButtons#��[  5!   !   $��..\Sources\HiddenLine.png��6G   6j   �� 5"      -   5        #��[  5"   !   $��..\Sources\CloseImg.png��6G   6j   5#      5$      5%      � 5'      $��1��6   ���#dec9ad � ColumnDefinitions 5(      �� 5)      $	��240 �6'   65   �� 5*      6)   .+�5.      �� ���#4a3432$��10,20q�6.   $��0q�6=   $ 25��6Q   ._�5/      � $��0��6   $��10,0,0,0q�6,   .+�50      �� $
 Vertical=�6%   $��Center=�6<   $��0,40,0,0q�6Y   .+�51      ��  � Cursor$
 Hand��6F   $
��Left=�6T   $!��Выбор столиков��6w   $��22(�6�   
������ $��0q�6�   ���#D2B48C$��5,40,5,0q�6�   ��6%   �� *MoveToTables+6�   �� 52      $
 Hand��6E   $
��Left=�6S   $��Выбор блюд��6u   $��24(�6�   
������ $��0q�6�   ���#D2B48C$��5,40,5,0q�6�   ��6%   �� *
MoveToMenu+6�   �� 53        AccantButtons#��[ 6?   $��
0,370,0,20q�6f   $��Center=�6z   $��
Выйти��6�   ��6%   �� *Leave+6�   54      55      56      � 57      $��2��6   $	��850��6'   $��
40,20,0,20q�63   .+�58       �   � NavigationUIVisibility$ Hidden=�5;        � Source 59      �� *Source+��5:      �� *	Content+5;      5<      5=      5>      5?      5@      