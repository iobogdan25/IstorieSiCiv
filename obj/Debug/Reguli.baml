   M S B A M L   `   `   `  ����  Istorie    Istorie.Reguli   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     6F   -   5          � Title$  Reguli��5   "   $	��500��61   $	��900��6>   .��5      �  � ColumnDefinitions 5   
   �� 5      �� 5	      .+�5   
   �� -   5         ��Name$ wrong_image_1��5   O   $��0��6   $��Resources/lock.png��6     K� ZIndex$	 100��6<   $y�Hidden=�6f   � 5   
   -   5         �Name$ grid_player_1��5      $��0��6   .+�5      �� $��1��6   .+�5      �� $
��Bold"�6   $��20(�6*   
���  ��$��REGULAMENT!��6I   �� 5      2  ,System.Windows.Markup.XmlAttributeProperties  XmlSpace preserve6E   $
��Wrap=�6   $��13(�6E   �� 6T   $��{      Fiecare duel are un set de 10 intrebari, iar la ficare intrebare aveti la dispozitie 30 de secunde pentru a raspunde.��6X   6�   �� 5       preserve6E   $
��Wrap=�6   $��13(�6E   �� 6T   $���      Intrebarile sunt cu raspuns multiplu. Pentru fiecare raspuns corect, primesti 10 puncte, la sfarsitul duelului, jucatorul cu cele mai multe puncte este declarat invingator��6X   6  �� 5       preserve6E   $
��Wrap=�6   $��13(�6E   �� 6T   $6�0      Tastele corespunzatoare raspunsurile sunt:��6X   6�   �� 5       preserve6E   $
��Wrap=�6   $��13(�6E   �� 6T   $ �      Raspunsul A: tasta A��6X   6}   �� 5       preserve6E   $
��Wrap=�6   $��13(�6E   �� 6T   $ �      Raspunsul B: tasta S��6X   6}   �� 5       preserve6E   $
��Wrap=�6   $��13(�6E   �� 6T   $ �      Raspunsul C: tasta D��6X   6}   �� 5       preserve6E   $
��Wrap=�6   $��13(�6E   �� 6T   $ �      Raspunsul D: tasta F��6X   6}   �� 5       �� Orientation$ 
Horizontal=�6   .+�5      �� $+��%Resources/Taste/47-computer_key_A.png��6   $��50��6K   $��50��6W   $��	30,5,20,5q�6b   �� 5      $+��%Resources/Taste/52-computer_key_S.png��6   $��50��6K   $��50��6W   $��	30,5,20,5q�6b   �� 5      $+��%Resources/Taste/37-computer_key_D.png��6   $��50��6K   $��50��6W   $��	30,5,20,5q�6b   �� 5      $+��%Resources/Taste/50-computer_key_F.png��6   $��50��6K   $��50��6W   $��	30,5,20,5q�6b   5      �� 5      $ 
Horizontal=�6   .+�5      � -   5        $ grid_raspuns_1��5   2   $��50��6   $��50��6'   $��
30,0,20,20q�6J   ���	#FFD8D8D8.+�5      �� $��Center=�6$   $��Center=�6?   $��30(�6\   �� 6l   $�A��6p   6|   5      � 5       -   5        $ grid_raspuns_2��5    2   $��50��6   $��50��6'   $��
30,0,20,20q�6J   ���	#FFD8D8D8.+�5!      �� $��Center=�6$   $��Center=�6?   $��30(�6\   �� 6k   $�B��6o   6{   5"      � 5#      -   5        $ grid_raspuns_3��5#   2   $��50��6   $��50��6'   $��
30,0,20,20q�6J   ���	#FFD8D8D8.+�5$      �� $��Center=�6$   $��Center=�6?   $��30(�6\   �� 6k   $�C��6o   6{   5%      � 5&      -   5        $ grid_raspuns_4��5&   2   $��50��6   $��50��6'   $��
30,0,20,20q�6J   ���	#FFD8D8D8.+�5'      �� $��Center=�6$   $��Center=�6?   $��30(�6\   �� 6k   $�D��6o   6{   5(      5*      �� 5+      $ 
Horizontal=�6   .+�5,      ��  preserve6r   $
��Wrap=�6    $��13(�6I   $��Center=�6W   $
��Bold"�6r   �� 6�   $7�1      Pentru a confirma raspunsul apasati tasta X��6�   6�   �� 5-      $+��%Resources/Taste/30-computer_key_X.png��6   $��50��6K   $��50��6W   $��10,0,0,0q�6b   5.      � 5/      -   5        $ grid_trimitere��5/   u   $	��170��6   $��35��6#   ���	#FFD8D8D8$��Right=�6F   $��	0,10,40,0q�6b   .+�50      �� $��Center=�6    $��Center=�6;   $��16(�6X   $
��Bold"�6f   �� 6y   $�Incepe jocul (apasa X)��6}   6�   51      53      54      � 56   
   -	   5        $ grid_player_2��56   +   $��1��6    J� Opacity$ 1Q�6   .+�58      �� $��1��6   .+�59      �� $
��Bold"�6   $��20(�6*   
���  ��$��REGULAMENT!��6I   �� 5:       preserve6E   $
��Wrap=�6   $��13(�6E   �� 6T   $��{      Fiecare duel are un set de 10 intrebari, iar la ficare intrebare aveti la dispozitie 30 de secunde pentru a raspunde.��6X   6�   �� 5;       preserve6E   $
��Wrap=�6   $��13(�6E   �� 6T   $���      Intrebarile sunt cu raspuns multiplu. Pentru fiecare raspuns corect, primesti 10 puncte, la sfarsitul duelului, jucatorul cu cele mai multe puncte este declarat invingator��6X   6  �� 5<       preserve6E   $
��Wrap=�6   $��13(�6E   �� 6T   $6�0      Tastele corespunzatoare raspunsurile sunt:��6X   6�   �� 5=       preserve6E   $
��Wrap=�6   $��13(�6E   �� 6T   $ �      Raspunsul A: tasta U��6X   6}   �� 5>       preserve6E   $
��Wrap=�6   $��13(�6E   �� 6T   $ �      Raspunsul B: tasta I��6X   6}   �� 5?       preserve6E   $
��Wrap=�6   $��13(�6E   �� 6T   $ �      Raspunsul C: tasta O��6X   6}   �� 5@       preserve6E   $
��Wrap=�6   $��13(�6E   �� 6T   $ �      Raspunsul D: tasta P��6X   6}   �� 5A      $ 
Horizontal=�6   .+�5B      �� $+��%Resources/Taste/94-computer_key_U.png��6   $��50��6K   $��50��6W   $��	30,5,20,5q�6b   �� 5C      $*��$Resources/Taste/9-computer_key_I.png��6   $��50��6J   $��50��6V   $��	30,5,20,5q�6a   �� 5D      $+��%Resources/Taste/34-computer_key_O.png��6   $��50��6K   $��50��6W   $��	30,5,20,5q�6b   �� 5E      $+��%Resources/Taste/25-computer_key_P.png��6   $��50��6K   $��50��6W   $��	30,5,20,5q�6b   5F      �� 5G      $ 
Horizontal=�6   .+�5H      � $��50��6   $��50��6'   $��
30,0,20,20q�63   ���	#FFD8D8D8.+�5I      �� $��Center=�6$   $��Center=�6?   $��30(�6\   �� 6l   $�A��6p   6|   5J      � 5K      $��50��6   $��50��6'   $��
30,0,20,20q�63   ���	#FFD8D8D8.+�5L      �� $��Center=�6$   $��Center=�6?   $��30(�6\   �� 6k   $�B��6o   6{   5M      � 5N      $��50��6   $��50��6'   $��
30,0,20,20q�63   ���	#FFD8D8D8.+�5O      �� $��Center=�6$   $��Center=�6?   $��30(�6\   �� 6k   $�C��6o   6{   5P      � 5Q      $��50��6   $��50��6'   $��
30,0,20,20q�63   ���	#FFD8D8D8.+�5R      �� $��Center=�6$   $��Center=�6?   $��30(�6\   �� 6k   $�D��6o   6{   5S      5U      �� 5V      $ 
Horizontal=�6   .+�5W      ��  preserve6r   $
��Wrap=�6    $��13(�6I   $��Center=�6W   $
��Bold"�6r   �� 6�   $7�1      Pentru a confirma raspunsul apasati tasta K��6�   6�   �� 5X      $,��&Resources/Taste/100-computer_key_K.png��6   $��50��6L   $��50��6X   $��10,0,0,0q�6c   5Y      � 5Z      $	��170��6   $��35��6#   ���	#FFD8D8D8$��Right=�6F   $��	0,10,40,0q�6b   .+�5[      �� $��Center=�6    $��Center=�6;   $��16(�6X   $
��Bold"�6f   �� 6y   $�Incepe jocul (apasa K)��6}   6�   5\      5^      5_      5`      5a      