   M S B A M L   `   `   `  ���� R  NLibraryManagementSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:LibraryManagementSystemLibraryManagementSystem      MyBookList.Window1   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     7local%clr-namespace:LibraryManagementSystem       � Title$  Library Management System��$	��500��$
��1000��.��� $��0,11,-0.4,-10.6q� � ColumnDefinitions �� $��20 ��� $
��auto ��� $��* ��� $��20 � � RowDefinitions �� $��20 ��� $
��auto ��� �� $��20 �.+�&   System.Windows.Controls.DataGrid  -     Name$ MyBookListTable��   
IsReadOnly .    CanUserAddRows .     AutoGenerateColumns .  $
��Left=�$	��360��$	��Top=�$	��580��$��2��$��
364,60,0,0q�$��2��   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ No��	   Width5  /System.Windows.Controls.DataGridLengthConverter$	 30 1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 �� *No+   ClipboardContentBinding Z�   $ ID��$	 50 
 �� *ID+ Z�   $ Status��$		 100 
 �� *Status+ Z�   $
 ISBN��$	 70 
 �� *ISBN+ Z�   $ Title��$		 100 
 �� *Title+ Z�   $ 
Issue Date��$		 100 
 �� *	IssueDate+ Z�   $ Due Date��$	 80 
 �� *	DueDate+ Z�   $ User ID��$	 50 
 �� *UserId+ Z� �� -   $��Return Book��$��2��$
��Left=�$��174,333,0,0q�$��2��$	��Top=�$	��156��$��47���� $��ID��$
��Left=�$	��Top=� J� RenderTransformOrigin$ 2.865,3.469&�$��2��$��	66,86,0,0q�$��2��$��25��$��24���� -    ��Name$ ID��$��2��$
��Left=�$��26��$��
102,88,0,0q�$��2�� �� TextWrapping$
 Wrap=�$�� ��$	��Top=�$	��227���� $��User ID��$
��Left=�$	��Top=�$ 2.865,3.469&�$��2��$��
38,116,0,0q�$��2��$��25��$��52���� -   $ UserId��$��2��$
��Left=�$��26��$��101,119,0,0q�$��2��$
 Wrap=�$�� ��$	��Top=�$	��227���� $
��ISBN��$
��Left=�$	��Top=�$ 2.865,3.469&�$��2��$��
51,150,0,0q�$��2��$��25��$��52���� -   $
 ISBN��$��2��$
��Left=�$��26��$��103,150,0,0q�$��2��$
 Wrap=�$�� ��$	��Top=�$	��227���� $��Title��$
��Left=�$	��Top=�$ 2.865,3.469&�$��2��$��
49,181,0,0q�$��2��$��25��$��39���� -   $ Title��$��2��$
��Left=�$��26��$��102,180,0,0q�$��2��$
 Wrap=�$�� ��$	��Top=�$	��228���� $��
Issue Date��$
��Left=�$	��Top=�$ 2.865,3.469&�$��2��$��
22,210,0,0q�$��2��$��25��$��74���� -   $ 	IssueDate��$��2��$
��Left=�$��26��$��102,211,0,0q�$��2��$
 Wrap=�$�� ��$	��Top=�$	��227���� $��Due Date��$
��Left=�$	��Top=�$ 2.865,3.469&�$��2��$��
22,242,0,0q�$��2��$��25��$��68���� -   $ DueDate��$��2��$
��Left=�$��26��$��101,242,0,0q�$��2��$
 Wrap=�$�� ��$	��Top=�$	��227���� $��Status��$
��Left=�$	��Top=�$ 2.865,3.469&�$��2��$��
41,273,0,0q�$��2��$��25��$��49���� -	   $ Status��$��2��$
��Left=�$��26��$��101,273,0,0q�$��2��$
 Wrap=�$�� ��$	��Top=�$	��227��	� -
    	�Name$	 All��$	��All��
 � Tag$	 All��$��2��$
��Left=�$��
563,29,0,0q�$��2��$	��Top=�$��21��$��49��$ 
1.18,0.495&�	� -   $ Request��$��Request��$ Request��$��2��$
��Left=�$��
631,29,0,0q�$��2��$	��Top=�$��21��$��78��	� -   $ Returned��$��Returned��$ Returned��$��2��$
��Left=�$��
813,29,0,0q�$��2��$	��Top=�$��21��$��78��	� -   $
 Loan��$
��Loan��$
 Loan��$��2��$
��Left=�$��
725,29,0,0q�$��2��$	��Top=�$��21��$��62��$ 1.716,0.619&��� $��My Book Status��$��20(�$��2��$
��Left=�$��10,0,0,0q�$��2��$	��Top=�$��42��$	��161��