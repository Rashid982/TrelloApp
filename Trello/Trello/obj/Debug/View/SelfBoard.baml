   M S B A M L   `   `   `  ����A  =Trello, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:Trello.ViewModelTrello.ViewModel  5   8   )clr-namespace:Trello.ViewTrello.View  5   D   =#clr-namespace:Trello.ValueConverterTrello.ValueConverter  5          Trello.View.SelfBoard   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    6(   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      -VMclr-namespace:Trello.ViewModel     68   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      a ]Syncfusion.SfGrid.WPF, Version=19.1460.0.58, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89a ]Syncfusion.Shared.Wpf, Version=19.1460.0.58, Culture=neutral, PublicKeyToken=3d67ed1f87d44c894
syncfusion!http://schemas.syncfusion.com/wpf   6H   <d2http://schemas.microsoft.com/expression/blend/2008   5      'localclr-namespace:Trello.View   6D   b ^MaterialDesignThemes.Wpf, Version=4.0.0.2422, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3b+http://schemas.microsoft.com/xaml/behaviors  6J   3	Converter#clr-namespace:Trello.ValueConverter  5        N� 
Background
  ����� N� Title$ 	SelfBoard��5   N    � 	Resources 5      /  )Trello.ValueConverter.ForegroundConverter   ForegroundConverter��%   &	          5	      6$   5
      .��5      � -   5         �Name$ MainGrid��5       � RowDefinitions 5   
   �� 5      �� 5      $
��5.5* �6   .+�5   
   ��  �� Orientation$ 
Horizontal=�6   $��2,0,0,15q�6.   .+�5      �� -   5        $��ListTitleTxtbox��5   Q   $��10,0,0,0q�5   V   $	��150��6h   $��15(�5      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Enter list title...��6$   $y�	Collapsed=�6Y    % !MaterialDesignFloatingHintTextBox#��[ 5      ��5      �� *	ListTitle+ �� UpdateSourceTrigger$ PropertyChanged=�5   j   �� 5      -   5         ��Name$ CloseBtn��5      
������ $��20,11,-10,0q�6A   
���   �$��X��5      $��25(�6!   $��Arial)�6/   $y�	Collapsed=�6B   $��31��6Y   6e   �� 5      -   5        $��
AddListBtn��5   K      MaterialDesignOutlinedButton#��[ 6   ���#5e6c84$	��200��5   (   $
��Left=�64   $��	20,10,0,0q�6Q   ��5      �� *
AddListCmd+.��5   8   
+ Add List6D   5      �� 5   
   $��1��6   $
��Auto=�6$   .��5      �� -   5        	 ��Name$	 MyItems��5   :   ��6   �� *Lists+��5       �� 5!      .R�5"      � 5#      ��5&      �� 5'      .R�5(      �  5)      �� 5*   "   $
��auto �60   .+�5-      � $��0��6#   .+�5.   "   �� -   5        
 �� CornerRadius$
 3��5.   )   $	��272��6:   $��78��6F   ���#ebecf0$��8 10 4 0q�6j   ._�50   &   �  51   *   �� 52   .   $
��Auto �6<   �� 53   .   $��* �6<   �� 54   .   $
��Auto �6<   .+�57   *   � $��0��6/   .+�58   .   �� -   5        $��0q�58   6   $	��140��6J   $
��Left=�6V   ���#172b4d$��16(�59   Y   $��DemiBold"�5:   -    �� TextWrapping$
 Wrap=�6C   $
��8 10q�6W   ��59   -   �� *Title+5:   W   �� 5<   .   $ SuccessBtn1��65   $��	160 0 0 3q�6J   $��18��6]   $��18��6h   $y�	Collapsed=�6t   $��0q�5=   5    � ToolTip$ Change list name��5@   R   ��5=   J   ��  �� RelativeSource ��  �� AncestorType" �� �� AncestorLevel$ 1�� �� Path$% DataContext.SaveListNameCommand���5@   5   �� ��5A   2   �� 5B   6    �� ImageSource$ /Images/ChangeIcon.png��6A   6h   5D   /   �� 5F   .   $��DeleteListBtn��5G   I   $��	220 0 0 3q�5F   5   $��20��6H   $��20��6S   $y�Hidden=�6_   $��0q�5G   5   $ Delete this list��5K   R   ��5H   5   ��  �� " ��$ 1��$  DataContext.DelListCommand���5K   5   �� ��5L   2   �� 5M   6   $ /Images/DeleteIconpng.png��6A   6k   5O   /   5P   +   � 5R   *   $��1��6/   .+�5S   .   �� $��Disabled=�6;   $
��Auto=�6d   .��5T   2   ��  ��Name$
 Root��6|   ��6:   �� *Cards+$ PropertyChanged=� �� SelectedItem 5U   1   ��  �� " ��$ DataContext.SelectedCard���5W   6   �� 5X   :   .R�5Y   >   �� $ Vertical=�6I   $	��Top=�6`   5Z   ;   *  $Microsoft.Xaml.Behaviors.Interaction   Triggers 5]   6   +  %Microsoft.Xaml.Behaviors.EventTrigger  5^   :      	EventName$ MouseDoubleClick��6I   *  $Microsoft.Xaml.Behaviors.TriggerBase   Actions. 5_   >   2  ,Microsoft.Xaml.Behaviors.InvokeCommandAction     Command 6T   ��  �� " ��$ 2��$ DataContext.MoveCardCmd�5a   ;   ��5d   6   �� 5e   :   .R�5f   >   �� -   5        $) #Tap double click to move other list��5f   E   $
 3��6s   $��40��6�   
�������$��0 0 0 0q�5g   P    �� Padding$ 8 0 8 0q�6a    J� Effect 5i   B   3  -System.Windows.Media.Effects.DropShadowEffect  5j   F      
BlurRadius$	 1.5Q�6W      Color$ 	LightGray��6h      	Direction$	 -90Q�6z      RenderingBias$ Quality=�6�      ShadowDepth$ 1Q�6�   ._�5l   B   �  5m   F   �� 5n   J   $
��auto �6X   .+�5q   F   � $��0��6K   .+�5r   J   �� -	   5        $��0q�5r   R   $
 Wrap=�5s   I   $
��Left=�6]   ���#172b4d$��14(�5t   ^   $��0 0 0 15q�6l   ��5r   f   �� *Title+5t   l   �� 5u   J   $ 
SuccessBtn��6l   $ Change card name��6Q   $��	160 0 0 3q�5v   I   $��18��6\   $��18��6g   $y�	Collapsed=�6s   $��0q�5w   I   ��6^   ��  �� " ��$ 2��$% DataContext.SaveCardNameCommand���5z   I   �� ��5{   N   �� 5|   R   $ /Images/ChangeIcon.png��6]   6�   5~   K   �� 5   J   $��DeleteCardBtn��5�   x   $��	220 0 0 3q�5   Q   $��20��6d   $��20��6o   $y�Hidden=�6{   $��0q�5�   I   $ Delete this card��6]   ��5�   I   ��  �� " ��$ 2��$  DataContext.DelCardCommand���5�   I   �� ��5�   N   �� 5�   R   $ /Images/DeleteIconpng.png��6]   6�   5�   K   �� 5�   J   $��10(�5�   c   $��0 25 0 0q�6q   ��5�   T   �� *
DeadLine+ �� 	Converter# [  ��5�   I   �� *
DeadLine+5�   K   5�   G   5�   C   5�   ?   5�   ;   5�   3   5�   /   5�   +   � 5�   *   $��2��6/   .+�5�   .   �� .+�5�   2   �� $��NewCardBorder��5�   l   $
 3��5�   9   $��40��6J   
�������$��8 7 8 7q�5�   D   $y�	Collapsed=�6U    5�   6     5�   :   $	 1.5Q�6K   $ 	LightGray��6\   $	 -90Q�6n   $ Quality=�6~   $ 1Q�6�   ._�5�   6   �� $ 
Horizontal=�6A   .+�5�   :   �� $��CardTitleTxtBox��5�   {   $
 Wrap=�5�   B   $��0,0,0,4q�5�   j   $��15(�5�   5   $ Enter card title...��6C   $y�	Collapsed=�6x   #��[ 5�   5   $	��180��6p   ��5�   V   ��  �� " ��$ DataContext.CardTitle�5�   ~   (  "System.Windows.Controls.DatePicker  5�   :   $��DatetimePckr��6E    ( $MaterialDesignFloatingHintDatePicker#��[ 5�   5   $y�	Collapsed=�6t   $ 
Edit dates��5�   5   $��0,0,0,-4q�6a       SelectedDate  5�   Y   ��  �� " ��$ 1��$ DataContext.SelectedDate�5�   u   5�   7   5�   3   �� 5�   2   -
   5        #��[ 5�   9   ���#5e6c84$��3 3 3 3q�5�   s   ��5�   1   ��  �� " ��$# DataContext.AddAnotherCardCmd���5�   V   �� .��6�   
+ Add card6�   5�   /   5�   +   5�   '   5�   #   5�      5�      5�      5�      5�      5�      5�      