   M S B A M L   `   `   `  ����C  ?Restoreo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:Restoreo.ViewsRestoreo.Views  5   	   9!clr-namespace:Restoreo.ViewModelsRestoreo.ViewModels  5   	   &     Restoreo.Views.ApplicationWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:Restoreo.Views     5   	   7	viewModel!clr-namespace:Restoreo.ViewModels     5   	     � WindowStartupLocation$  CenterScreen=�5	   	    � WindowStyle$
 None=�5
   	    � 
ResizeMode$ CanMinimize=�5   	   
������  � AllowsTransparency .  � Title$ ApplicationWindow��5   	   $	��700��6#   $
��1200��60    � DataContext 5      4  .Restoreo.ViewModels.ApplicationWindowViewModel  5   
    � 	Resources 5       �� Source�� 5   
   $) #..\Resources\StylesForRegister.xaml?�6   %    .��5      �� ���#383235 �� CornerRadius$ 30��6"   ._�5   
   � 	 � RowDefinitions	 5      �� 5      $��30 �6    �� 5      �� 5      $��25 �6    .+�5       � $��0��6   .+�5!      A� 
 A� Columns$
 2��6   }�.  .+�5"      �� $
��Left=�6    $��20,0,0,0q�6;   $��Center=�6M   $��Restoreo��6h   $��24(�6x   ���#D2B48C6�   �� 5#      $��Right=�6!    �� Orientation$ 
Horizontal=�6=   $��Center=�6V   $��40��6q   $��0,0,10,0q�6}   .+�5$      �� -   5           
TopButtons#��[  5$   !   $��..\Sources\HiddenLine.png��6G   6j   �� 5%      -   5        #��[  5%   !   $��..\Sources\CloseImg.png��6G   6j   5&      5'      5(      � 5*      $��1��6   ���#dec9ad � ColumnDefinitions 5+      �� 5,      $	��240 �6'   65   �� 5-      $	��19* �6'   65   �� 5.      $	��11* �6'   .+�52      �� ���#4a3432$��10,20,10,20q�6.   $��0q�6C   $ 25��6W   ._�53      � $��0��6   $��10,0,0,0q�6,   .+�54      �� $ Vertical=�6%   $��Center=�6<   $��0,40,0,0q�6Y   .+�55      ��   	MenuPunct#��[ 6F    � Cursor$
 Hand��6j   $
��Left=�6x   $!��Выбор столиков��6�   $��22(�6�   
������ $��0q�6�   ���#D2B48C$��5,40,5,0q�6  ��6%   �� *MoveToTables+6  �� 56      $
 Hand��6E   $
��Left=�6S   $��Выбор блюд��6u   $��24(�6�   
������ $��0q�6�   ���#D2B48C$��5,40,5,0q�6�   ��6%   �� *
MoveToMenu+6�   �� 57      $
 Hand��6D   $
��Left=�6R   $��
Бронь��6t   $��24(�6�   
������ $��0q�6�   ���#D2B48C$��5,40,5,0q�6�   ��6%   �� *	MoveToEnd+6�   �� 58      $
 Hand��6H   $
��Left=�6V   $��Аккаунт��6x   $��24(�6�   
������ $��0q�6�   ���#D2B48C$��5,40,5,0q�6�   ��6%   �� *MoveToAccaunt+6�   59      5:      5;      � 5<      $��1��6   $	��850��6'   $��75,20,35,20q�63   $��2��6H   .+�5=       �   � NavigationUIVisibility$ Hidden=�5@        � Source 5>      �� *Source+��5?      �� *	Content+5@      5A      5B      5C      5D      5E      