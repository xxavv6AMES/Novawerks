   M S B A M L   `   `   `  ����  NovawerksApp     NovawerksApp.LoadingWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � WindowStartupLocation$  CenterScreen=�5   	    � WindowStyle$
 None=�5   	    � AllowsTransparency$
 True��5   	   
������  � SizeToContent$ WidthAndHeight=�5   	   .��5      �� 
���   � �� CornerRadius$ 10��6     �� Padding$ 20q�62   ._�5   
   �� $��Center=�6   $��Center=�62   .+�5      � .+�5      � $��Center=�6   $��Center=�64   .+�5      A� $��50��6   $��50��6)   
��� ���$��5��6E    J� RenderTransformOrigin$ 0.5,0.5&�5      z�5      �� 5      -   5        spinnerRotateTransform�� �� Angle$ 0Q�5   N   5      A� 5      $��30��6   $��30��6)   
���   �$��5��6D   
���   �6X   5      �� 5      $��Starting NDE��6   
�������$��16(�6C   $��Center=�5      $��Bottom=�69   $��	20,60,0,0q�6T   5      5      5       � 	Resources 5"         LoadingAnimation	 g� RepeatBehavior
 �� 
TargetName �� TargetProperty W� From	 W� To g� Duration��%�   &	        �� 5#   
   $	 Forever��6.   .��5$      W� $
 spinnerRotateTransform��6   $ Angle�5%       05&       3606'   $ 0:0:2D�60   5'      5(       � Triggers 5+      :� 5,   
    :� RoutedEvent$ Window.Loaded��6   .[�5-      �� #��[  6   5.      50      