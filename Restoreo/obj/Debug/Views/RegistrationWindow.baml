   M S B A M L   `   `   `  ����C  ?Restoreo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:RestoreoRestoreo  5   	   9!clr-namespace:Restoreo.ViewModelsRestoreo.ViewModels  5   	   !    Restoreo.RegistrationWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:Restoreo     5   	   7	viewModel!clr-namespace:Restoreo.ViewModels     5   	     � Title$  
MainWindow��5	   	   $	��600��6   $	��400��6)    � WindowStyle$
 None=�5
   	    � 
ResizeMode$ CanMinimize=�5   	    � WindowStartupLocation$ CenterScreen=�5   	   
������  � AllowsTransparency .  � DataContext 5      /  )Restoreo.ViewModels.RegistrationViewModel  5   
    � 	Resources 5       �� Source�� 5   
   $) #..\Resources\StylesForRegister.xaml?�6   %    .��5      �� ���#faebd7 �� CornerRadius$ 10��5      ._�5   
   � 	 � RowDefinitions	 5      �� 5       $��40 �6    6.   �� 5!      $	��180 �6    6/   �� 5"      $��40 �6    6.   �� 5#      6"   �� 5$      $	��120 �6    6/   .+�5(      � $��0��6   .+�5)      A� 
 A� Columns$
 2��6   .+�5*      ��    SettingButtons#���   6   $
��Left=�6F   $��70��6�   $��	20,0,10,0q�6�   ��6a   �� *ReversSignCommand+��6�   �� *SignOrRegist+6�   �� 5+       �� Orientation$ 
Horizontal=�6!   $��Right=�6:   $��40��6V   $��Bottom=�6b   .+�5,      �� -   5          
TopButtons#��[ 5,       $��..\Sources\HiddenLine.png��6F   6j   �� 5-      -   5        #��[ 5-       $��..\Sources\CloseImg.png��6F   6j   5.      5/      50      � 51      $��1��6   .+�52      �� $��Restoreo��6   $��60(�6,   $��Center=�6:   $��Center=�6W   ���#d1b28a6r   53      � 54      $��2��6   .+�55      A� $
 3��6   .+�56      �� �� 57      $��Center=�6A   $��Center=�6^   $��18(�6y   $��10,0,0,0q�6�    J� Opacity$	 0.6Q�6�   ��6    �� *EnterButtonText+6�   �� 58      #���   6   $��Right=�6q   $��0,0,30,0q�6�   $��60��6�   ��6F   �� *UserTypeReverseCommand+��6�   �� *
UserType+59      5:      � 5;      $��3��6   .+�5<      �� $��2��6   .+�5=      �   InputTextGridStyle#��[ 6   $��60��6H   .+�5>      �� $	��335��6$   $��16��60   $	��Top=�6<   $��
Логин��6T   6c   �� 5?      -   5        $��TextBoxLogin��5?   �     InputTextStyle#���  6"   ��6K   �� *Login+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�6�   �� 5@        
LinesLogin#���  6   �� 5A        
ErrorsText#��[ 6$   ��6H   �� *MessageLogin+$ TwoWay=�6u   5B      � 5C      #��[ 6   $��60��6G   .+�5D      �� $	��335��6$   $��16��60   $	��Top=�6<   $��Пароль��6T   6d   �� 5E      -   5        $��TextBoxPassword��5E   �   #���  6"   ��6K   �� *
Password+$ TwoWay=�$ PropertyChanged=�6�   �� 5F        LinesPassword#��[ 6   �� 5G      #��[ 6$   ��6H   �� *MessagePassword+6k   5H      �� 5I      $ 
Horizontal=�6!   .+�5J      �� $��50,0,0,0q�6#   $��20��65   $
��Left=�6@   $��Bottom=�6[    � Cursor$
 Hand��6v    d� 	IsChecked 6�   �� *Check+6�   �� 5K      $��20,0,0,0q�6$   $	��300��66   $;��5Пользовательское соглашение��6B   $��16(�6e   6u   5L      5M      5N      � 5O      $��4��6   .+�5P      ��   ButtonEnter#���  6   ��6?   �� *RegisterCommand+��6c   �� *EnterButtonText+6�   5Q      5R      5T      5U      