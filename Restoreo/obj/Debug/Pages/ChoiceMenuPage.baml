   M S B A M L   `   `   `  ����C  ?Restoreo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:Restoreo.PagesRestoreo.Pages  5      #clr-namespace:RestoreoRestoreo  5      9!clr-namespace:Restoreo.ViewModelsRestoreo.ViewModels  5	      #    Restoreo.Pages.ChoiceMenuPage   5      @i:http://schemas.microsoft.com/expression/2010/interactivity  5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .localclr-namespace:Restoreo.Pages     5      0contextHolderclr-namespace:Restoreo     5      7	viewModel!clr-namespace:Restoreo.ViewModels     5	        N� Title$  ChoiceMenuPage��5       � 	Resources 5       �� MergedDictionaries �� Source�� 5   
    5      �� 5      $" ..\Resources\NenuStalys.xaml?�6%   %    5      .��5      ��  �� CornerRadius$ 20��6   ���#383235._�5   
   �  � RowDefinitions 5      �� 5      $��80 �6    6.   �� 5      6"   .+�5      � $��0��6   .+�5       �� $ 10��6   $��2q�6+   
���   �$	��600��6S   $��30��6_   
�������._�5!      ��  �� Orientation$ 
Horizontal=�6!   $��5,0,0,0q�6:   .+�5"      �� $��30��6    $��30��6+   .��5#      �� $��/Sources/SearchImage.png��6$   $��20��6F   $��30��6Q   5$      � 5%      .+�5&      �� $��Search��6(   $��18(�66      SearchBlock#��[  6D    J� Opacity$	 0.6Q�6i   �� 5'        	SearchBox#��[ 6&   ��6I   �� *
SearchText+ �� UpdateSourceTrigger$ PropertyChanged=�	 �� Mode$	 TwoWay=�5(      5)      5*      5+      � 5-      $��1��6   .+�5.      �� $ 20��6   $��2q�6+   $��
60,0,60,40q�6@   
���   �._�5/      �� 
������ $��0q�67   
������ $��Hidden=�6�   $��Disabled=�6�   ��6e   �� *Dishes+
 �� SelectedItem
 6�   �� *SelectedDish+��50      �� 51       �� 
TargetType" ��6$    �� Triggers 52   "   P� 53   &    P� Property �@J�IsKeyboardFocusWithin P� Value . . �54   *   ��  �� Property �@��
IsSelected �� Value . 6G   55   '   .�57   "   ��  � �� 58   &   �� 59   *    �� 
TargetType" ��6:   .R�5:   .   �� 5;   +   5=   #   5>      ��5@      �� 5A   "   .R�5B   "   �� $ 10��6)   $��80��6<   $
��20,5q�6I   ���#D2B48C._�5C   *   �  � ColumnDefinitions 5D   .   �� 5E   2   6E   �� 5F   2   $��40 �6C   6P   .+�5H   .   � $��0��63   .+�5I   2   A�  A� Rows$ 2��6>   $
��20,0q�6G   .+�5J   6   � .+�5K   :   A�  A� Columns$ 2��6F   $��Center=�6R   .+�5L   >   �� $��16(�6�   $
��Bold"�6�   ��6H   ��  �� Path$
 Name� �� StringFormat$ Назавание:  {0}��6�   �� 5M   >   $��Right=�6�   $��14(�6�   $
��Bold"�6�   ��6H   �� $ Coast�$ Цена: {0} p��6�   5N   ;   5O   7   �� 5P   2   $
��Wrap=�6<   $
��Left=�6�   $	��500��6�   $��10(�6�   ��6P   �� *Description+$ Состав: {0}��6�   5Q   3   5R   /   � 5S   .   $��1��63   .+�5T   2   A� $ 3��6>   $	��0,5q�6G   .+�5U   2   ��   AddDishButton#��[ 69   (   "Restoreo.ViewModels.MenusViewModel   
AddCommand#��Z 6`   $��23��6�    � Cursor$
 Hand��6�   $��14(�6�   $��+��6�   �� 5V   2     	CountDish#���  6S   $��Center=�6w   $��Center=�6�   $��13��6�   ��6<   �� *count+6�   �� 5W   2   #��[ 69      DeleteCommand#��Z 6`   $��23��6�   $
 Hand��6�   $��14(�6�   $��-��6�   5X   /   5Y   /   5Z   +   5[   '   5\   #   5_      5a      5b      5c      5d      5e      