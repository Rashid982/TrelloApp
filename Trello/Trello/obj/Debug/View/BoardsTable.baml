   M S B A M L   `   `   `  ����A  =Trello, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:Trello.ViewTrello.View  5          Trello.View.BoardsTable   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    6+   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      +localclr-namespace:Trello.View     5      c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5      X TXceed.Wpf.Toolkit, Version=4.0.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44wpfx)http://schemas.xceed.com/wpf/xaml/toolkit  5        N� 
Background
  ����� N� Title$ BoardsTable��5   D   .��5
      � .+�5   
   �� $
��Auto=�6   .��5      �� $��	15,10,0,0q�6   .+�5      ��  �� Orientation$ 
Horizontal=�6   .+�5      �� $��14(�6   .��6&   Your Workspace boards6=   �� 5      
����  �$��0q�6N   $��	100,0,0,0q�5      ��5   /   �� *	CreateCmd+.��5   ,   Create new board6>   �� 5      $��30,0,0,0q�6   
�������
����  �
������ $y�	Collapsed=�5   ;   ��6   �� *	InviteCmd+.��6R   Invite6Z   5      �� 5      -   5        $��1��5      $��0,10,0,0q�6#   ��65   �� *Boards+ �� SelectedItem 5      �� *SelectedBoard+��5      �� 5      .R�5      � 5      ��5      �� 5      .R�5      � .+�5       �� $	��180��6(   $��95��64   ��5!   "   �� 5"   &    �� Color 66   �� *Color+6P   5$      �� 5%   "   -   5        $
��Left=�5%   *   $	��Top=�6E   $��16(�6]   
�������$
��Bold"�5&   7    �� TextWrapping$
 Wrap=�6I   $��2,0,0,0q�6]   $��0q�5'   ;   $��30��6O   $	��155��6[   ��6$   �� *Title+5(   $   �� 5)   "    ��Name$ 
SuccessBtn��6E   -   5         � ToolTip$ Change board name��5)   )   $��	165 0 0 3q�6Y   $��18��5*   )   $��18��64   $��0q�6@   $y�	Collapsed=�6T   ��5+   )   ��  �� RelativeSource �� 	 �� AncestorType"	 ��
 �� AncestorLevel$
 1�� �� Path$&  DataContext.SaveBoardNameCommand���5.   )   �� ��5/   &   �� 50   *    �� ImageSource$ /Images/ChangeIcon.png��65   6\   52   #   �� 53   "   $��DeleteBoardBtn��54   Y   $��
165 0 0 60q�53   )   $��20��6=   $��20��6H   $y�	Collapsed=�6T   $��0q�54   )   $ Delete this board��6=   ��55   )   ��  �� "	 ��$
 1��$  DataContext.DeleteBoardCmd���58   )   �� ��59   &   �� 5:   *   $ /Images/DeleteIconpng.png��65   6_   5<   #   5=      5>      5@      5B      5C      %  Xceed.Wpf.Toolkit.BusyIndicator  5D   
      IsBusy 6   �� *IsBusyOrNot+ �� UpdateSourceTrigger$ PropertyChanged=�6b   5E      5F      