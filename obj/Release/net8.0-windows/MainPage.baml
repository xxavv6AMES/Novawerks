   M S B A M L   `   `   `  ���� e  aMicrosoft.Web.WebView2.Wpf, Version=1.0.2739.15, Culture=neutral, PublicKeyToken=2a8ab48044d2601ekLclr-namespace:Microsoft.Web.WebView2.Wpf;assembly=Microsoft.Web.WebView2.WpfMicrosoft.Web.WebView2.Wpf   NovawerksApp   NovawerksApp.MainPage   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     \wv2Lclr-namespace:Microsoft.Web.WebView2.Wpf;assembly=Microsoft.Web.WebView2.Wpf       N� 
Background  �#121212 N� 
Foreground �#E0E0E0.���  � ColumnDefinitions �� $	��230 ��� $��* ��� $	��200 � � RowDefinitions �� $
��Auto ��� $��* ��� $
��Auto �.+�]� $��0��$��0��$��3��$
��True�����#1F1F1F$��30��.+�o� $
��Left=����#1F1F1F���#E0E0E0$	��Top=�.@�m� $��_File��.@�m� -   $��_Exit�� m� InputGestureText$ Alt+F4�����#B0B0B0m� $��_Edit��.@�m� -   $��_Undo��$ Ctrl+Z�����#B0B0B0m� -   $��_Redo��$ Ctrl+Y�����#B0B0B0m� $��_View��.@�m� -   $��_Refresh��$ F5�����#B0B0B0m� $��_Help��.@�m� -   $��_Help Center��$ Ctrl+H�����#B0B0B0�� $��Right=� �� Orientation$ 
Horizontal=�$��Right=�$��Center=�$
��10,0q�.+��� $��Images\novawerks1.png��$��30��$��30��$��0,0,10,0q��� -    ��Name$ UserEmailTextBlock��$��user@example.com�����#E0E0E0$��Center=�$��0,0,10,0q��� -    ��Name$ LoginButton��$��Login�����#FFA500
�������$��80��$��30��$��0,0,10,0q��� -   $ LogoutButton��$��Logout�����#FF4444
�������$��80��$��30��$y�	Collapsed=��� -	    ��Name$ LeftMenu�����#2F2F2F$	��230��$��1��$��0��$��Stretch=�._�]� $
��True��.+��� $	��Top=�.+��� -
   $ MainPageMenuItem��$
��Home��$��10q�	 �� Padding$	 10q����#CCCCCC
 � Cursor$

 Hand��$��16(�$��Medium"�   xGFF#��[  �� -   $ ForumPageMenuItem��$��Forums��$��10q�$	 10q����#CCCCCC$

 Hand��$��16(�$��Medium"�#��[  �� -   $ NWASPageMenuItem��$��NW Addon Store��$��10q�$	 10q����#CCCCCC$

 Hand��$��16(�$��Medium"�#��[  �� -   $ SettingsButton��$��Settings��$��40�����#FFA500
�������$��Bottom=�$��10q�#��[  $
��Bold"��� -   $ HelpSidebar�����#1F1F1F$	��300��$��1��$��2��$��Stretch=�$y�	Collapsed=�._�� .+��� -   $��X��$��Right=�$	��Top=�$��30��$��30��$��5q�$��16(�$
��Bold"����#FF4444���#FFFFFF)   #Microsoft.Web.WebView2.Wpf.WebView2  -     Name$ HelpWebView��   Source$2 ,https://werks.nova.xxavvgroup.com/helpcenter?�$��0,35,0,0q�� $��1��$��1��$��20q�.+��� $
��Auto=�$
��Auto=�.���� .+��� $��
Welcome...��$��24(�$
��Bold"�$��0,0,0,20q����#E0E0E0#��[  �� $D��>Sup? Find everything you need and want, right here in the NDE!��$��16(�$��0,0,0,20q����#B0B0B0#��[  �� ���#2F2F2F �� Padding$ 15q�$��0,0,0,20q�._��� .+��� $��Latest Update:��$��24(�$
��Bold"����#E0E0E0#��[  �� $��	v0.8.0-EA��$��20(�$��SemiBold"����#B0B0B0#��[  �� ${��uThe 4th primary EarlyAccess release of the Novawerks Desktop Experience!
Check out the full changelog on our website.��$��14(����#B0B0B0#��[  �� �� -   $+��%https://werks.nova.xxavvgroup.com/nde?�.�.��� $��Read about this update�����#FFA500#��[  �� ���#2F2F2F$ 15q�$��0,0,0,20q�._��� .+��� $��Latest Blog Post��$��24(�$
��Bold"����#E0E0E0#��[  �� $��Join The WerksClub!��$��20(�$��SemiBold"����#B0B0B0#��[  �� $^��XThe WerksClub is Novawerks' official newsletter. Here's why we think you should join us.��$��14(����#B0B0B0#��[  �� �� -   $1��+https://werks.nova.xxavvgroup.com/join-club?�.�.��� $��	Read more�����#FFA500#��[  �� ���#2F2F2F$ 15q�$��0,0,0,20q�._��� .+��� $��Addon Launcher��$��22(�$
��Bold"����#E0E0E0#��[  $��0,0,0,10q��� ���#FFA500$ 50q�$��Center=�._��� $��Main App��$��18(�
�������$��Center=� � -   $��ContentFrame��$��Stretch=�$��Stretch=�  � NavigationUIVisibility$ Hidden=��� ���#1F1F1F$��2��$��0��$��3��$��30��$��Bottom=�._��� $A��;Novawerks Desktop Experience © 2024 Novawerks & xxavv6AMES��$��Center=�$��Center=����#CCCCCC#��[  