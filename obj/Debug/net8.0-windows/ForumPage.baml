   M S B A M L   `   `   `  ����e  aMicrosoft.Web.WebView2.Wpf, Version=1.0.2739.15, Culture=neutral, PublicKeyToken=2a8ab48044d2601ekLclr-namespace:Microsoft.Web.WebView2.Wpf;assembly=Microsoft.Web.WebView2.WpfMicrosoft.Web.WebView2.Wpf  5       NovawerksApp   NovawerksApp.ForumPage   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      \wv2Lclr-namespace:Microsoft.Web.WebView2.Wpf;assembly=Microsoft.Web.WebView2.Wpf     5        N� 
Background  �#000000 N� 
Foreground �#FFFFFF.��5      �  � ColumnDefinitions 5	   
   �� 5
      $
��Auto �6   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $��0��6   $��1��6   ���#1F1F1F$��40��6C   ._�5      ��  �� Orientation$ 
Horizontal=�6   $��Center=�62   $��10q�6M   .+�5      �� -   5        $	��←��5      $��20(�6%   ���#2F2F2F���#FFFFFF
������ 6w   �� 5      $��Novawerks Forums��6   $��10,0,0,0q�64   $��18(�6F   $��Center=�6T   ���#FFFFFF   xGFF#��[  6�   5      5      �� 5   
   -   5         ��Name$ LeftMenu��5      $��1��6#   ���#2F2F2F$	��250��6E   $
��Left=�6Q   $��Stretch=�6l   $y�	Collapsed=�6�   ._�5      �� .+�5      �� -   5         ��Name$ MainPageMenuItem��5      $��	Main Page��66   $��10q�6G    �� Padding$ 5q�6S   ���#CCCCCC � Cursor$
 Hand��6t   $��16(�6�   $��SemiBold"�6�   #��[  6�   �� 5      -   5        $ ForumPageMenuItem��5      $��
Forum Page��67   $��10q�6I   $ 5q�6U   ���#FFA500$
 Hand��6v   $��16(�6�   $��SemiBold"�6�   #��[  6�   �� 5      -   5        $ NWASPageMenuItem��5      $��	NWAS Page��66   $��10q�6G   $ 5q�6S   ���#CCCCCC$
 Hand��6t   $��16(�6�   $��SemiBold"�6�   #��[  6�   5       5!      �� 5$   
   -   5        $ 	HoverArea��5$      
������ $��15��6=   $
��Left=�6H   $��Stretch=�6c   � 5'   
   $��1��6   $��1��6   $��0q�6,   .+�5(      )   #Microsoft.Web.WebView2.Wpf.WebView2  -   5        $��ForumWebView��5(      	   Source$(	 "https://forums.nova.xxavvgroup.com?�5)      $��Stretch=�5*      $��Stretch=�5+      5,      5-      5.      