   M S B A M L   `   `   `  ����A  =Trello, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:Trello.ViewTrello.View  5   8   %    Trello.View.InvitationSelfBoard   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    61   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      +localclr-namespace:Trello.View     68   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5        N� 
Background
  ����� N� Title$ InvitationSelfBoard��5   Y   .��5      � .+�5   
   �� $��1��6   $
��Auto=�6$   .��5      �� -   5         ��Name$ MyItems��5   :   ��6   �� *Lists+��5	      �� 5
      .R�5      � 5      ��5      �� 5      .R�5      �  � RowDefinitions 5      �� 5   "   $
��auto �60   .+�5      � $��0��6#   .+�5   "   ��  �� CornerRadius$ 3��6)   $	��272��6:   $��78��6F   ���#ebecf0$��8 10 4 0q�6j   ._�5   &   �  5   *   �� 5   .   $
��Auto �6<   �� 5   .   $��* �6<   �� 5   .   $��12 �6<   .+�5   *   � $��0��6/   .+�5    .   �� $	��140��68   $
��Left=�6D   ���#172b4d$��16(�5!   b   $��DemiBold"�5"   1   $
��Wrap=�6G    �� Padding$
 8 10q�6[   ��5!   6   �� *Title+5"   [   5#   +   � 5%   *   $��1��6/   .+�5&   .   �� $��Disabled=�6;   $
��Auto=�6d   .��5'   2   �� ��6?   �� *Cards+��5(   6   �� 5)   :   .R�5*   >   ��  �� Orientation$ Vertical=�6I   $	��Top=�6`   5+   ;   ��5.   6   �� 5/   :   .R�50   >   �� $ 3��6E   $��40��6V   
�������$��7 4 7 4q�51   X    �� Padding$ 8 6 8 2q�6i    J� Effect 52   B   3  -System.Windows.Media.Effects.DropShadowEffect  53   F   	   
BlurRadius$		 1.5Q�6W   
   Color$
 	LightGray��6h      	Direction$	 -90Q�6z      RenderingBias$ Quality=�6�      ShadowDepth$ 1Q�6�   ._�55   B   �  56   F   �� 57   J   $
��auto �6X   .+�5:   F   � $��0��6K   .+�5;   J   �� $
��Wrap=�5<   I   $
��Left=�6]   ���#172b4d$��14(�5=   ^   $��0 0 0 15q�6l   ��5;   T   �� *Title+5=   l   5>   G   5?   C   5@   ?   5A   ;   5C   3   5D   /   5E   +   5F   '   5G   #   5H      5I      5J      5L      5M      5N      5O      