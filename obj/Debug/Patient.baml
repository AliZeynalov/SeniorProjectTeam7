   M S B A M L   `   `   `  ����F  BTeam7Senior, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:Team7SeniorTeam7Senior  5   	   N JLightBuzz.Vitruvius, Version=2.0.0.0, Culture=neutral, PublicKeyToken=nullhGclr-namespace:LightBuzz.Vitruvius.Controls;assembly=LightBuzz.VitruviusLightBuzz.Vitruvius.Controls 5   	       Team7Senior.Patient   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:Team7Senior     5   	   \controlsGclr-namespace:LightBuzz.Vitruvius.Controls;assembly=LightBuzz.Vitruvius     5   	     � Title$  Patient��5	   	   $	��670��6   $	��670��6&    � WindowStartupLocation$ Manual=�62    � 
ResizeMode$ CanMinimize=�6Q   ��5
      �� 5   
    �� ImageSource$ img/back.jpg��6   .��5      � .+�5   
   �� $
��Left=�6   $	��490��6,   $��	15,77,0,0q�69   $	��Top=�6L   $	��296��6d   .+�5      �� ���	#FF126C8C$��3q�6-   $
��Left=�6A   $	��490��6\   $	��Top=�6i   $	��296��6�    �� Left$ -1��6�   �� 5      -   5         ��Name$ label��5      $
��ID: ��6#   $
��Left=�62   $	��Top=�6M   $ 10��6e   
 �� Top$ 12��6v   �� 5      -   5         ��Name$
 idtb��5      $
��Left=�6$   $��23��6?    �� TextWrapping$
 Wrap=�6K   $	��Top=�6_   $��37��6w   {�.  $ 53��6�   $ 15��6�   �� 5      -   5        $ label1��5      $��Name: ��6$   $
��Left=�65   $	��Top=�6P   $	 126��6h   $ 12��6z   �� 5      -   5        $ nametb��5      $
��Left=�6&   $��23��6A   $
 Wrap=�6M   $	��Top=�6a   $��94��6y   {�.  $	 179��6�   $ 15��6�   �� 5      -   5        $ label2��5      $��Subject:��6$   $
��Left=�67   $	��Top=�6R   	 J� RenderTransformOrigin$	 0.5,0.5&�6j   $ 14��6�   $	 183��6�   z�5      V� 5      .~�5      �� �� 5      �� 5      
 �� Angle$
 0.229Q�6*   T� 5       T� X$ 0.287Q�6-    T� Y$ -0.394Q�67   5      5      �� 5      -   5        $ label3��5      $��Message:��6$   $
��Left=�67   $	��Top=�6R   $	 0.5,0.5&�6j   $ 12��6�   $	 240��6�   z�5      V� 5       .~�5!      �� �� 5"      �� 5#      $
 0.229Q�6*   T� 5$      $ 0.162Q�6-   $ -0.378Q�67   5%      5'      �� 5(      -   5        $ 	subjecttb��5(      $
��Left=�6)   $��23��6D   $
 Wrap=�6P   $	��Top=�6e   $	��120��6}   $	 0.5,0.5&�6�   $	 111��6�   $	 190��6�   .��6�   z�5)      V� 5*      .~�5+      �� �� 5,      �� 5-      $
 0.229Q�6*   T� 5.      $ 0.269Q�6-   $ 0.046Q�67   5/      .��50   +   51      �� 52      -   5        $ msgtb��52      $
��Left=�6%   $��86��6@   $
 Wrap=�6L   $	��Top=�6a   $	��176��6y   $	 0.5,0.5&�6�   $	 109��6�   $	 242��6�   .��6�   z�53      V� 54      .~�55      �� �� 56      �� 57      $
 0.229Q�6*   T� 58      $ 0.024Q�6-   $ 0.151Q�67   59      .��5:   +   5;      �� 5<      -	   5        $ label4��5<      $��	Password:��6$   $
��Left=�68   $	��Top=�6S   $	 0.5,0.5&�6k   $ 9��6�   $	 358��6�   z�5=      V� 5>      .~�5?      �� �� 5@      �� 5A      $
 0.229Q�6*   T� 5B      $ -0.286Q�6-   $ -0.373Q�68   5C      5E      G� 5F      -
   5         G�Name$ passtb��5F      $
��Left=�6*   $	��Top=�6E   $	��178��6]   $	 0.5,0.5&�6i   $	 108��6�   $	 361��6�    G� PasswordChar$ *��6�   z�5G      V� 5H      .~�5I      �� �� 5J      �� 5K      $
 0.229Q�6*   T� 5L      $ -0.302Q�6-   $ 0.155Q�68   5M      5O      �� 5P      -   5        $ label5��5P      $��E-Mail: ��6$   $
��Left=�67   $	��Top=�6R   $ 10��6j   $ 56��6{   �� 5Q      -   5        $ mailtb��5Q      $
��Left=�6&   $��23��6A   $
 Wrap=�6M   $	��Top=�6a   $	��196��6y   {�.  $ 77��6�   $ 56��6�   �� 5R      -   5         ��Name$ sendbtn��5R      $��Send E-Mail��6&   $
��Left=�6<   $	��Top=�6W   $	��177��6o   $ 53��6�   $	 448��6�   �� 5S      -   5        $ 	enablebtn��5S      $��Enable/Disable��6(   $
��Left=�6A   $	��Top=�6\   $	��116��6t   $ 10��6�   $ 87��6�   �� 5T      -   5        $ 	updatebtn��5T      $��Update E-Mail��6(   $
��Left=�6@   $	��Top=�6[   $	��130��6s   $	 143��6�   $ 87��6�   �� 5U      -   5        $ label6��5U      $)��#Send E-Mail to Your Physiotherapist��6$   $ 3��6R   $	 142��6b   $��Arial Black)�6t   $��14(�6�   ���	#FF126C8C6�   5V      �� 5W   
   -   5        $ button��5W      $��Logout��6!   $
��Left=�62   $	��Top=�6M   $��75��6e   $��	563,5,0,0q�6�   $��33��6�   �� 5X   
   -   5         ��Name$ image��5X      $��img/logo.png��6   $
��Left=�66   $	��121��6Q   $	��Top=�6^   $	��290��6v   $��
330,77,0,0q�6�   �� 5Y   
   -   5         ��Name$ 
motionList��5Y      $
��Left=�6'   $	��180��6B   $	��Top=�6O   $	��273��6g   $��343,244,0,0q�6s   
������  �� View 5Z      �� 5[      .P�5\      �� $��
MotionName��6%    �� DisplayMemberBinding 69   �� *
MotionName+�� 5]      $��Description��6%    6:   �� *Description+�� 5^      $��Category��6%    67   �� *
Category+�� 5_      $��
Repetition��6%    69   �� *
Repetition+5`      5b      �� 5e   
   -   5        $��Start Motion��5e      $
��Left=�6(   $��55��6C   $��432,465,0,0q�6O   $	��Top=�6d   $��91��6|   6�   �� 5f   
   ���	#FF126C8C$��3q�6)   $
��Left=�6=   $	��191��6X   $��343,235,0,0q�6e   $	��Top=�6z   $	��276��6�   5l      5m      