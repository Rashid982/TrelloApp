   M S B A M L   `   `   `  ����A  =Trello, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:Trello.ViewTrello.View  5          Trello.View.Registration   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    6/   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     6>   @d2http://schemas.microsoft.com/expression/blend/2008     5      b ^MaterialDesignThemes.Wpf, Version=4.0.0.2422, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      %localclr-namespace:Trello.View  5      X TXceed.Wpf.Toolkit, Version=4.0.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44wpfx)http://schemas.xceed.com/wpf/xaml/toolkit  5        N� 
Background
  ����� N� Title$ Registration��6C   .��5	      � .+�5
   
   �� $ ��/Images/BlueBackGround.jpg��6   $��UniformToFill=�64   6N   �� 5   
   $	��330��6   $	��350��6    
������� �� RadiusX$ 15��6:    �� RadiusY$ 15��6G    J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5         Color$ 	#FFBBBBBB��6#      
BlurRadius$ 15Q�65      	Direction$ 0Q�6E      RenderingBias$ Quality=�6S   	   ShadowDepth$	 1Q�6k   5      �� 5   
   $	��Top=�6   $��Center=�6/   $��12(�6L   $��0,45,0,0q�6Z   .��6l   REGISTRATION6z   �� 5   
   $��Center=�6   $��Center=�62   $	��300��6M   .+�5      �� $��0,0,0,0q�6�   $��15(�6�   )  #MaterialDesignThemes.Wpf.HintAssist
   Hint$

 NAME��6�    %  !MaterialDesignFloatingHintTextBox#��[  6�   ��6   �� *Name+ �� UpdateSourceTrigger$ PropertyChanged=� �� ValidatesOnDataErrors . " �� ValidatesOnNotifyDataErrors . 6  �� 5      $��0,0,0,0q�6�   $��15(�6�   $
 SURNAME��6�   #��[  6�   ��6   �� *	Surname+$ PropertyChanged=� .  . 6  �� 5      $��15(�6�   $
 NUMBER��6�   #��[  6�   ��6   �� *Number+$ PropertyChanged=� .  . 6  �� 5      $��0,0,0,0q�6�   $��15(�6�   $
 USERNAME��6�   #��[  6�   ��6   �� *
UserName+$ PropertyChanged=� .  . 6  G� 5      -   5         G�Name$ txtPassword��5      $��0,0,0,0q�6/   $��15(�6@   $
 PASSWORD��6O    ) %MaterialDesignFloatingHintPasswordBox#��[ 6z   6�   �� 5       �� Orientation$ 
Horizontal=�6   $��0,30,0,0q�62   .+�5      ��    MaterialDesignOutlinedButton#��[ 6   $��20,0,0,0q�6p   $	��110��6�   ��6P   �� *RegisterCmd+��6�   ��  �� ElementName$ txtPassword��.��6�   
Register6�   �� 5      #��[ 6   $��50,0,0,0q�6n   $	��100��6�   ��6P   �� *	CancelCmd+.��6�   Cancel6�   5      5      %  Xceed.Wpf.Toolkit.BusyIndicator  5   
      IsBusy 6   �� *IsBusyOrNot+$ PropertyChanged=�6b   5      5      