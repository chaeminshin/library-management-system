   M S B A M L   `   `   `  ���� R  NLibraryManagementSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:LibraryManagementSystemLibraryManagementSystem      BookListS.Window1   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     7local%clr-namespace:LibraryManagementSystem       � Title$  Library Management System��$	��500��$
��1000��.��� $��0,11,-0.4,-10.6q� � ColumnDefinitions �� $��20 ��� $
��auto ��� $��* ��� $��20 � � RowDefinitions �� $��20 ��� $
��auto ��� $��* ��� $��20 �.+��� $��
Book Title��$��2��$
��Left=�$��
210,16,0,0q�$��2��$	��Top=��� -    ��Name$ 	SearchKwd��$��20(�$��2��$
��Left=�$��36��$��
280,10,0,0q�$��2�� �� TextWrapping$
 Wrap=�$�� ��$	��Top=�$	��270���� -   $��Search��$��2��$
��Left=�$��
572,10,0,0q�$��2��$	��Top=�$��80��$��36��&   System.Windows.Controls.DataGrid  -     Name$ BookListTableS��   
IsReadOnly .    CanUserAddRows .     AutoGenerateColumns .  $
��Left=�$	��265��$	��Top=�$	��934��$��2��$��	10,60,0,0q�$��2��	   Columns	 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn
   Header$
 No��   Width5  /System.Windows.Controls.DataGridLengthConverter$ 30 1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *No+   ClipboardContentBinding Z�   $

 ISBN��$ 80  �� *ISBN+ Z�   $
 Title��$	 200  �� *Title+ Z�   $
 Author��$	 130  �� *Author+ Z�   $
 Description��$	 300  �� *Description+ Z�   $
 Published Date��$	 100  �� *PublishedDate+ Z�   $
 	Available��$ 80  �� *	Available+ Z� �� -   $��	Check Out��$��2��$
��Left=�$��
10,341,0,0q�$��2��$	��Top=�$	��933��$��78���� -   $��	All Books��$��2��$
��Left=�$��
666,10,0,0q�$��2��$	��Top=�$	��122��$��36���� $��Borrow Book��$��20(�$��2��$
��Left=�$��	10,10,0,0q�$	��Top=�$��3��$��39��$	��148��