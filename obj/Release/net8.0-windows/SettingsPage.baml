   M S B A M L   `   `   `  ����   NovawerksApp    NovawerksApp.SettingsPage   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008       N� Title$  Settings�� N� 
Background �#121212.���  � ColumnDefinitions �� $	��240 ��� $��* �.+��� -    ��Name$ LeftMenu�����#1E1E1E$��0��$��Stretch=� �� CornerRadius$ 10��$��10q�._��� .+��� -    ��Name$ MainPageMenuItem��$��	Main Page��$��20,15q� �� Padding$ 10q����#FFFFFF � Cursor$
 Hand��$��18(�$
��Bold"�   xGFF#��[  �� -   $ ForumPageMenuItem��$��
Forum Page��$��20,15q�$ 10q����#FFFFFF$
 Hand��$��18(�$
��Bold"�#��[  �� -   $ NWASPageMenuItem��$��	NWAS Page��$��20,15q�$ 10q����#FFFFFF$
 Hand��$��18(�$
��Bold"�#��[  �� $��1��$
��Auto=�$��20q� �� PanningMode$ VerticalFirst=�.���� .+��� ���#1A1A1A$ 10��	 �� Padding$	 20q�$��0,0,0,20q�._��� .+��� $��Account Settings��$��24(����#FFA500$��0,0,0,15q�$
��Bold"��� -   $ UserName��$��20(�$��10q����#FFFFFF�� -   $ 	UserEmail��$��16(�$��10q����#B0B0B0�� $��	10,20,0,0q��� -   $'��!https://werks.nova.xxavvgroup.com?�.�.��� $��Manage Your Account�����#FFA500�� $��10,0,0,0q��� -   .�.��� $��Log Out�����#FFA500�� ���#1A1A1A$ 10��$	 20q�$��0,0,0,20q�._��� .+��� $��App Settings��$��24(����#FFA500$��0,0,0,15q�$
��Bold"��� $��Theme�����#FFA500$��Medium"��� -	   
 ��Name$
 ThemeComboBox��$��0,5,0,20q����#333���#FFF$��10q����#444$��1q�.@��� $��Light���� $
��Dark���� -
   $��Apply Settings�����#FFA500���#000$	��180��$
��Left=�$��40���� ���#1A1A1A$ 10��$	 20q�$��0,0,0,20q�._��� .+��� $��Updates��$��24(����#FFA500$��0,0,0,15q�$
��Bold"��� $��Current Version: 0.8.0-EA�����#FFFFFF$��0,5,0,20q��� -   $��Check for Updates�����#FFA500���#000$	��180��$
��Left=�$��40���� -   $!��Download and Install Update�����#FFA500���#000$	��220��$
��Left=�$��40��$��0,15,0,0q��� -   $��View Changelog�����#FFA500$
 Hand��$��	Underline{�$��0,15,0,0q�