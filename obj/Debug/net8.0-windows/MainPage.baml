   M S B A M L   `   `   `  ����e  aMicrosoft.Web.WebView2.Wpf, Version=1.0.2739.15, Culture=neutral, PublicKeyToken=2a8ab48044d2601ekLclr-namespace:Microsoft.Web.WebView2.Wpf;assembly=Microsoft.Web.WebView2.WpfMicrosoft.Web.WebView2.Wpf  5       NovawerksApp   NovawerksApp.MainPage   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      \wv2Lclr-namespace:Microsoft.Web.WebView2.Wpf;assembly=Microsoft.Web.WebView2.Wpf     5        N� 
Background  �#121212 N� 
Foreground �#E0E0E0.��5      �  � ColumnDefinitions 5	   
   �� 5
      $	��230 �6   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   ]� $��0��6   $��0��6!   $��3��61   $
��True��6E   ���#1F1F1F$��30��6o   .+�5      o� $
��Left=�6   ���#1F1F1F���#E0E0E0$	��Top=�6S   .@�5      m� $��_File��6   .@�5      m� -   5        $��_Exit��5       m� InputGestureText$ Alt+F4��6.   ���#B0B0B06c   5      m� 5      $��_Edit��6   .@�5      m� -   5        $��_Undo��5      $ Ctrl+Z��6.   ���#B0B0B06c   m� 5      -   5        $��_Redo��5      $ Ctrl+Y��6.   ���#B0B0B06c   5      m� 5      $��_View��6   .@�5      m� -   5        $��_Refresh��5      $ F5��61   ���#B0B0B06e   5      m� 5       $��_Account��6   .@�5!      m� -   5        $��_Login��5!      ���#B0B0B06I   m� 5"      -   5        $��_Logout��5"      ���#B0B0B06K   5#      m� 5$      $��_Help��6   .@�5%      m� -   5        $��_Help Center��5%      $ Ctrl+H��65   ���#B0B0B06j   5&      5'      5(      �� 5+   
   -   5         ��Name$ LeftMenu��5+      ���#2F2F2F$	��230��68   $��1��6D   $��0��6Q   $��Stretch=�6a   ._�5,      ]� $
��True��6   .+�5-      �� $	��Top=�6   .+�5.      �� -	   5         ��Name$ MainPageMenuItem��5.       $
��Home��6:   $��10q�6F    �� Padding$ 10q�6R   ���#CCCCCC � Cursor$
 Hand��6t   $��16(�6�   $��Medium"�6�   6�   �� 5/      -
   5        $ ForumPageMenuItem��5/       $��Forums��6;   $��10q�6I   $ 10q�6U   ���#CCCCCC$
 Hand��6w   $��16(�6�   $��Medium"�6�   6�   �� 50      -   5        $ NWASPageMenuItem��50       $��NW Addon Store��6:   $��10q�6P   $ 10q�6\   ���#CCCCCC$
 Hand��6~   $��16(�6�   $��Medium"�6�   6�   51      �� 52      -   5        	 ��Name$	 SettingsButton��52      $��Settings��61   $��40��6D   ���#FFA500
�������$��Bottom=�6x   $��10q�6�   $
��Bold"�53   6   54      55      � 58   
   $��1��6   $��1��6   $��20q�6,   .+�59      �� $��Hidden=�6   $��Hidden=�6@   .��5:      �� .+�5<      �� $��
Welcome...��6    $��24(�62   $
��Bold"�6@   $��0,0,0,20q�6R   ���#E0E0E06d   �� 5=      $D��>Sup? Find everything you need and want, right here in the NDE!��6    $��16(�6f   $��0,0,0,20q�6t   ���#B0B0B06�   �� 5@      ���#2F2F2F
 �� Padding$
 15q�62   $��0,0,0,20q�6?   ._�5A      �� .+�5B      �� $��My Novawerks ID��6(   $��24(�6?   $
��Bold"�6M   ���#E0E0E06_   �� 5C      -   5         ��Name$ UserProfilePicture��5C   $   $��50��6@   $��50��6K   $��	0,10,0,10q�6W   �� 5D      -   5        $ UsernameTextBlock��5D   (   $��18(�6C   ���#B0B0B06Q   �� 5E      -   5        $ EmailTextBlock��5E   (   $��16(�6@   ���#B0B0B06N   5F      5G      �� 5J      ���#2F2F2F$
 15q�62   $��0,0,0,20q�6?   ._�5K      �� .+�5L      �� $��Latest Update:��6(   $��24(�6>   $
��Bold"�6L   ���#E0E0E06^   �� 5M      $��	v0.9.0-EA��6(   $��20(�69   $��SemiBold"�6G   ���#B0B0B06]   �� 5N      ${��uThe 5th primary EarlyAccess release of the Novawerks Desktop Experience!
Check out the full changelog on our website.��6(   $��14(�6�   ���#B0B0B06�   �� 5O      �� 5P   "   -   5        $+��%https://werks.nova.xxavvgroup.com/nde?�5P   ,   .�6�   .�5Q   &   �� $��Read about this update��60   ���#FFA5006N   5R   #   5S      5T      5U      �� 5X      ���#1F1F1F$��2��62   $��0��6?   $��3��6O   $��30��6c   $��Bottom=�6o   ._�5Y      �� $@��:Novawerks Desktop Experience ©2024 Novawerks & xxavv6AMES��6$   $��Center=�6i   $��Center=�6�   ���#CCCCCC6�   5Z      5[      5\      5]      5^      5_      