   M S B A M L   `   `   `  ����F  BTeam7Senior, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:Team7SeniorTeam7Senior  5      N JLightBuzz.Vitruvius, Version=2.0.0.0, Culture=neutral, PublicKeyToken=nullhGclr-namespace:LightBuzz.Vitruvius.Controls;assembly=LightBuzz.VitruviusLightBuzz.Vitruvius.Controls 5      "    Team7Senior.PoseMatchingPage   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      +localclr-namespace:Team7Senior     5      \controlsGclr-namespace:LightBuzz.Vitruvius.Controls;assembly=LightBuzz.Vitruvius     5      -   5          � Title$  PoseMatchingPage��5
       � WindowState$ 	Minimized=�5        � 
ResizeMode$ CanMinimize=�68   ��5      �� 5   
    �� ImageSource$ img/back.jpg��6   .��5      � .+�5   
   �� $
��Left=�6   $	��Top=�6,   .+�5      �� -   5        $
��Back��5      $
��Bold"�5      $��28��6#    �� Left$ 27��6/   
 �� Top$ 15��6@   $��77��6P   �� 5      -   5         ��Name$ image��5      $��img/logo.png��5      $��Center=�5      $��93��5      $	��Top=�5      $	��227��6(   $	 458��64   $ 7��6F   5      � 5    
   $��1��6    � ColumnDefinitions 5!      �� 5"      $
��0.5* �6#   �� 5#      $
��0.5* �6#   .+�5%      /  )LightBuzz.Vitruvius.Controls.KinectViewer  -   5          Name$ viewer1��5%   $   $��0��65     5&      -   5        $ viewer2��5&   $   $��1��65   5(      5+      5,      