   M S B A M L   `   `   `  ����D  @LogFilter, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:LogFilter.ViewModelLogFilter.ViewModel  5   	   /    )LogFilter.ViewModel.MainApplicationWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:LogFilter.ViewModel     5   	     � Title$  
Log Filter��5   	   $	��350��6   $	��525��6)   $	��350��65   $	��525��6E   .��5	      ]� .+�5
   
   o� $��15(�6   $	��Top=�6   .@�5      m� $
��File��6   .@�5      m� $��Add Pattern��6   .@�5      m� -   5        $��
Create New��5      63   m� 5      -   5        $��Existing Pattern��5      69   5      m� 5      -   5        $��Destination Folder��5      67   m� 5      -   5        $
��Save��5      6)   m� 5      -   5        $��	Save as..��5      6.   �� 5      m� 5      -   5        $
��Exit��5      6)   5      m� 5      $
��Edit��6   .@�5      m� -   5        $��Remove��5      6+   5      m� 5      $
��View��6   .@�5      m� -   5        $��Search��5      6+   5      m� 5      -	   5        $	��Run��5      6$   5      � 5   
    � ColumnDefinitions 5      �� 5       $
��Auto �6#   �� 5!      $��* �6#   .+�5#      �� -
   5        $��
lvContents��5#      $��0��6)   $
��Auto��69   $
��Auto=�6F   ��6v   ��  �� Path$ PatternsList� �� View 5%      �� 5'      .P�5)      �� $
��Name��6)    �� Width$
 Auto��67    �� DisplayMemberBinding 6D   �� *
FileName+ �� CellTemplate 5*      �� 5+   "   .R�5,   &   �� $
��Auto��6.   $��30��6;   5-   #   5/      �� 51      $��Include��6)   $
 Auto��6:    52      �� 53   "   .R�54   &   ��  d� 	IsChecked$
 TrueY�6/   6B   55   #   57      59      5=      �� 5>      -   5        $��richTB��5>   *   $��1��6   $
��Auto=�68   $
��Auto=�6i   . �5?      /� .T�5@      J� .*�6    .*�5A      �� .�6    Double click a pattern to view6>   5B      5C      5D      5E      5F      5G      