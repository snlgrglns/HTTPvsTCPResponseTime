   M S B A M L   `   `   `  ���� I  EWpfApplication, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:WpfApplication.ModelsWpfApplication.Models  '    !WpfApplication.Pages.MessageTimer   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     Z VFirstFloor.ModernUI, Version=1.0.8.0, Culture=neutral, PublicKeyToken=bc9b0c37bf06c6a90mui&http://firstfloorsoftware.com/ModernUI  /local#clr-namespace:WpfApplication.Models    � DataContext  *  $WpfApplication.Models.TimerViewModel  .���    ContentRoot#��[   � ColumnDefinitions �� $	��100 ��� $��5 ��� $	��200 ��� $��20 ��� $	��100 ��� $��5 ��� $	��200 � � RowDefinitions �� $��30 ��� $��6 ��� $��30 ��� $��6 ��� $��30 ��� $��40 ��� $��30 ��� $��6 ��� $��30 ��� $��40 ��� $��30 ��� $��6 ��� $��30 ��� $��6 ��� $��30 �.+��� -    ��Name$ label��$��4��$��Loops��$
��Left=�$	��Top=�$��31��$	��100���� -    ��Name$ loopNo��$��4��$��2��$
��Left=�$��31�� �� TextWrapping$
 Wrap=�$��Bottom=�$	��200��$��0,0,0,39q�$��2������ *LoopNo+ �� Mode$ TwoWay=� �� ValidatesOnDataErrors . �� -    ��Name$ webBtn��$��4��$	��Web��$
��Left=�$��65��$��6��$��70,0,0,0q��� -   	 ��Name$	 serviceTotal��$��2��$
��Left=�$��31��$��6��$
��Wrap=�$	��Top=�$	��200���� -   $	 
serviceAvg��$��6��$
��Left=�$��31��$��6��$
��Wrap=�$	��Top=�$	��200���� -   $ 
serviceBtn��$��4��$	��TCP��$
��Left=�$	��Top=�$��65��$��31��$��6��$��2���� -   $ label1��$��Total Time:��$
��Left=�$��6��$	��Top=�$��31��$	��100���� -   $ label2��$��Average Time:��$��4��$
��Left=�$��6��$	��Top=�$��31��$	��100���� -	   $ label3��$��	Min Time:��$
��Left=�$��8��$	��Top=�$��31��$	��100���� -
   $ label4��$��	Max Time:��$��4��$
��Left=�$��8��$	��Top=�$��31��$	��100���� -   $	 
serviceMin��$��2��$
��Left=�$��31��$��8��$
��Wrap=�$	��Top=�$	��200���� -   $	 
serviceMax��$��6��$
��Left=�$��31��$��8��$
��Wrap=�$	��Top=�$	��200���� -   $ label5��$��Total Time:��$
��Left=�$��10��$	��Top=�$��30��$	��100���� -   $ label6��$��Average Time:��$��4��$
��Left=�$��10��$	��Top=�$��30��$	��100���� -   $ label7��$��	Min Time:��$
��Left=�$��12��$	��Top=�$��30��$	��100���� -   $ label8��$��	Max Time:��$��4��$
��Left=�$��12��$	��Top=�$��30��$	��100���� -   $	 webTotal��$��2��$
��Left=�$��30��$��10��$
��Wrap=�$	��Top=�$	��200���� -   $	 webAvg��$��6��$
��Left=�$��30��$��10��$
��Wrap=�$	��Top=�$	��200���� -   $	 webMin��$��2��$
��Left=�$��30��$��12��$
��Wrap=�$	��Top=�$	��200���� -   $	 webMax��$��6��$
��Left=�$��30��$��12��$
��Wrap=�$	��Top=�$	��200���� -   
 ��Name$
 	groupBox1��$��Web Time��$
��Left=�$��-10,17,-42,0q�$��9��$	��Top=�$��7��$	��115��$��6��$	��682���� -   $
 groupBox��$��Service Time��$��-16,5,-36,0q�$��5��$	��Top=�$��5��$��7��$	��115��$��Right=�$	��682���� -   $ label9��$��
Socket(IP)��$
��Left=�$	��Top=�$��30��$	��100���� -   $ label10��$��Web(url)��$
��Left=�$��2��$	��Top=�$��30��$	��100���� -   $ ipVal��$��2��$
��Left=�$��30��$
 Wrap=�$	��Top=�$	��200���� -   $ urlVal��$��2��$
��Left=�$��30��$��2��$
 Wrap=�$	��Top=�$	��200���� -   $	 webError��$��4��$
��Left=�$��2��$
��Wrap=�$	��Top=�$��30��$	��100��$y�Hidden=��� -   $	 ipError��$��4��$
��Left=�$
��Wrap=�$	��Top=�$��30��$	��100��$y�Hidden=��� -   $	 errorMessage��$��5��$
��Left=�$
��Wrap=�$	��Top=�$��66��$	��205��$��3��$��2���� -   $ button��$
��Stop��$��6��$
��Left=�$��	140,0,0,0q�$��4��$	��Top=�$��65��$��30��