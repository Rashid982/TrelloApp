   M S B A M L   `   `   `  ����A  =Trello, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:Trello.ViewTrello.View  5   D   3clr-namespace:Trello.ViewModelTrello.ViewModel  5          Trello.View.Home   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    6"   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     6>   @d2http://schemas.microsoft.com/expression/blend/2008     5      +localclr-namespace:Trello.View     6D   -VMclr-namespace:Trello.ViewModel     5        N� 
Background
  ����� N� Title$
 Home��5   D   .��5      �  � ColumnDefinitions 5   
   �� 5	      �� 5
      $
��2.4* �6   .+�5   
   �� $
��Auto=�6   .��5      �� .+�5      ��  �� Orientation$ 
Horizontal=�6   .+�5      �� $��
WORKSPACES��6   $��	10,12,0,0q�62   �� 5      $	��Top=�6>   $��78,7,0,0q�6V   
�������
������ 
���   �$��18(�5   J   ��5      �� *AddWorkSpCmd+.��5   Y   +6\   �� 5      $��6,7,0,0q�6E   $��0q�6V   $��38��6j   $��30��6u   $y�	Collapsed=�5      ��5      �� *NotificationCommand+��5      �� 5       �� ImageSource$ /Images/Notification.png��6)   5      5      �� 5      ��6   �� *
Workspaces+��5      �� 5      .R�5      � 5      ��5"      �� 5#      .R�5$      9� $��0,15,0,0q�6'   ��5%   "   �� 5&   &   $ 
Horizontal=�61   .+�5'   *   �� -   5        $��0q�5'   T   $��15(�6h    �� TextWrapping$
 Wrap=�5(   )   $	��120��6>   ��6J   �� *Name+�� 5)   *   $��ChangeIconBtn��5,   )   -   5         � ToolTip$ Change Workspace name��5+   )   $��0q�6I   $y�	Collapsed=�6]   $��16��5,   >   $��16��6J   $��15 0 0 0q�6U   ��5)   1   ��  �� RelativeSource ��  �� AncestorType" ��	 �� Path$%	 DataContext.ChangeWKNameCommand���5*   h   �� ��5-   .   �� 5.   2   $ /Images/ChangeIcon.png��6=   6d   50   +   51   '   .��53   "   �� .+�54   &   �� $��5q�55   ^       MaterialDesignOutlinedButton#��[  56   )   ��54   -   ��  �� " ��$	 DataContext.BoardCmd���55   A   �� .��56   _   Boards6g   �� 57   &   $��5q�58   B   #��[  6M   ��57   -   ��  �� " ��$	 DataContext.DeleteCmd���59   &   �� .��6C   Delete6K   5:   #   5;      5<      5>      5?      5@       � 5B   
   $��1��6   ��6    �� *CurrentPage+5C      5D      