   M S B A M L   `   `   `  ���� R  NLibraryManagementSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:LibraryManagementSystemLibraryManagementSystem      UserList.Window1   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     7local%clr-namespace:LibraryManagementSystem       � Title$  Library Management System��$	��500��$
��1000��.��� $��0,11,-0.4,-10.6q� � ColumnDefinitions �� $��20 ��� $
��auto ��� $��* ��� $��20 � � RowDefinitions �� $��20 ��� $
��auto ��� �� $��20 �.+��� $��	User Name��$��2��$
��Left=�$��
365,16,0,0q�$��2��$	��Top=��� -    ��Name$ 	SearchKwd��$��20(�$��2��$
��Left=�$��36��$��
434,10,0,0q�$��2�� �� TextWrapping$
 Wrap=�$�� ��$	��Top=�$	��270���� -   $��Search��$��2��$
��Left=�$��
727,10,0,0q�$��2��$	��Top=�$��80��$��36��&   System.Windows.Controls.DataGrid  -     Name$ UserListTable��   
IsReadOnly .    CanUserAddRows .     AutoGenerateColumns .  $
��Left=�$	��360��$	��Top=�$	��580��$��2��$��
364,60,0,0q�$��2��	   Columns	 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn
   Header$
 No��   Width5  /System.Windows.Controls.DataGridLengthConverter$ 30 1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *No+   ClipboardContentBinding Z�   $
 ID��$ 50  �� *ID+ Z�   $
 Position��$ 60  �� *
Position+ Z�   $

 Name��$ 80  �� *Name+ Z�   $
 Email��$	 100  �� *Email+ Z�   $
 Address��$	 100  �� *	Address+ Z�   $
 
PostalCode��$ 80  �� *
PostalCode+ Z�   $
 Phone��$ 80  �� *Phone+ Z�   $
 
Department��$ 80  �� *
Department+ Z�   $
 Semester��$ 80  �� *
Semester+ Z� �� -   $��Update User��$��2��$
��Left=�$��
20,332,0,0q�$��2��$	��Top=�$	��155��$��36���� -   $��Delete User��$��2��$
��Left=�$��190,332,0,0q�$��2��$	��Top=�$	��154��$��36���� -   $��Input Reset��$��2��$
��Left=�$��
20,383,0,0q�$��2��$	��Top=�$	��324��$��36���� $��ID��$
��Left=�$	��Top=� J� RenderTransformOrigin$ 2.865,3.469&�$��2��$��	77,63,0,0q�$��2��$��25��$��24���� -   $ ID��$��2��$
��Left=�$��26��$��
118,62,0,0q�$��2��$
 Wrap=�$�� ��$	��Top=�$	��227���� $
��Name��$
��Left=�$	��Top=�$ 2.865,3.469&�$��2��$��	66,94,0,0q�$��2��$��25��$��46���� -   $
 Name��$��2��$
��Left=�$��26��$��
118,93,0,0q�$��2��$
 Wrap=�$�� ��$	��Top=�$	��228���� $��Email��$
��Left=�$	��Top=�$ 2.865,3.469&�$��2��$��
66,124,0,0q�$��2��$��25��$��52���� -	   $ Email��$��2��$
��Left=�$��26��$��118,124,0,0q�$��2��$
 Wrap=�$�� ��$	��Top=�$	��227���� $��Address��$
��Left=�$	��Top=�$ 2.865,3.469&�$��2��$��
57,154,0,0q�$��2��$��25��$��55���� -
   $ Address��$��2��$
��Left=�$��26��$��118,155,0,0q�$��2��$
 Wrap=�$�� ��$	��Top=�$	��227���� $��
PostalCode��$
��Left=�$	��Top=�$ 2.865,3.469&�$��2��$��
38,186,0,0q�$��2��$��25��$��75���� -   $ 
PostalCode��$��2��$
��Left=�$��26��$��117,186,0,0q�$��2��$
 Wrap=�$�� ��$	��Top=�$	��227���� $��
Department��$
��Left=�$	��Top=�$ 2.865,3.469&�$��2��$��
38,217,0,0q�$��2��$��25��$��74���� -   $ 
Department��$��2��$
��Left=�$��26��$��117,217,0,0q�$��2��$
 Wrap=�$�� ��$	��Top=�$	��227���� $��Semester��$
��Left=�$	��Top=�$ 2.865,3.469&�$��2��$��
51,247,0,0q�$��2��$��25��$��62���� -   $ Semester��$��2��$
��Left=�$��26��$��117,247,0,0q�$��2��$
 Wrap=�$�� ��$	��Top=�$	��227���� $��Position��$
��Left=�$	��Top=�$ 2.865,3.469&�$��2��$��
51,277,0,0q�$��2��$��25��$��61���� -   $��radioButtonPanel��$
��Left=�$��44��$��120,283,0,0q�$	��Top=�$	��226��$��2��$��2��.+�	� -    	�Name$ 	PositionA��$��Administrator��
 � Tag$ A��$��0,0,128.6,0q�	� -   $ 	PositionL��$��	Librarian��$ L��$��0,0,128.6,0q�	� -   $ 	PositionS��$��Student��$ S��$��0,0,128.6,0q��� -   $��	All Users��$��2��$
��Left=�$��
821,10,0,0q�$��2��$	��Top=�$	��122��$��36���� $��User Management��$��20(�$��2��$
��Left=�$��0,18,0,0q�$	��Top=�$��3��$��44��$	��191��