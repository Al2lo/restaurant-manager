   M S B A M L   `   `   `  ����C  ?Restoreo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:Restoreo.ViewModelsRestoreo.ViewModels  5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089  �� 
TargetType 	  Table �� Property �� Value �� 
TargetType �� Triggers P� Property P� Value �� 
TargetName  img �� Path	 �� UpdateSourceTrigger
 �� Triggers �� Binding �� Value  
AdminTable  imgAdmin  ButtonGetAllOrders �� 	Resources�� 5      D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    :x,http://schemas.microsoft.com/winfx/2006/xaml     5      0
viewModels!clr-namespace:Restoreo.ViewModels  5      %

  &	        &	 �    &	 �    &	 �    &	 �    �� 5      "  ��6   .�5   
   ��  �@�OverridesDefaultStyle . 62   �� 5   
    � ��$ 5q�6#   �� 5   
    � �� 5	      �� 5
      " ��6"   
button��.R�5      �� $��border��6   #��z��5      ._�5      �� $��Center=�6+   $��Center=�6H   5      5       5      P� 5       �@J�IsMouseOver . . �5      �� $ border��6%    �@J�Opacity$	 0.7Q�6L   5      5      5      5      �� 5      "  ��6   .�5   
   ��  � �� 6#   �� $ pathImgFree�$	 PropertyChanged=�
 5   
   �� 5       6   �� $ isEnter�$	 PropertyChanged=� true6`   .a�5      ��  � �� 6+   �� $ pathImgSelect�$	 PropertyChanged=�5      �� 5        6   �� $ isFree�$	 PropertyChanged=�	 false6_   .a�5!      ��  � �� 6+   �� $ pathImgNoFree�$	 PropertyChanged=�5"      5%      �� 5)      "  ��6   .�5*   
   ��  � �� 5+      �� 5,      " ��6"   
button��.R�5-      �� $��border��6   ._�5.      �� $��Center=�6+   $��Center=�6H   5/       50      P� 51       �@J�IsMouseOver . . �52      �� $ border��6%    �@J�Opacity$	 0.7Q�6L   53      55      57      5A      �� 5C      "  ��6   .�5D   
   ��  � �� 6#   �� $ pathImgFree�$	 PropertyChanged=�
 5E   
   �� 5F       6   �� $ isEnter�$	 PropertyChanged=� true6`   .a�5G      ��  � �� 6+   �� $ pathImgSelect�$	 PropertyChanged=�5H      �� 5I       6   �� $ isFree�$	 PropertyChanged=�	 false6_   .a�5J      ��  � �� 6+   �� $ pathImgNoFree�$	 PropertyChanged=�5K      5N      �� 5R      "  ��6   .�5S   
   ��  � �� �#964b006'   �� 5T   
    � ��
 �����6'   �� 5U   
    � ��$ 	30,0,25,0q�6#   �� 5V   
    �@J�Opacity$	 0.9Q�6$   �� 5W   
    � ��$ 30��6"   �� 5X   
    � ��$ 30��6#   �� 5Y   
    � �� 5Z      �� 5[      " ��6"   .R�5\      �� #��z��6   ._�5]      � .+�5^      �� #��z��6/   #��z��6Y   #��z��6�   5_      5`      5a      5c       5d   
   ���� 5e      '��       "  ��6   .�5f      ��  �@��CornerRadius$ 5��61   5g      5h      
 5j   
   P� 5k       �@J�IsMouseOver . . �5l      ��  �@�Cursor$
 Hand��6+   �� 5m       � �� �#D2B48C6/   �� 5n       � ��
 �   �6/   5o      5q      5u      