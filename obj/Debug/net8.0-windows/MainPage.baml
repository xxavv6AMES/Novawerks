   M S B A M L   `   `   `  ����e  aMicrosoft.Web.WebView2.Wpf, Version=1.0.2739.15, Culture=neutral, PublicKeyToken=2a8ab48044d2601ekLclr-namespace:Microsoft.Web.WebView2.Wpf;assembly=Microsoft.Web.WebView2.WpfMicrosoft.Web.WebView2.Wpf  5       NovawerksApp   NovawerksApp.MainPage   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      \wv2Lclr-namespace:Microsoft.Web.WebView2.Wpf;assembly=Microsoft.Web.WebView2.Wpf     5        N� 
Background  �#121212 N� 
Foreground �#E0E0E0.��5      �  � ColumnDefinitions 5
   
   �� 5      $	��230 �6   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5      ]� $��0��6   $��0��6   $��3��6)   $
��True��6=   ���#1F1F1F$��30��6g   .+�5      o� $
��Left=�6   ���#1F1F1F���#E0E0E0$	��Top=�6G   .@�5      m� $��_File��6   .@�5   
   m� -   5        $��_Exit��5       m� InputGestureText$ Alt+F4��6"   ���#B0B0B06W   5      m� 5      $��_Edit��6   .@�5   
   m� -   5        $��_Undo��5      $ Ctrl+Z��6"   ���#B0B0B06W   m� 5   
   -   5        $��_Redo��5      $ Ctrl+Y��6"   ���#B0B0B06W   5      m� 5      $��_View��6   .@�5   
   m� -   5        $��_Refresh��5      $ F5��6%   ���#B0B0B06Y   5       m� 5!      $��_Account��6   .@�5"   
   m� -   5        $��_Login��5"      ���#B0B0B06=   m� 5#   
   -   5        $��_Logout��5#      ���#B0B0B06?   5$      m� 5&      $��_Help��6   .@�5'   
   m� -   5        $��_Help Center��5'      $ Ctrl+H��6)   ���#B0B0B06^   5(      5)      5*      �� 5.   
   -   5         ��Name$ LeftMenu��5.      ���#2F2F2F$	��230��68   $��1��6D   $��0��6Q   $��Stretch=�6a   ._�5/      ]� $
��True��6   .+�50      �� $	��Top=�6   .+�51      �� -	   5         ��Name$ MainPageMenuItem��51       $
��Home��6:   $��10q�6F    �� Padding$ 10q�6R   ���#CCCCCC � Cursor$
 Hand��6t   $��16(�6�   $��Medium"�6�      xGFF#��[  6�   �� 52      -
   5        $ ForumPageMenuItem��52       $��Forums��6;   $��10q�6I   $ 10q�6U   ���#CCCCCC$
 Hand��6w   $��16(�6�   $��Medium"�6�   #��[  6�   �� 53      -   5        $ NWASPageMenuItem��53       $��NW Addon Store��6:   $��10q�6P   $ 10q�6\   ���#CCCCCC$
 Hand��6~   $��16(�6�   $��Medium"�6�   #��[  6�   54      �� 57      -   5        	 ��Name$	 SettingsButton��57      $��Settings��61   $��40��6D   ���#FFA500
�������$��Bottom=�6x   $��10q�6�   #��[  58   6   $
��Bold"�6Y   59      5:      � 5=   
   $��1��6   $��1��6   $��20q�6,   .+�5>      �� $��Hidden=�6   $��Hidden=�6@   .��5?      �� .+�5A      �� $��
Welcome...��6    $��24(�62   $
��Bold"�6@   $��0,0,0,20q�6R   ���#E0E0E0#��[  6y   �� 5B      $D��>Sup? Find everything you need and want, right here in the NDE!��6    $��16(�6f   $��0,0,0,20q�6t   ���#B0B0B0#��[  6�   �� 5E   
   ���#2F2F2F
 �� Padding$
 15q�6&   $��0,0,0,20q�63   ._�5F      �� .+�5G      �� $��My Novawerks ID��6    $��24(�67   $
��Bold"�6E   ���#E0E0E0#��[  6l   �� 5J   
   -   5         ��Name$ UserProfilePicture��5J      $��50��6,   $��50��67   $��	0,10,0,10q�6C   �� 5M      -   5        $ UsernameTextBlock��5M       $��18(�6;   ���#B0B0B0#��[  6^   �� 5N      -   5        $ EmailTextBlock��5N       $��16(�68   ���#B0B0B0#��[  6[   5O      5P      �� 5S      ���#2F2F2F$
 15q�62   $��0,0,0,20q�6?   ._�5T      �� .+�5U      �� $��Latest Update:��6(   $��24(�6>   $
��Bold"�6L   ���#E0E0E0#��[  6s   �� 5V      $��	v0.9.0-EA��6(   $��20(�69   $��SemiBold"�6G   ���#B0B0B0#��[  6r   �� 5W      ${��uThe 5th primary EarlyAccess release of the Novawerks Desktop Experience!
Check out the full changelog on our website.��6(   $��14(�6�   ���#B0B0B0#��[  6�   �� 5X      �� 5Y   "   -   5        $+��%https://werks.nova.xxavvgroup.com/nde?�5Y   ,   .�6�   .�5Z   &   �� $��Read about this update��60   ���#FFA500#��[  6c   5[   #   5\      5]      5^      �� 5a      ���#2F2F2F$
 15q�62   $��0,0,0,20q�6?   ._�5b      �� .+�5c      �� $��Novawerks Forums & Blog��6(   $��24(�6K   $
��Bold"�6Y   ���#E0E0E0#��[  6�   �� 5d      $7��1Join us there! We'd be so happy if you showed up.��6(   $��20(�6a   $��SemiBold"�6o   ���#B0B0B0#��[  6�   �� 5e      $c��]Check out the link below to get started. We have a wonderful blog and a great live community!��6(   $��14(�6�   ���#B0B0B0#��[  6�   �� 5f      �� 5g   "   -   5        $(��"https://forums.nova.xxavvgroup.com?�5g   ,   .�6�   .�5h   &   �� $ ��CHECK OUT NOVAWERKS FORUMS��60   ���#FFA500#��[  6g   5i   #   5j      5k      5l      �� 5o      ���#2F2F2F$
 15q�62   $��0,0,0,20q�6?   ._�5p      �� .+�5q      �� $��Addon Launcher��6(   $��22(�6>   $
��Bold"�6L   ���#E0E0E0#��[  6s   $��0,0,0,10q�6�   �� 5s      ���#FFA500$
 50q�6:   $��Center=�6G   ._�5t   "   �� $��Main App��6,   $��18(�6<   
�������$��Center=�6]   5u      5v      5w      5x      5y       � 5{      -   5        $��ContentFrame��5{      $��Stretch=�6    $��Stretch=�6>     � NavigationUIVisibility$ Hidden=�6Z   5|      �� 5   
   ���#1F1F1F$��2��6&   $��0��63   $��3��6C   $��30��6W   $��Bottom=�6c   ._�5�      �� $@��:Novawerks Desktop Experience ©2024 Novawerks & xxavv6AMES��6   $��Center=�6]   $��Center=�6z   ���#CCCCCC#��[  6�   5�      5�      5�      