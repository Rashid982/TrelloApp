   M S B A M L   `   `   `  ����A  =Trello, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:Trello.ViewTrello.View  5          Trello.View.Login   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      +localclr-namespace:Trello.View     5      b ^MaterialDesignThemes.Wpf, Version=4.0.0.2422, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      X TXceed.Wpf.Toolkit, Version=4.0.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44wpfx)http://schemas.xceed.com/wpf/xaml/toolkit  5        N� 
Background
  ����� N� Title$ Login��5
   H   .��5      � .+�5   
   �� $ ��/Images/BlueBackGround.jpg��6   $��UniformToFill=�64   6N   �� 5   
   $��35(�6   $
��Bold"�6"   
�������$��Center=�6G   $��0,10,0,0q�6d   Welcome to Trello6�   �� 5   
   $	��330��6   $	��240��6    
������� �� RadiusX$ 15��6:    �� RadiusY$ 15��6G    J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5         Color$ 	#FFBBBBBB��6#      
BlurRadius$ 15Q�65      	Direction$ 0Q�6E      RenderingBias$ Quality=�6S   	   ShadowDepth$	 1Q�6k   5      �� 5   
   $	��Top=�6   $��Center=�6/   $��14(�6L   $��	0,110,0,0q�6Z   .��6m   	SIGN IN6v   �� 5   
   $��Center=�6   $��Center=�62   $	��300��6M   .+�5      �� $��0,5,0,0q�60   $��15(�6A   )  #MaterialDesignThemes.Wpf.HintAssist
   Hint$
 	USER NAME��6O    %  !MaterialDesignFloatingHintTextBox#��[  5      ��5      �� *
UserName+5   T   G� 5      -   5         G�Name$ txtPassword��5      $��15(�6/   $��0,15,0,0q�6=   $
 PASSWORD��5       ) %MaterialDesignFloatingHintPasswordBox#��[ 5      6[   �� 5      -   5        $��PasswordUnmask��5   7   $��	0,-30,0,0q�6   $��15(�6)   $y�Hidden=�6M   �� 5       �� Orientation$ 
Horizontal=�6   $��0,30,0,0q�62   .+�5      �� $	��110��6   $��	25,0,20,0q�6%      MaterialDesignOutlinedButton#��[ 6V   ��68   �� *	SignInCmd+��5       ��  �� ElementName$ txtPassword��.��6N   	Sign In6W   �� 5!      $	��110��6   $��10,0,0,0q�6%   #��[ 5"      ��5!   7   �� *RegistrationCmd+.��5"   P   Registration6^   5#      5$      �� 5&   
   -   5        $��EyeBtn��5&   &   $��35��64   $��	250,5,0,0q�6?   $��0q�6R   ��5'      �� 5(       �� ImageSource$ /Images/Eye.png��6   6=   5*      %  Xceed.Wpf.Toolkit.BusyIndicator  5+   
      IsBusy 6   �� *IsBusyOrNot+ �� UpdateSourceTrigger$ PropertyChanged=�6b   5,      5-      