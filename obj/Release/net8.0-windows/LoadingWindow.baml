   M S B A M L   `   `   `  ����   NovawerksApp     NovawerksApp.LoadingWindow   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml       � WindowStartupLocation$  CenterScreen=� � WindowStyle$
 None=� � AllowsTransparency$
 True��
������  � SizeToContent$ WidthAndHeight=�.���� 
���   � �� CornerRadius$ 10�� �� Padding$ 20q�._��� $��Center=�$��Center=�.+�� .+�� $��Center=�$��Center=�.+�A� $��50��$��50��
��� ���$��5�� J� RenderTransformOrigin$ 0.5,0.5&�z��� -   spinnerRotateTransform�� �� Angle$ 0Q�A� $��30��$��30��
���   �$��5��
���   ��� $��Starting NDE��
�������$��16(�$��Center=�$��Bottom=�$��	20,60,0,0q� � 	Resources    LoadingAnimation	 g� RepeatBehavior
 �� 
TargetName �� TargetProperty W� From	 W� To g� Duration��%h   &	        �� $	 Forever��.��W� $
 spinnerRotateTransform��$ Angle� 0 360$ 0:0:2D� � Triggers :�  :� RoutedEvent$ Window.Loaded��.[��� #��[  