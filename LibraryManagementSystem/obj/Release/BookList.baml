   M S B A M L   `   `   `  ���� R  NLibraryManagementSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:LibraryManagementSystemLibraryManagementSystem      BookList.Window1   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     7local%clr-namespace:LibraryManagementSystem       � Title$  Library Management System��$	��500��$
��1000��.��� $��0,11,-0.4,-10.6q� � ColumnDefinitions �� $��20 ��� $
��auto ��� $��* ��� $��20 � � RowDefinitions �� $��20 ��� $
��auto ��� $��* ��� $��20 �.+��� $��
Book Title��$��2��$
��Left=�$��
365,16,0,0q�$��2��$	��Top=��� -    ��Name$ 	SearchKwd��$��20(�$��2��$
��Left=�$��36��$��
434,10,0,0q�$��2�� �� TextWrapping$
 Wrap=�$�� ��$	��Top=�$	��270���� -   $��Search��$��2��$
��Left=�$��
727,10,0,0q�$��2��$	��Top=�$��80��$��36��&   System.Windows.Controls.DataGrid  -     Name$ BookListTable��   
IsReadOnly .    CanUserAddRows .     AutoGenerateColumns .  $
��Left=�$	��360��$	��Top=�$	��580��$��2��$��
364,60,0,0q�$��2��	   Columns	 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn
   Header$
 No��   Width5  /System.Windows.Controls.DataGridLengthConverter$ 30 1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *No+   ClipboardContentBinding Z�   $

 ISBN��$ 80  �� *ISBN+ Z�   $
 Title��$	 180  �� *Title+ Z�   $
 Author��$	 130  �� *Author+ Z�   $
 Published Date��$	 100  �� *PublishedDate+ Z�   $
 	Available��$ 80  �� *	Available+ Z� �� -   $��Add Book��$��2��$
��Left=�$��
20,332,0,0q�$��2��$	��Top=�$��92��$��36�� J� RenderTransformOrigin$ 1.63,-0.678&��� -   $��Update Book��$��2��$
��Left=�$��134,332,0,0q�$��2��$	��Top=�$��98��$��36���� -   $��Delete Book��$��2��$
��Left=�$��250,332,0,0q�$��2��$	��Top=�$��94��$��36���� -   $��Input Reset��$��2��$
��Left=�$��
20,383,0,0q�$��2��$	��Top=�$	��324��$��36���� $
��ISBN��$
��Left=�$	��Top=�$ 2.865,3.469&�$��2��$��	77,63,0,0q�$��2��$��25��$��36���� -   $
 ISBN��$��2��$
��Left=�$��26��$��
118,62,0,0q�$��2��$
 Wrap=�$�� ��$	��Top=�$	��227���� $��Title��$
��Left=�$	��Top=�$ 2.865,3.469&�$��2��$��
77,103,0,0q�$��2��$��25��$��35���� -	   $ Title��$��2��$
��Left=�$��26��$��118,102,0,0q�$��2��$
 Wrap=�$�� ��$	��Top=�$	��228���� $��Author��$
��Left=�$	��Top=�$ 2.865,3.469&�$��2��$��
65,137,0,0q�$��2��$��25��$��52���� -
   $ Author��$��2��$
��Left=�$��26��$��117,137,0,0q�$��2��$
 Wrap=�$�� ��$	��Top=�$	��227���� $��Published Date��$
��Left=�$	��Top=�$ 2.865,3.469&�$��2��$��
20,173,0,0q�$��2��$��25��$��97���� -   $ PublishedDate��$��2��$
��Left=�$��26��$��117,173,0,0q�$��2��$
 Wrap=�$�� ��$	��Top=�$	��227���� $��Description��$
��Left=�$	��Top=�$ 2.865,3.469&�$��2��$��
39,213,0,0q�$��2��$��25��$��78���� -   $ Description��$��2��$
��Left=�$��52��$��117,213,0,0q�$��2��$
 Wrap=�$�� ��$	��Top=�$	��227���� $��	Available��$
��Left=�$	��Top=�$ 2.865,3.469&�$��2��$��
51,277,0,0q�$��2��$��25��$��61���� -   $��radioButtonPanel��$
��Left=�$��31��$��120,283,0,0q�$	��Top=�$	��226��$��2��$��2��.+�	� -    	�Name$ 
AvailableY��$��Y��
 � Tag$ Y��$��0,0,128.6,0q�	� -   $ 
AvailableN��$��N��$ N��$��0,0,128.6,0q��� -   $��	All Books��$��2��$
��Left=�$��
821,10,0,0q�$��2��$	��Top=�$	��122��$��36���� $��Book Management��$��20(�$��2��$
��Left=�$��0,18,0,0q�$	��Top=�$��3��$��44��$	��197��